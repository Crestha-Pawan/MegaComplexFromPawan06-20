using FiboBilling.InfraStructure.Repository;
using FiboBlock.InfraStructure.Assembler;
using FiboBlock.InfraStructure.Repository;
using FiboBlock.InfraStructure.Service;
using FiboBlock.Src.ViewModel;
using FiboInfraStructure.Entity.FiboBilling;
using FiboInfraStructure.Entity.FiboBlock;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiboInfraStructure;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using FiboOffice.InfraStructure.Repository;

namespace CItyCenterSystem.Areas.FiboLedger.Controllers
{
    public class LedgerController : Controller
    {
        private readonly IClientAssembler _clientAssembler;
        private readonly IClientRepository _clientRepository;
        private readonly IClientService _clientService;
        private readonly IBillingRepository _bDRepo;
        private readonly IBillingDetailRepository _billingDetailRepository;
        private readonly IBlockRepository _blockRepo;
        private readonly IYearRepository _yearRepo;
        private readonly IMonthRepository _monthRepo;
        private readonly IRoomRepository _roomRepo;
        private readonly IClientBlockRoomSetupRepository _cblRepo;
        public LedgerController(IClientAssembler clientAssembler
            , IClientRepository clientRepository
            , IClientService clientService
            , IBillingDetailRepository billingDetailRepository
            , IBillingRepository bDRepo
            , IBlockRepository blockRepository
            , IRoomRepository roomRepository
            , IYearRepository yearRepository
            , IMonthRepository monthRepository
            , IClientBlockRoomSetupRepository cblRepo
            )
        {
            _clientAssembler = clientAssembler;
            _clientRepository = clientRepository;
            _clientService = clientService;
            _bDRepo = bDRepo;
            _blockRepo = blockRepository;
            _roomRepo = roomRepository;
            _yearRepo = yearRepository;
            _monthRepo = monthRepository;
            _cblRepo = cblRepo;
            _billingDetailRepository = billingDetailRepository;
        }
        public async Task<IActionResult> ClientList(ClientViewModel vm)
        {
            vm.Clients = new List<Client>();
            var clients = await _clientRepository.GetAllClientAsync();
            vm.Clients = clients;
            vm.ClientList = await _clientRepository.GetAllClientAsync();

            if (vm.ClientId > 0)
            {
                vm.Clients = vm.Clients.Where(x => x.Id == vm.ClientId).ToList();
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> ClientLedger(long? id)
        {
            ClientViewModel vm = new ClientViewModel();
            vm.Billings = new List<Billing>();
            var billing = await _bDRepo.GetAllBillingAsync();
            vm.Clients = new List<Client>();
            vm.Clients = await _clientRepository.GetAllClientAsync();
            vm.Clients = vm.Clients.Where(x => x.Id == id).ToList();
            vm.Billings = billing.Where(x => x.ClientId == id).ToList();
            vm.ClientId = (long)id;
            ViewBag.ClientID = id;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> ClientLedger(ClientViewModel vm)
        {
            vm.Billings = new List<Billing>();
            var billing = await _bDRepo.GetAllBillingAsync();
            vm.Billings = billing.Where(x => x.ClientId == vm.ClientId).ToList();
            if (!string.IsNullOrEmpty(vm.FromMiti))
            {
                vm.FromDate = vm.FromMiti.ToEnglishDate();
                vm.Billings = vm.Billings.Where(x => x.DueDate >= vm.FromDate).ToList();
            }
            if (!string.IsNullOrEmpty(vm.ToMiti))
            {
                vm.ToDate = vm.ToMiti.ToEnglishDate();
                vm.Billings = vm.Billings.Where(x => x.DueDate <= vm.ToDate).ToList();
            }
            vm.Clients = new List<Client>();
            vm.Clients = await _clientRepository.GetAllClientAsync();
            vm.Clients = vm.Clients.Where(x => x.Id == vm.ClientId).ToList();

            ViewBag.ClientID = vm.ClientId;
            return View(vm);
        }
        public async Task<ActionResult> ExportToExcel()
        {
            var client = await _clientRepository.GetAllClientAsync();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage pck = new ExcelPackage();

            using (var package = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
            {

            }
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.TabColor = System.Drawing.Color.Black;

            ws.Cells["A1"].Value = "PARICHAYA AWAS BIKASH PVT. LTD.";

            ws.Cells["A3"].Value = "Client Ledger";

            ws.Cells["A6"].Value = "Date";
            ws.Cells["B6"].Value = "Owner Name";
            ws.Cells["C6"].Value = "Address";
            ws.Cells["D6"].Value = "Business Name";
            ws.Cells["E6"].Value = "Pan Number";
            ws.Cells["F6"].Value = "Contact Number";
            ws.Cells["G6"].Value = "CitizenshipNo";
            ws.Cells["H6"].Value = "Collaterol(Rs.)";

            ws.Row(6).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Row(6).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#228b22")));
            int rowStart = 7;
            foreach (var item in client)
            {
                ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#F7F4F3")));

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Date;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.OwnerName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Address;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.BusinessName;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.PanNo;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.ContactNumber;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.CitizenShipNo;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Collateral;

                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();

            Response.Clear();

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment; filename=" + "LedgerExcelReport.xlsx");
            Response.Body.Write(pck.GetAsByteArray());
            var syncIOFeature = HttpContext.Features.Get<IHttpBodyControlFeature>();
            if (syncIOFeature != null)
            {
                syncIOFeature.AllowSynchronousIO = true;
            }
            Response.StatusCode = StatusCodes.Status200OK;
            //Response.End();
            return View();
        }

        public async Task<ActionResult> LedgerExportToExcel(long clientId)
        {
            var billing = await _bDRepo.GetAllBillingAsync();
            var client = await _clientRepository.GetAllClientAsync();
            var clientblockroom = await _cblRepo.GetAllClientBlockRoomSetupAsync();
            client = client.Where(x => x.Id == clientId).ToList();
            billing = billing.Where(x => x.ClientId == clientId).ToList();
            clientblockroom = clientblockroom.Where(x => x.ClientId == clientId).ToList();
            var _room = string.Empty;
            var billingDetail = await _billingDetailRepository.GetAllBillingAsync();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage pck = new ExcelPackage();

            using (var package = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
            {

            }
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.TabColor = System.Drawing.Color.Black;

            ws.Cells["A1"].Value = "Client Information";
            foreach (var cl in client)
            {
                ws.Cells["A3"].Value = "Business Name";
                ws.Cells["B3"].Value = cl.BusinessName;
                ws.Cells["D3"].Value = "Owner Name";
                ws.Cells["E3"].Value = cl.OwnerName;
                ws.Cells["G3"].Value = "Contact";
                ws.Cells["H3"].Value = cl.ContactNumber;
                ws.Cells["G4"].Value = "Opening Balance/Collaterol";
                ws.Cells["H4"].Value = cl.Collateral;

            }
            foreach (var cbr in clientblockroom)
            {
                ws.Cells["A4"].Value = "Room Number";
                if (cbr.RoomId.Contains(","))
                {
                    var rooms = await _roomRepo.GetAllRoomAsync();
                    string[] _tmpRoom = cbr.RoomId.Split(",");
                    foreach (var id in _tmpRoom)
                    {
                        var room = rooms.Where(x => x.Id == long.Parse(id)).FirstOrDefault();
                        _room += room.Name + ",";
                        ws.Cells["B4"].Value = _room;
                    }
                }
                else
                {
                    var rooms = await _roomRepo.GetAllRoomAsync();
                    var room = rooms.Where(x => x.BlockId == cbr.BlockId).FirstOrDefault();
                    _room += room.Name + ",";
                    ws.Cells["B4"].Value = _room;
                }
                ws.Cells["D4"].Value = "Block Number";
                if (cbr.BlockId != null)
                {
                    var blocks = await _blockRepo.GetAllBlockAsync();
                    var block = blocks.Where(x => x.Id == cbr.BlockId).FirstOrDefault().Name;
                    ws.Cells["E4"].Value = block;
                }
            }
           
            ws.Cells["A7"].Value = "Date";
            ws.Cells["B7"].Value = "Particular";
            ws.Cells["C7"].Value = "Vch No.";
            ws.Cells["D7"].Value = "Block";
            ws.Cells["E7"].Value = "Room";
            ws.Cells["F7"].Value = "Room Rent";
            ws.Cells["G7"].Value = "Unit";
            ws.Cells["H7"].Value = "Unit Charge";
            ws.Cells["I7"].Value = "Rent Fine";
            ws.Cells["J7"].Value = "Electricity Fine";
            ws.Cells["K7"].Value = "Total Amount";
            ws.Cells["L7"].Value = "Recieved Amount";
            ws.Cells["M7"].Value = "Due Amount";

            ws.Row(7).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Row(7).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#228b22")));
            int rowStart = 8;
            decimal? balance = 0;
            decimal? totalBalance = 0;
            foreach (var item in billing)
            {
                ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#F7F4F3")));
                decimal? pmTotalDr = 0;
                decimal due = 0;
                decimal? totalDr = 0;
                decimal? totalCr = 0;
                var openingBalance = client.FirstOrDefault().Collateral;
                balance += item.CashReceived.ToDecimal() + item.DuePaid.ToDecimal();
                totalBalance += item.GrandTotal.ToDecimal() + item.Fine.ToDecimal() + item.ElectricityFineAmount.ToDecimal() - item.Discount.ToDecimal();
                totalDr = totalBalance - balance;
                totalCr = balance - totalBalance;
                due = item.DuePaid.ToDecimal();
                decimal? pmTotalBalance = 0;
                decimal? pmTotalCr = item.CashReceived.ToDecimal();
                pmTotalDr = item.GrandTotal.ToDecimal() + item.Fine.ToDecimal() + item.ElectricityFineAmount.ToDecimal() - item.Discount.ToDecimal() - item.DuePaid.ToDecimal();
                pmTotalBalance = pmTotalDr - pmTotalCr;
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.CreatedDate.ToDateTime().ToNepDate();
                if (balance > totalBalance)
                {
                    ws.Cells["A5"].Value = "Cr(Advance)";
                    ws.Cells[string.Format("B5", rowStart)].Value = totalCr;
                }
                else
                {
                    ws.Cells["A5"].Value = "Dr(Due)";
                    ws.Cells[string.Format("B5", rowStart)].Value = totalDr;
                }
                ws.Cells["G5"].Value = "Closing Balance";
                ws.Cells[string.Format("H5", rowStart)].Value = balance;

                foreach (var detail in billingDetail.Where(x => x.BillingId == item.Id).ToList())
                {


                    if (detail.YearId != null && detail.MonthId != null)
                    {
                        var year = await _yearRepo.GetByIdAsync((long)detail.YearId);

                        var month = await _monthRepo.GetByIdAsync((long)detail.MonthId);
                        var YearMonth = string.Format("{0}/{1}", year.YearName, month.MonthName);
                        ws.Cells[string.Format("B{0}", rowStart)].Value = YearMonth;
                    }
                }
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.BillNo;
                foreach (var detail in billingDetail.Where(x => x.BillingId == item.Id).ToList())
                {
                    if (detail.BlockId != null)
                    {
                        var blocks = await _blockRepo.GetAllBlockAsync();
                        var block = blocks.Where(x => x.Id == detail.BlockId).FirstOrDefault().Name;
                        ws.Cells[string.Format("D{0}", rowStart)].Value = block;
                    }
                    if (detail.RoomId != null)
                    {
                        var rooms = await _roomRepo.GetAllRoomAsync();
                        var room = rooms.Where(x => x.Id == detail.RoomId).FirstOrDefault().Name;
                        ws.Cells[string.Format("E{0}", rowStart)].Value = room;
                    }
                    ws.Cells[string.Format("F{0}", rowStart)].Value = detail.RentAmount;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = detail.ElectricityUnit;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = detail.ElectricityBillAmount;
                }

                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Fine;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.ElectricityFineAmount;
                ws.Cells[string.Format("K{0}", rowStart)].Value = pmTotalDr;
                if (due > pmTotalDr)
                {
                    ws.Cells[string.Format("L{0}", rowStart)].Value = due.ToString().Trim('-');
                }
                else
                {
                    ws.Cells[string.Format("L{0}", rowStart)].Value = item.CashReceived;
                }

                if (pmTotalBalance.ToString().Contains('-'))
                {
                    ws.Cells[string.Format("M{0}", rowStart)].Value = pmTotalBalance.ToString().Trim('-');
                }
                else
                {
                    ws.Cells[string.Format("M{0}", rowStart)].Value = pmTotalBalance;
                }
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();

            Response.Clear();

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment; filename=" + "ClientInformationExcelReport.xlsx");
            Response.Body.Write(pck.GetAsByteArray());
            var syncIOFeature = HttpContext.Features.Get<IHttpBodyControlFeature>();
            if (syncIOFeature != null)
            {
                syncIOFeature.AllowSynchronousIO = true;
            }
            Response.StatusCode = StatusCodes.Status200OK;
            //Response.End();
            return View();
        }
    }
}
