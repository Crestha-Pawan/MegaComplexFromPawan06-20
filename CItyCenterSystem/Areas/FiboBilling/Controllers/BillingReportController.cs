using FiboBilling.InfraStructure.Assembler;
using FiboBilling.InfraStructure.Repository;
using FiboBilling.InfraStructure.Service;
using FiboBilling.Src.ViewModel;
using FiboBlock.InfraStructure.Repository;
using FiboInfraStructure.Data;
using FiboOffice.InfraStructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiboInfraStructure;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace CItyCenterSystem.Areas.FiboBilling.Controllers
{
    public class BillingReportController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBillingService _service;
        public readonly IClientRepository _clientRepo;
        private readonly IBillingRepository _repo;
        private readonly IBillingAssembler _assembler;
        private readonly IBillingDetailService _bDetailService;
        private readonly IBillingDetailRepository _bDetailRepo;
        private readonly IBillingDetailAssembler _bDetailAssembler;
        private readonly IBlockRepository _blockRepo;
        private readonly IYearRepository _yearRepo;
        private readonly IMonthRepository _monthRepo;
        private readonly IRoomRepository _roomRepo;
        public BillingReportController(
            IBillingService service
            , IBillingRepository repo
            , IBillingAssembler assembler
            , IBillingDetailService bDetailService
            , IBillingDetailAssembler bDetailAssembler
            , IBillingDetailRepository bDetailRepo
            , IBlockRepository blockRepo
            , IYearRepository yearRepo
            , IClientRepository clientRepo
            , IMonthRepository monthRepo
            , IRoomRepository roomRepo
            , ApplicationDbContext context
            )
        {
            _repo = repo;
            _assembler = assembler;
            _service = service;
            _bDetailService = bDetailService;
            _bDetailRepo = bDetailRepo;
            _bDetailAssembler = bDetailAssembler;
            _blockRepo = blockRepo;
            _yearRepo = yearRepo;
            _clientRepo = clientRepo;
            _monthRepo = monthRepo;
            _roomRepo = roomRepo;
            _context = context;
        }
        public async Task<ActionResult> BillingReport(BillingViewModel vm)
        {
            var billingList = await _repo.GetAllBillingAsync();
            vm.BillingList = billingList.ToList();
            vm.Clients = await _clientRepo.GetAllClientAsync();
            if (!string.IsNullOrEmpty(vm.FromMiti))
            {
                vm.FromDate = vm.FromMiti.ToEnglishDate();
                vm.BillingList = vm.BillingList.Where(x => x.DueDate >= vm.FromDate).ToList();
            }
            if (!string.IsNullOrEmpty(vm.ToMiti))
            {
                vm.ToDate = vm.ToMiti.ToEnglishDate();
                vm.BillingList = vm.BillingList.Where(x => x.DueDate <= vm.ToDate).ToList();
            }
            if (vm.ClientId > 0)
            {
                vm.BillingList = vm.BillingList.Where(x => x.ClientId == vm.ClientId).ToList();
            }
            var billingDetail = await _bDetailRepo.GetAllBillingAsync();
            billingDetail = billingDetail.ToList();
            vm.BillingDetailList = billingDetail;
            return View(vm);
        }


        public async Task<ActionResult> MonthlyReport(long id, string actionName)
        {
            BillingViewModel vm = new BillingViewModel()
            {
                MonthList = await _monthRepo.GetAllMonthAsync(),
                Years = await _yearRepo.GetAllYearAsync()
            };

            //vm.BusSetupId = id;
            vm.ActionName = actionName;
            return View(vm);
        }
        public async Task<ActionResult> BillingDetails(string id)
        {
            string yearId = id.Split("-")[0].Trim();
            long lYearId = long.Parse(yearId);
            string monthNo = id.Split("-")[1].Trim();
            var monthList = await _monthRepo.GetAllMonthAsync();
            var month = monthList.Where(x => x.MonthOrder == monthNo).FirstOrDefault();
            var YearList = await _yearRepo.GetAllYearAsync();
            var year = YearList.Where(x => x.Id == lYearId).FirstOrDefault();
            BillingViewModel vm = new BillingViewModel();
            var billingList = await _repo.GetAllBillingAsync();
            vm.BillingList = billingList.Where(x => x.YearId == lYearId).ToList();
            var billingDetail = await _bDetailRepo.GetAllBillingAsync();
            billingDetail = billingDetail.Where(x => x.YearId == lYearId && x.MonthId == month.Id).ToList();
            vm.BillingDetailList = billingDetail;

            ViewBag.Month = month.MonthName;
            ViewBag.Year = year.YearName;
            return View(vm);
        }

        public async Task<ActionResult> ExportToExcel()
        {
            var billing = await _repo.GetAllBillingAsync();
            var billingDetail = await _bDetailRepo.GetAllBillingAsync();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage pck = new ExcelPackage();

            using (var package = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
            {

            }
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.TabColor = System.Drawing.Color.Black;

            ws.Cells["A1"].Value = "PARICHAYA AWAS BIKASH PVT. LTD.";

            ws.Cells["A3"].Value = "Billing Report";


            ws.Cells["A6"].Value = "Date";
            ws.Cells["B6"].Value = "Client Name";
            ws.Cells["C6"].Value = "Particular";
            ws.Cells["D6"].Value = "Vch No.";
            ws.Cells["E6"].Value = "Block";
            ws.Cells["F6"].Value = "Room";
            ws.Cells["G6"].Value = "Room Rent";
            ws.Cells["H6"].Value = "Maintanance";
            ws.Cells["I6"].Value = "Unit";
            ws.Cells["J6"].Value = "Unit Charge";
            ws.Cells["K6"].Value = "Rent Fine";
            ws.Cells["L6"].Value = "Electricity Fine";
            ws.Cells["M6"].Value = "Due Paid";
            ws.Cells["N6"].Value = "Amount Recieved";

            ws.Row(6).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Row(6).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#228b22")));
            int rowStart = 7;
            foreach (var item in billing)
            {
                ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#F7F4F3")));

                foreach (var detail in billingDetail.Where(x => x.BillingId == item.Id).ToList())
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.CreatedDate.ToDateTime().ToNepDate();
                    
                    if (item.ClientId != null)
                    {
                        var clients = await _clientRepo.GetAllClientAsync();
                        var client = clients.Where(x => x.Id == item.ClientId).FirstOrDefault().OwnerName;
                        ws.Cells[string.Format("B{0}", rowStart)].Value = client;
                    }
                    if (detail.YearId != null && detail.MonthId != null)
                    {
                        var year = await _yearRepo.GetByIdAsync((long)detail.YearId);

                        var month = await _monthRepo.GetByIdAsync((long)detail.MonthId);
                        var YearMonth = string.Format("{0}/{1}", year.YearName, month.MonthName);
                        ws.Cells[string.Format("C{0}", rowStart)].Value = YearMonth;
                    }
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.BillNo;
                    if (detail.BlockId != null)
                    {
                        var blocks = await _blockRepo.GetAllBlockAsync();
                        var block = blocks.Where(x => x.Id == detail.BlockId).FirstOrDefault().Name;
                        ws.Cells[string.Format("E{0}", rowStart)].Value = block;
                    }
                    if (detail.RoomId != null)
                    {
                        var rooms = await _roomRepo.GetAllRoomAsync();
                        var room = rooms.Where(x => x.Id == detail.RoomId).FirstOrDefault().Name;
                        ws.Cells[string.Format("F{0}", rowStart)].Value = room;
                    }
                    ws.Cells[string.Format("G{0}", rowStart)].Value = detail.RentAmount;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.MaintenanceCharge;
                    ws.Cells[string.Format("I{0}", rowStart)].Value = detail.ElectricityUnit;
                    ws.Cells[string.Format("J{0}", rowStart)].Value = detail.ElectricityBillAmount;
                    ws.Cells[string.Format("K{0}", rowStart)].Value = item.Fine;
                    ws.Cells[string.Format("L{0}", rowStart)].Value = item.ElectricityFineAmount;
                    ws.Cells[string.Format("M{0}", rowStart)].Value = item.DuePaid;
                    ws.Cells[string.Format("N{0}", rowStart)].Value = item.CashReceived;
                    rowStart++;
                }

            }
            ws.Cells["A:AZ"].AutoFitColumns();

            Response.Clear();

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment; filename=" + "BillingReportExcelReport.xlsx");
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
