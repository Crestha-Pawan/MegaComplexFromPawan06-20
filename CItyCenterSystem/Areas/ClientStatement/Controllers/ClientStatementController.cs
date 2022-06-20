using FiboBilling.InfraStructure.Repository;
using FiboBlock.InfraStructure.Assembler;
using FiboBlock.InfraStructure.Repository;
using FiboBlock.InfraStructure.Service;
using FiboBlock.Src.ViewModel;
using FiboInfraStructure;
using FiboInfraStructure.Entity.FiboBilling;
using FiboInfraStructure.Entity.FiboBlock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem.Areas.ClientStatement.Controllers
{
    public class ClientStatementController : Controller
    {
        private readonly IClientAssembler _clientAssembler;
        private readonly IClientRepository _clientRepository;
        private readonly IClientService _clientService;
        private readonly IBillingRepository _bDRepo;
        private readonly IBlockRepository _blockRepo;
        private readonly IRoomRepository _roomRepo;
        private readonly IClientBlockRoomSetupRepository _cblRepo;
        public ClientStatementController(IClientAssembler clientAssembler
            , IClientRepository clientRepository
            , IClientService clientService
            , IBillingRepository bDRepo
            , IBlockRepository blockRepository
            , IRoomRepository roomRepository
            , IClientBlockRoomSetupRepository cblRepo
            )
        {
            _clientAssembler = clientAssembler;
            _clientRepository = clientRepository;
            _clientService = clientService;
            _bDRepo = bDRepo;
            _blockRepo = blockRepository;
            _roomRepo = roomRepository;
            _cblRepo = cblRepo;
        }
        public async Task<IActionResult> Index(ClientViewModel vm)
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
        public async Task<IActionResult> ClientStatement(long? id)
        {
            ClientViewModel vm = new ClientViewModel();
            vm.Billings = new List<Billing>();
            vm.Clients = new List<Client>();
            vm.Clients = await _clientRepository.GetAllClientAsync();
            vm.Clients = vm.Clients.Where(x => x.Id == id).ToList();
            var billing = await _bDRepo.GetAllBillingAsync();
            vm.Billings = billing.Where(x => x.ClientId == id).ToList();
            vm.ClientId = id;
            return View(vm);
        }
        public async Task<ActionResult> LedgerExportToExcel(long? clientId)
        {
            var billing = await _bDRepo.GetAllBillingAsync();
            var client = await _clientRepository.GetAllClientAsync();
            var clientblockroom = await _cblRepo.GetAllClientBlockRoomSetupAsync();
            client = client.Where(x => x.Id == clientId).ToList();
            billing = billing.Where(x => x.ClientId == clientId).ToList();
            clientblockroom = clientblockroom.Where(x => x.ClientId == clientId).ToList();
            var _room = string.Empty;
           
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
            ws.Cells["C7"].Value = "Debit";
            ws.Cells["D7"].Value = "Credit";
            ws.Cells["E7"].Value = "Balance";

            ws.Row(7).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Row(7).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#228b22")));
            int rowStart = 8;
            decimal? balance = 0;
            decimal? totalDr = 0;
            decimal? totalBalance = 0;
            foreach (var item in billing)
            {
                ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#F7F4F3")));
                decimal? pmTotalDr = 0;
                decimal due = 0;
                var openingBalance = client.FirstOrDefault().Collateral;
                balance += item.CashReceived.ToDecimal() + item.DuePaid.ToDecimal();
                due = item.DuePaid.ToDecimal();
                decimal? pmTotalBalance = 0;
                pmTotalDr = item.GrandTotal.ToDecimal() + item.Fine.ToDecimal() + item.ElectricityFineAmount.ToDecimal() - item.Discount.ToDecimal() - item.DuePaid.ToDecimal();
                pmTotalBalance = pmTotalDr - item.CashReceived.ToDecimal();
                totalDr += pmTotalDr;
                totalBalance += pmTotalBalance;
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.CreatedDate.ToDateTime().ToNepDate();
               
                ws.Cells["G5"].Value = "Closing Balance";
                ws.Cells[string.Format("H5", rowStart)].Value = balance;

               
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.BillNo;
                ws.Cells[string.Format("C{0}", rowStart)].Value = pmTotalDr;
                if (due > pmTotalDr)
                {
                    ws.Cells[string.Format("D{0}", rowStart)].Value = due.ToString().Trim('-');
                }
                else
                {
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.CashReceived;
                }
                if (due > pmTotalDr)
                {
                    ws.Cells[string.Format("E{0}", rowStart)].Value = due.ToString().Trim('-');
                }
                else
                {
                    ws.Cells[string.Format("E{0}", rowStart)].Value = pmTotalBalance;
                }

                rowStart++;
            }
            ws.Cells[string.Format("C{0}", rowStart)].Value = totalDr;//debit total
            ws.Cells[string.Format("D{0}", rowStart)].Value = balance;// cr total
            ws.Cells[string.Format("E{0}", rowStart)].Value = totalBalance;// balance total
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
