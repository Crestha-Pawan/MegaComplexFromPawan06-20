using FiboBilling.InfraStructure.Assembler;
using FiboBilling.InfraStructure.Repository;
using FiboBilling.InfraStructure.Service;
using FiboBilling.Src.Dto;
using FiboBilling.Src.ViewModel;
using FiboBlock.InfraStructure.Repository;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboBilling;
using FiboOffice.InfraStructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiboInfraStructure;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using FiboInfraStructure.Entity.FiboBlock;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using OfficeOpenXml;

namespace CItyCenterSystem.Areas.FiboBilling.Controllers
{
    public class BillingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBillingService _service;
        private readonly IBillingRepository _repo;
        private readonly IBillingAssembler _assembler;
        private readonly IBillingDetailService _bDetailService;
        private readonly IBillingDetailRepository _bDetailRepo;
        private readonly IBillingDetailAssembler _bDetailAssembler;
        private readonly IYearRepository _yearRepo;
        private readonly IMonthRepository _monthRepo;
        private readonly IClientRepository _clientRepo;
        private readonly IBlockRepository _blockRepo;
        private readonly IRoomRepository _roomRepo;
        private readonly IFineSetupRepository _fineRepo;
        private readonly IElectricityRepository _eRepo;
        private readonly IElectricityUnitSetupRepository _eSetupRepo;
        private readonly IElectricityFineSetupRepository _eFineSetupRepo;
        private readonly IClientBlockRoomSetupRepository _clientBlockSetupRepo;
        private readonly IClientRoomMaintenanceRepository _clientRoomMaintenanceRepo;
        public BillingController(
            IBillingService service
            , IBillingRepository repo
            , IBillingAssembler assembler
            , IBillingDetailService bDetailService
            , IBillingDetailAssembler bDetailAssembler
            , IBillingDetailRepository bDetailRepo
            , IYearRepository yearRepo
            , IMonthRepository monthRepo
            , IClientRepository clientRepo
            , IBlockRepository blockRepo
            , IRoomRepository roomRepo
            , IFineSetupRepository fineRepo
            , IElectricityRepository eRepo
            , IElectricityUnitSetupRepository eSetupRepo
            , IElectricityFineSetupRepository eFineSetupRepo
            , IClientBlockRoomSetupRepository clientBlockSetupRepo
            , IClientRoomMaintenanceRepository clientRoomMaintenanceRepo
            , ApplicationDbContext context
            )
        {
            _repo = repo;
            _assembler = assembler;
            _service = service;
            _bDetailService = bDetailService;
            _bDetailRepo = bDetailRepo;
            _bDetailAssembler = bDetailAssembler;
            _yearRepo = yearRepo;
            _monthRepo = monthRepo;
            _clientRepo = clientRepo;
            _blockRepo = blockRepo;
            _roomRepo = roomRepo;
            _context = context;
            _fineRepo = fineRepo;
            _eRepo = eRepo;
            _eSetupRepo = eSetupRepo;
            _eFineSetupRepo = eFineSetupRepo;
            _clientBlockSetupRepo = clientBlockSetupRepo;
            _clientRoomMaintenanceRepo = clientRoomMaintenanceRepo;
        }
        public async Task<IActionResult> Index(BillingViewModel vm, string message)
        {
            string _currentdate = DateTime.Now.ToDateTime().ToNepDate();
            string _currentYear = _currentdate.Split("-")[0].Trim();
            string _currentMonth = _currentdate.Split("-")[1].Trim();
            var month = await _monthRepo.GetAllMonthAsync();
            var _monthName = month.Where(x => x.MonthOrder == _currentMonth).FirstOrDefault();
            string nepstartDate = string.Empty;
            string nependDate = string.Empty;
            if (_currentMonth == "12")
            {
                nepstartDate = _currentYear + "/" + _currentMonth + "/" + "1";
                nependDate = (Convert.ToDecimal(_currentYear) + Convert.ToDecimal(1)).ToString() + "/" + "1" + "/" + "1";
            }
            else
            {
                nepstartDate = _currentYear + "/" + _currentMonth + "/" + "1";
                nependDate = _currentYear + "/" + (Convert.ToDecimal(_currentMonth) + Convert.ToDecimal(1)).ToString() + "/" + "1";
            }
            DateTime? startDate = nepstartDate.ToEnglishDate();
            DateTime? endDate = nependDate.ToEnglishDate();
            vm.BillingList = new List<Billing>();
            var billing = await _repo.GetAllBillingAsync();
            vm.BillingList = billing;
            vm.Clients = await _clientRepo.GetAllClientAsync();
            if (string.IsNullOrEmpty(vm.FromMiti) && string.IsNullOrEmpty(vm.ToMiti))
            {
                vm.FromDate = startDate;
                vm.ToDate = endDate;
                vm.BillingList = vm.BillingList.Where(x => x.DueDate >= vm.FromDate && x.DueDate < vm.ToDate).ToList();
            }
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

            var billingDetailList = await _bDetailRepo.GetAllBillingAsync();
            vm.BillingDetailList = billingDetailList;
            ViewBag.Message = message;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            BillingDto dto = new BillingDto();
            dto.Clients = await _clientRepo.GetAllClientAsync();
            dto.Blocks = await _blockRepo.GetAllBlockAsync();
            dto.Rooms = await _roomRepo.GetAllRoomAsync();
            dto.Months = await _monthRepo.GetAllMonthAsync();
            dto.Years = await _yearRepo.GetAllYearAsync();
            var electricityUnit  = await _eRepo.GetAllElectricityAsync();
            ViewBag.Rate = electricityUnit.Where(x => x.IsActive()).FirstOrDefault().Charge;
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(BillingDto dto)
        {
            //using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            //{
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (dto.IsRent == true)
                        {
                            dto.ElectricityFineAmount = "0";
                        }
                        if (dto.IsElectricity == true)
                        {
                            dto.Fine = "0";
                        }
                        var billing = await _repo.GetAllBillingAsync();
                        int count=1;
                        foreach (var item in billing)
                        {
                            count++;
                        }
                        dto.BillNo = count.ToString();
                        if (dto.IsDue == false)
                        {
                            dto.DueAmount = (dto.BillingAmount.ToDecimal()).ToString();
                        }
                        await _service.InsertAsync(dto);
                        if (dto.billingDetailDtos != null)
                        {
                            foreach (var item in dto.billingDetailDtos)
                            {
                                item.BillingId = dto.Id;
                                item.YearId = (long?)dto.YearId;
                                if (dto.IsRent == true)
                                {
                                    item.ElectricityUnit = "0";
                                    item.ElectricityBillAmount = "0";

                                }
                                if (dto.IsElectricity == true)
                                {
                                    item.RentAmount = "0";
                                }

                                await _bDetailService.InsertAsync(item);
                            }
                        }
                       // await tran.CommitAsync();
                        return RedirectToAction("BillPrint", "Billing", new { id = dto.Id, message = "Billing has been saved successfully." });
                    }
                    else
                    {
                        ViewBag.Message = "Error: Invalid Data !";
                    }
                }
                catch (Exception ex)
                {
                   // await tran.RollbackAsync();
                    ViewBag.Message = "Error: Please contact System Administrator.";
                }
            //}
            return View(dto);
        }
        [HttpGet()]
        public async Task<IActionResult> Update(long id)
        {
            var billing = await _repo.GetByIdAsync(id);
            var billingDetailList = await _bDetailRepo.GetAllBillingAsync();
            var billingDetail = billingDetailList.Where(x=>x.BillingId==billing.Id).ToList();
            BillingDto dto = new BillingDto()
            {
                ClientId = billing.ClientId,
                //BlockId= billing.BlockId,
                //RoomId= billing.RoomId,
                YearId = billing.YearId,
                DueAmount = billing.DueAmount,
                DueDate = billing.DueDate.ToNepDate(),
                BillingAmount = billing.BillingAmount,
                GrandTotal = billing.GrandTotal,
                Fine = billing.Fine,
                ElectricityFineAmount = billing.ElectricityFineAmount,
                Discount = billing.Discount,
                MaintenanceCharge = billing.MaintenanceCharge,
                DuePaid = billing.DuePaid,
                DebitTotal = billing.DebitTotal,
                CreditTotal = billing.CreditTotal,
                CreatedDate = billing.CreatedDate,
                CreatedBy=billing.CreatedBy,
                CashReceived = billing.CashReceived,
                IsElectricity= billing.IsElectricity,
                IsRent = billing.IsRent,
                IsDue=billing.IsDue,
            };
            var electricityUnit  = await _eRepo.GetAllElectricityAsync();
            ViewBag.Rate = electricityUnit.Where(x => x.IsActive()).FirstOrDefault().Charge;

            List<BillingDetailDto> list = new List<BillingDetailDto>();
            foreach (var info in billingDetail)
            {
                BillingDetailDto info_dto = new BillingDetailDto();
                _bDetailAssembler.copyFrom(info_dto, info);
                info_dto.YearId = dto.YearId;
                list.Add(info_dto);
            }
            dto.billingDetailDtos = list;
            dto.Clients = await _clientRepo.GetAllClientAsync();
            dto.Blocks = await _blockRepo.GetAllBlockAsync();
            dto.Rooms = await _roomRepo.GetAllRoomAsync();
            dto.Months = await _monthRepo.GetAllMonthAsync();
            dto.Years = await _yearRepo.GetAllYearAsync();
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(BillingDto dto)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        //if (dto.IsRent == true)
                        //{
                        //    dto.ElectricityFineAmount = "0";
                        //}
                        //if (dto.IsElectricity == true)
                        //{
                        //    dto.Fine = "0";
                        //}
                        await _service.UpdateAsync(dto);
                        foreach (var item in dto.billingDetailDtos)
                        {
                            //if (dto.IsRent == true)
                            //{
                            //    item.ElectricityUnit = "0";
                            //    item.ElectricityBillAmount = "0";
                            //}
                            //if (dto.IsElectricity == true)
                            //{
                            //    item.RentAmount = "0";
                            //}
                            await _bDetailService.UpdateAsync(item);
                        }
                        await tran.CommitAsync();
                        return RedirectToAction("BillPrint", "Billing", new { id = dto.Id, message = "Billing has been saved successfully." });

                    }
                    else
                    {
                        ViewBag.Message = "Error: Invalid Data !";
                    }
                }
                catch (Exception ex)
                {
                    await tran.RollbackAsync();
                    ViewBag.Message = "Error: Please contact System Administrator.";
                }
            }
            return View(dto);
        }
        public async Task<ActionResult> BillPrint(long id, string message)
        {
            BillingViewModel vm = new BillingViewModel();

            vm.BillingList = await _repo.GetAllBillingAsync();
            vm.BillingList = vm.BillingList.Where(x => x.Id == id).ToList();
            vm.BillingDetailList = new List<BillingDetail>();
            if (vm.BillingList != null)
            {
                var billinginfo = await _bDetailRepo.GetAllBillingAsync();
                var billinginfos = billinginfo.Where(x => x.BillingId == id).ToList();
                vm.BillingDetailList = billinginfos;
            }
            ViewBag.Message = message;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> BillPayment()
        {
            BillingDto dto = new BillingDto();
            dto.Clients = await _clientRepo.GetAllClientAsync();
            dto.Blocks = await _blockRepo.GetAllBlockAsync();
            dto.Rooms = await _roomRepo.GetAllRoomAsync();
            dto.Months = await _monthRepo.GetAllMonthAsync();
            dto.Years = await _yearRepo.GetAllYearAsync();

            return View(dto);
        }
        //public async Task<JsonResult> GetBillingDetail(long id, long blockId, long roomId, string dueDate, string dueAmount, [FromServices] ICompositeViewEngine viewEngine)
        //{
        //    var _result = new ResponseData();
        //    try
        //    {
        //        var billingList = await _repo.GetAllBillingAsync();
        //        var billing = billingList.Where(x=>x.IsPaid==false && x.ClientId==id && x.BlockId==blockId && x.RoomId== roomId).FirstOrDefault();
        //        if (billing != null)
        //        {
        //            var billingDetailList = await _bDetailRepo.GetAllBillingAsync();
        //            var billingDetail = billingDetailList.Where(x=>x.BillingId==billing.Id).ToList();

        //            if (billingDetail != null)
        //            {

        //                BillingDto dto = new BillingDto();
        //                dto.billingDetails = billingDetail;
        //                dto.Id = billing.Id;
        //                dto.billing = billing;
        //                dto.Months = await _monthRepo.GetAllMonthAsync();
        //                dto.Years = await _yearRepo.GetAllYearAsync();
        //                dto.ClientId = id;
        //                dto.BlockId = blockId;
        //                dto.RoomId = roomId;
        //                dto.DueAmount = billing.DueAmount;
        //                dto.DueDate = billing.DueDate.ToNepDate();
        //                string dtResult = await RenderPartialView("_billingDetails",viewEngine, dto);
        //                _result.Success = true;
        //                _result.Message = dtResult;

        //            }
        //            else
        //            {
        //                _result.Message = "No bill for payment.";
        //            }
        //        }
        //        else
        //        {
        //            _result.Message = "No bill records for payment found.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _result.Success = false;
        //        _result.Message = ex.Message;
        //    }

        //    return Json(_result);
        //}

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> UpdateBilling(BillingDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateFromBillPaymentAsync(dto);
                    return RedirectToAction("BillPaymentPrint", "Billing", new { id = dto.Id, message = "Billing has been saved successfully." });

                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> GenerateBill()
        {
            BillingDto dto = new BillingDto();
            dto.Clients = await _clientRepo.GetAllClientAsync();
            dto.Blocks = await _blockRepo.GetAllBlockAsync();
            dto.Rooms = await _roomRepo.GetAllRoomAsync();
            dto.Months = await _monthRepo.GetAllMonthAsync();
            dto.Years = await _yearRepo.GetAllYearAsync();
            dto.ClientsList = await _clientRepo.GetAllClientAsync();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> GenerateBill(BillingDto dto)
        {
            dto.Clients = await _clientRepo.GetAllClientAsync();
            dto.Blocks = await _blockRepo.GetAllBlockAsync();
            dto.Rooms = await _roomRepo.GetAllRoomAsync();
            dto.Months = await _monthRepo.GetAllMonthAsync();
            dto.Years = await _yearRepo.GetAllYearAsync();
            dto.ClientsList = await _clientRepo.GetAllClientAsync();
            if (dto.ClientId > 0)
            {
                dto.ClientsList = dto.ClientsList.Where(x => x.Id == dto.ClientId).ToList();
            }
            //if (dto.BlockId > 0)
            //{
            //    dto.ClientsList = dto.ClientsList.Where(x => x.BlockId == dto.BlockId).ToList();
            //}
            //if (dto.RoomId > 0)
            //{
            //    dto.ClientsList = dto.ClientsList.Where(x => x.RoomId == dto.RoomId).ToList();
            //}
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Bill(string id)
        {
            ViewBag.ClientId = id.Split("-")[0].Trim();
            ViewBag.BlockId = id.Split("-")[1].Trim();
            ViewBag.RoomId = id.Split("-")[2].Trim();
            //var electricity = await _eSetupRepo.GetAllElectricityUnitSetupAsync();
            //ViewBag.Electricity = electricity;
          
            return View();
        }
        protected async Task<string> RenderPartialView(string viewName, ICompositeViewEngine _viewEngine, object model = null)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult = _viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }
        //public async Task<JsonResult> LoadBilling(long id, long blockId, long roomId)
        //{
        //    var billingList = await _repo.GetAllBillingAsync();
        //    var billing = billingList.Where(x=>x.IsPaid==false && x.ClientId==id && x.BlockId== blockId && x.RoomId==roomId).FirstOrDefault();
        //    List<string> list = new List<string>();
        //    if (billing != null)
        //    {
        //        list.Add(billing.DueAmount);
        //        list.Add(billing.DueDate.ToNepDate());
        //        return Json(list);
        //    }
        //    else
        //    {
        //        return Json("");
        //    }

        //}
        public async Task<JsonResult> LoadFine(string dueDate)
        {
            DateTime? _dueDate = dueDate.ToEnglishDate();
            DateTime? _currentDate = DateTime.Now;
            var days = (_currentDate - _dueDate).Value.Days;
            var _fine= await _fineRepo.GetAllFineSetupAsync();
            decimal? _finePercent=0;
            foreach (var item in _fine)
            {
                if (days.ToDecimal() >= item.StartDay.ToDecimal() && days.ToDecimal() <= item.EndDay.ToDecimal())
                {
                    _finePercent = item.FinePercent.ToDecimal();
                }
            }
            return Json(_finePercent);
        }
        public async Task<JsonResult> LoadFineOnly(long yearId, long monthId)
        {
            var months = await _monthRepo.GetAllMonthAsync();
            var month = months.Where(x=>x.Id==monthId).FirstOrDefault();
            var Years = await _yearRepo.GetAllYearAsync();
            var year = Years.Where(x=>x.Id==yearId).FirstOrDefault();

            string _nepDate = year.YearName+"/"+ month.MonthOrder + "/" + "1";

            DateTime? _dueDate = _nepDate.ToEnglishDate();
            DateTime? _currentDate = DateTime.Now;
            var days = (_currentDate - _dueDate).Value.Days;
            var _fine= await _fineRepo.GetAllFineSetupAsync();
            decimal? _finePercent=0;
            foreach (var item in _fine)
            {
                if (days.ToDecimal() >= item.StartDay.ToDecimal() && days.ToDecimal() <= item.EndDay.ToDecimal())
                {
                    _finePercent = item.FinePercent.ToDecimal();
                }
            }
            return Json(_finePercent);
        }

        public async Task<JsonResult> LoadMaintenanceCharge(long yearId, long monthId, long clientId)
        {
            var months = await _monthRepo.GetAllMonthAsync();
            var month = months.Where(x=>x.Id==monthId).FirstOrDefault();
            var Years = await _yearRepo.GetAllYearAsync();
            var year = Years.Where(x=>x.Id==yearId).FirstOrDefault();

            var clientRoomMaintenanceList = await _clientRoomMaintenanceRepo.GetAllClientRoomMaintenanceAsync();
            var clientRoomMaintenance = clientRoomMaintenanceList.Where(x=>x.ClientId == clientId && x.MonthId == monthId && x.YearId == yearId).ToList();
            decimal? _charge = 0;
            foreach (var item in clientRoomMaintenance)
            {
                _charge += item.MaintenanceCharge.ToDecimal();
            }
            return Json(_charge);
        }
        public async Task<JsonResult> LoadElectricityFineOnly(long yearId, long monthId)
        {
            var months = await _monthRepo.GetAllMonthAsync();
            var month = months.Where(x=>x.Id==monthId).FirstOrDefault();
            var Years = await _yearRepo.GetAllYearAsync();
            var year = Years.Where(x=>x.Id==yearId).FirstOrDefault();

            string _nepDate = year.YearName+"/"+ month.MonthOrder + "/" + "1";

            DateTime? _dueDate = _nepDate.ToEnglishDate();
            DateTime? _currentDate = DateTime.Now;
            var days = (_currentDate - _dueDate).Value.Days;
            var _fine= await _eFineSetupRepo.GetAllFineSetupAsync();
            decimal? _finePercent=0;
            foreach (var item in _fine)
            {
                if (days.ToDecimal() >= item.StartDay.ToDecimal() && days.ToDecimal() <= item.EndDay.ToDecimal())
                {
                    _finePercent = item.FinePercent.ToDecimal();
                }
            }
            return Json(_finePercent);
        }



        public async Task<ActionResult> BillPaymentPrint(long id, string message)
        {
            BillingViewModel vm = new BillingViewModel();

            vm.BillingList = await _repo.GetAllBillingAsync();
            vm.BillingList = vm.BillingList.Where(x => x.Id == id).ToList();
            vm.BillingDetailList = new List<BillingDetail>();
            if (vm.BillingList != null)
            {
                var billinginfo = await _bDetailRepo.GetAllBillingAsync();
                var billinginfos = billinginfo.Where(x => x.BillingId == id).ToList();
                vm.BillingDetailList = billinginfos;
            }
            ViewBag.Message = message;
            return View(vm);
        }
        public async Task<JsonResult> LoadRoomRent(long id)
        {
            var rent = await _roomRepo.GetByIdAsync(id);
            return Json(rent.MonthlyAmount);
        }
        #region From Pawan
        public async Task<JsonResult> LoadFiscalYear()
        {
            var year = DateTime.Now.ToDateTime().ToNepDate();
            string[] y = year.Split("-");
            var yearList = await _yearRepo.GetAllYearAsync();
            var id = yearList.Where(x => x.YearName == y[0].ToString()).FirstOrDefault().Id;
            return Json(id);
        }
        public async Task<JsonResult> LoadRentFine(long id)
        {
            var clientList = await _clientRepo.GetAllClientAsync();
            var client = clientList.Where(x => x.Id == id).FirstOrDefault();
            if (client==null)
            {
                return Json("0");
            }
            else
            {
                return Json(client.RentDue);
            }
        }
        public async Task<JsonResult> LoadElectricityFine(long id)
        {
            var clientList = await _clientRepo.GetAllClientAsync();
            var client = clientList.Where(x => x.Id == id).FirstOrDefault();
            if (client == null)
            {
                return Json("0");
            }
            else
            {
                return Json(client.ElectricityDue);
            }
        }

        //public async Task<ActionResult> ExportToExcel()
        //{
        //    var billing = await _repo.GetAllBillingAsync();
        //    var billingDetail = await _bDetailRepo.GetAllBillingAsync();
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //    ExcelPackage pck = new ExcelPackage();

        //    using (var package = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
        //    {

        //    }
        //    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
        //    ws.TabColor = System.Drawing.Color.Black;

        //    ws.Cells["A1"].Value = "PARICHAYA AWAS BIKASH PVT. LTD.";

        //    ws.Cells["A3"].Value = "Billing Report";

        //    ws.Cells["A6"].Value = "Year/Mont/Day";
        //    ws.Cells["B6"].Value = "Client";
        //    ws.Cells["C6"].Value = "Blook";
        //    ws.Cells["D6"].Value = "Room";
        //    ws.Cells["E6"].Value = "Total";
        //    ws.Cells["F6"].Value = "Cash Received";
        //    ws.Cells["G6"].Value = "Due Paid";

        //    ws.Row(6).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //    ws.Row(6).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#228b22")));
        //    int rowStart = 7;
        //    foreach (var item in billing)
        //    {
        //        ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //        ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#F7F4F3")));

        //        foreach (var detail in billingDetail.Where(x => x.BillingId == item.Id).ToList())
        //        {
        //            //if (detail.YearId != null && detail.MonthId != null)
        //            //{
        //            //    string date = item.DueDate.ToNepDate();
        //            //    string day = date.Split("-")[2];
        //            //    var year = await _yearRepo.GetByIdAsync((long)detail.YearId);

        //            //    var month = await _monthRepo.GetByIdAsync((long)detail.MonthId);
        //            //    var YearMonth = string.Format("{0}/{1}/{2}", year.YearName, month.MonthName, day);
        //            //    ws.Cells[string.Format("A{0}", rowStart)].Value = YearMonth;
        //            //}
        //            if (item.ClientId != null)
        //            {
        //                var clients = await _clientRepo.GetAllClientAsync();
        //                var client = clients.Where(x => x.Id == item.ClientId).FirstOrDefault().OwnerName;
        //                ws.Cells[string.Format("B{0}", rowStart)].Value = client;
        //            }
        //            if (detail.BlockId != null)
        //            {
        //                var blocks = await _blockRepo.GetAllBlockAsync();
        //                var block = blocks.Where(x => x.Id == detail.BlockId).FirstOrDefault().Name;
        //                ws.Cells[string.Format("C{0}", rowStart)].Value = block;
        //            }
        //            if (detail.RoomId != null)
        //            {
        //                var rooms = await _roomRepo.GetAllRoomAsync();
        //                var room = rooms.Where(x => x.Id == detail.RoomId).FirstOrDefault().Name;
        //                ws.Cells[string.Format("D{0}", rowStart)].Value = room;
        //            }
        //            ws.Cells[string.Format("E{0}", rowStart)].Value = item.GrandTotal;
        //            ws.Cells[string.Format("F{0}", rowStart)].Value = item.CashReceived;
        //            ws.Cells[string.Format("G{0}", rowStart)].Value = item.DuePaid;

        //            rowStart++;
        //        }

        //    }
        //    ws.Cells["A:AZ"].AutoFitColumns();

        //    Response.Clear();

        //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    Response.Headers.Add("content-disposition", "attachment; filename=" + "BranchExcelReport.xlsx");
        //    Response.Body.Write(pck.GetAsByteArray());
        //    var syncIOFeature = HttpContext.Features.Get<IHttpBodyControlFeature>();
        //    if (syncIOFeature != null)
        //    {
        //        syncIOFeature.AllowSynchronousIO = true;
        //    }
        //    Response.StatusCode = StatusCodes.Status200OK;
        //    //Response.End();
        //    return View();
        //}

        #endregion
        public async Task<JsonResult> LoadDueAmount(long id)
        {
            string due="0";
            decimal total =0;
            decimal crTotal =0;
            var billingList = await _repo.GetAllBillingAsync();
            var billing = billingList.Where(x=>x.ClientId == id).ToList();

            if (billing.Count > 0)
            {
                foreach (var item in billing)
                {
                    total += item.GrandTotal.ToDecimal() + item.ElectricityFineAmount.ToDecimal() + item.Fine.ToDecimal() - item.Discount.ToDecimal() + item.MaintenanceCharge.ToDecimal();
                    crTotal += item.CashReceived.ToDecimal() + item.DuePaid.ToDecimal();
                }
                due = (crTotal - total).ToString();
                return Json(due);
            }
            else
            {
                var clientList = await _clientRepo.GetAllClientAsync();
                var client = clientList.Where(x=>x.Id == id).FirstOrDefault();
                due = "-" + (client.RentDue.ToDecimal() + client.ElectricityDue.ToDecimal()).ToString();
                return Json(due);
            }
        }

        //public async Task<JsonResult> LoadIsDueAmount(long id)
        //{

        //}
        public async Task<JsonResult> LoadUnit()
        {
            var unitList = await _eRepo.GetAllElectricityAsync();
            var unit = unitList.Where(x=>x.IsActive()).FirstOrDefault();
            return Json(unit.Charge);
        }
        public async Task<JsonResult> LoadRoomUnit(string monthId, string yearId, string roomId)
        {
            var electricitySetup = await _eSetupRepo.GetAllElectricityUnitSetupAsync();
            var _eSetup = electricitySetup.Where(x=>x.MonthId == long.Parse(monthId) && x.YearId== long.Parse(yearId) && x.RoomId== long.Parse(roomId)).FirstOrDefault();
            if (_eSetup == null)
            {
                return Json("0");
            }
            else
            {
                return Json(_eSetup.Unit);
            }
        }
        public async Task<JsonResult> LoadRoomBlock(long Id)
        {
            var blockList = await _clientBlockSetupRepo.GetAllClientBlockRoomSetupAsync();
            var block = blockList.Where(x=>x.ClientId==Id).ToList();
            List<Block> list = new List<Block>();
            foreach (var item in block)
            {
                var _tempBlock = await _blockRepo.GetByIdAsync((long)item.BlockId);
                list.Add(new Block { Id =(long)item.BlockId, Name = _tempBlock.Name });
            }
            return Json(list);
        }
        public async Task<JsonResult> LoadRoom(long Id, long blockId)
        {
            var roomList = await _clientBlockSetupRepo.GetAllClientBlockRoomSetupAsync();
            var room = roomList.Where(x=>x.ClientId==Id).ToList();
            if (blockId > 0)
            {
                room = room.Where(x => x.BlockId == blockId).ToList();
            }

            List<Room> list = new List<Room>();
            foreach (var item in room)
            {
                if (item.RoomId.Contains(","))
                {
                    string[] _temp = item.RoomId.Split(",");
                    foreach (var id in _temp)
                    {
                        var _tempRoom = await _roomRepo.GetByIdAsync(long.Parse(id));
                        list.Add(new Room { Id = long.Parse(id), Name = _tempRoom.Name, MonthlyAmount = _tempRoom.MonthlyAmount });
                    }
                }
                else
                {
                    var _tempRoom = await _roomRepo.GetByIdAsync(long.Parse(item.RoomId));
                    list.Add(new Room { Id = long.Parse(item.RoomId), Name = _tempRoom.Name, MonthlyAmount = _tempRoom.MonthlyAmount });
                }
            }
            return Json(list);
        }
        public async Task<JsonResult> getRoomDetail(long Id)
        {
            var roomList = await _clientBlockSetupRepo.GetAllClientBlockRoomSetupAsync();
            var room = roomList.Where(x=>x.ClientId==Id).ToList();

            List<Room> list = new List<Room>();
            foreach (var item in room)
            {
                if (item.RoomId.Contains(","))
                {
                    string[] _temp = item.RoomId.Split(",");
                    foreach (var id in _temp)
                    {
                        var _tempRoom = await _roomRepo.GetByIdAsync(long.Parse(id));
                        list.Add(new Room { Id = long.Parse(id), Name = _tempRoom.Name, MonthlyAmount = _tempRoom.MonthlyAmount });
                    }
                }
                else
                {
                    var _tempRoom = await _roomRepo.GetByIdAsync(long.Parse(item.RoomId));
                    list.Add(new Room { Id = long.Parse(item.RoomId), Name = _tempRoom.Name, MonthlyAmount = _tempRoom.MonthlyAmount });
                }
            }
            return Json(list);
        }

        public async Task<JsonResult> getMaintenanceCharge(long Id)
        {
            var roomList = await _clientRoomMaintenanceRepo.GetAllClientRoomMaintenanceAsync();
            var room = roomList.Where(x=>x.ClientId==Id).ToList();

            List<ClientRoomMaintenance> list = new List<ClientRoomMaintenance>();
            foreach (var item in room)
            {
                list.Add(new ClientRoomMaintenance { MaintenanceCharge = item.MaintenanceCharge });
            }
            return Json(list);
        }
      
    }
}
