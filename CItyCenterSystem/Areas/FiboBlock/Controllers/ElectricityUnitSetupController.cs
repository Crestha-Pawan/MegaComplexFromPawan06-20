using FiboBilling.Src.Dto;
using FiboBlock.InfraStructure.Assembler;
using FiboBlock.InfraStructure.Repository;
using FiboBlock.InfraStructure.Service;
using FiboBlock.Src.Dto;
using FiboBlock.Src.ViewModel;
using FiboInfraStructure.Data;
using FiboInfraStructure.Entity.FiboBlock;
using FiboOffice.InfraStructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem.Areas.FiboBlock.Controllers
{
    public class ElectricityUnitSetupController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IElectricityUnitSetupService _service;
        private readonly IElectricityUnitSetupRepository _repo;
        private readonly IElectricityUnitSetupAssembler _assembler;
        private readonly IYearRepository _yearRepo;
        private readonly IMonthRepository _monthRepo;
        private readonly IClientRepository _clientRepo;
        private readonly IBlockRepository _blockRepo;
        private readonly IRoomRepository _roomRepo;
        private readonly IElectricityRepository _eRepo;
        public ElectricityUnitSetupController(
             IElectricityUnitSetupAssembler assembler
            , IElectricityUnitSetupRepository repo
            , IElectricityUnitSetupService service
            , IYearRepository yearRepo
            , IMonthRepository monthRepo
            , IClientRepository clientRepo
            , IBlockRepository blockRepo
            , IRoomRepository roomRepo
            , IElectricityRepository eRepo
            , ApplicationDbContext context
            )

        {
            _repo = repo;
            _assembler = assembler;
            _service = service;
            _yearRepo = yearRepo;
            _monthRepo = monthRepo;
            _clientRepo = clientRepo;
            _blockRepo = blockRepo;
            _roomRepo = roomRepo;
            _eRepo = eRepo;
            _context = context;
        }
        public async Task<IActionResult> Index(ElectricityUnitSetupViewModel vm, string message)
        {
            vm.Electricities = new List<ElectricityUnitSetup>();
            var electricity = await _repo.GetAllElectricityUnitSetupAsync();
            vm.Electricities = electricity;
            vm.Blocks = await _blockRepo.GetAllBlockAsync();
            vm.ClientList = await _clientRepo.GetAllClientAsync();

            if (vm.BlockId > 0)
            {
                vm.Electricities = vm.Electricities.Where(x => x.BlockId == vm.BlockId).ToList();
            }
            if (vm.ClientId > 0)
            {
                vm.Electricities = vm.Electricities.Where(x => x.ClientId == vm.ClientId).ToList();
            }
            ViewBag.Message = message;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ElectricityUnitSetupDto dto = new ElectricityUnitSetupDto();
            dto.Clients = await _clientRepo.GetAllClientAsync();
            dto.Blocks = await _blockRepo.GetAllBlockAsync();
            dto.Rooms = await _roomRepo.GetAllRoomAsync();
            dto.Years = await _yearRepo.GetAllYearAsync();
            dto.Months = await _monthRepo.GetAllMonthAsync();
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(ElectricityUnitSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in dto.ElectricityDtos)
                    {
                        item.YearId = dto.YearId;
                        item.MonthId = dto.MonthId;
                        await _service.Insertasync(item);
                    }
                    return RedirectToAction("Index", "ElectricityUnitSetup", new { message = "Electricity has been saved successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid data !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(dto);
        }
        public async Task<ActionResult> MonthlyReport(long id, string actionName)
        {
            ElectricityUnitSetupViewModel vm = new ElectricityUnitSetupViewModel()
            {
                MonthList = await _monthRepo.GetAllMonthAsync(),
                Years = await _yearRepo.GetAllYearAsync()
            };

            vm.ElectricityUnitSetupId = id;
            return View(vm);
        }
        [HttpGet]
        public async Task<ActionResult> ElectricityReport(string id)
        {

            string yearId = id.Split("-")[0].Trim();
            long lYearId = long.Parse(yearId);
            string monthNo = id.Split("-")[1].Trim();
            var monthList = await _monthRepo.GetAllMonthAsync();
            var month = monthList.Where(x => x.MonthOrder == monthNo).FirstOrDefault();

            ElectricityUnitSetupViewModel vm = new ElectricityUnitSetupViewModel();
            var electricities = await _repo.GetAllElectricityUnitSetupAsync();
            electricities = electricities.Where(x => x.YearId == lYearId && x.MonthId == month.Id).ToList();
            vm.ElectricitiesList = electricities;
            vm.YearId = lYearId;
            vm.MonthId = month.Id;
            vm.ClientList = await _clientRepo.GetAllClientAsync();
            return View(vm);
        }
        [HttpPost]
        public async Task<ActionResult> ElectricityReport(ElectricityUnitSetupViewModel vm)
        {
            var electricities = await _repo.GetAllElectricityUnitSetupAsync();
            electricities = electricities.Where(x => x.YearId == vm.YearId && x.MonthId == vm.MonthId).ToList();
            vm.ElectricitiesList = electricities;
            vm.ClientList = await _clientRepo.GetAllClientAsync();

            if (vm.ClientId > 0)
            {
                vm.ElectricitiesList = vm.ElectricitiesList.Where(x => x.ClientId == vm.ClientId).ToList();
            }
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Update(long id)
        {
            var electricy = await _repo.GetByIdAsync(id);
            var electricitylist = await _repo.GetAllElectricityUnitSetupAsync();
            var electricdetails = electricitylist.Where(x => x.Id == electricy.Id).ToList();
            ElectricityUnitSetupDto dto = new ElectricityUnitSetupDto()
            {
                ClientId = electricy.ClientId,
                BlockId = electricy.BlockId,
                RoomId = electricy.RoomId,
                CreatedDate = electricy.CreatedDate,
                CreatedBy = electricy.CreatedBy,
            };
            List<ElectricityUnitSetupDto> list = new List<ElectricityUnitSetupDto>();
            foreach (var info in electricdetails)
            {
                ElectricityUnitSetupDto info_dto = new ElectricityUnitSetupDto();
                _assembler.copyFrom(info_dto, info);
                list.Add(info_dto);
            }
            dto.ElectricityDtos = list;
            dto.Clients = await _clientRepo.GetAllClientAsync();
            dto.Blocks = await _blockRepo.GetAllBlockAsync();
            dto.Rooms = await _roomRepo.GetAllRoomAsync();
            dto.Months = await _monthRepo.GetAllMonthAsync();
            dto.Years = await _yearRepo.GetAllYearAsync();
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(ElectricityUnitSetupDto dto)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        foreach (var item in dto.ElectricityDtos)
                        {
                            await _service.UpdateAsync(item);

                        }

                        await tran.CommitAsync();
                        return RedirectToAction("Index", "ElectricityUnitSetup", new { id = dto.Id, message = "ElectricityUnitSetup has been update successfully." });
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
        public async Task<JsonResult> LoadUnit()
        {
            var unitList = await _eRepo.GetAllElectricityAsync();
            var unit = unitList.Where(x => x.IsActive()).FirstOrDefault();
            return Json(unit.Charge);
        }

        public async Task<ActionResult> ExportToExcel(long monthId, long yearId)
        {
           
            var electricity = await _repo.GetAllElectricityUnitSetupAsync();
            electricity = electricity.Where(x => x.YearId == yearId && x.MonthId == monthId).ToList();
            //if (vm.ClientId > 0)
            //{
            //    electricity = electricity.Where(x => x.ClientId == vm.ClientId).ToList();
            //}
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage pck = new ExcelPackage();

            using (var package = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
            {

            }
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.TabColor = System.Drawing.Color.Black;

            ws.Cells["A1"].Value = "PARICHAYA AWAS BIKASH PVT. LTD.";

            ws.Cells["A3"].Value = "Electricity Report";

            ws.Cells["A6"].Value = "Client Name";
            ws.Cells["B6"].Value = "Blook";
            ws.Cells["C6"].Value = "Room";
            ws.Cells["D6"].Value = "Previous Unit";
            ws.Cells["E6"].Value = "Current Unit";
            ws.Cells["F6"].Value = "Consumed Unit";
            ws.Cells["G6"].Value = "Rate";
            ws.Cells["H6"].Value = "Amount";

            ws.Row(6).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Row(6).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#228b22")));
            int rowStart = 7;
                foreach (var item in electricity)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#F7F4F3")));

                //if (detail.YearId != null && detail.MonthId != null)
                //{
                //    string date = item.DueDate.ToNepDate();
                //    string day = date.Split("-")[2];
                //    var year = await _yearRepo.GetByIdAsync((long)detail.YearId);

                //    var month = await _monthRepo.GetByIdAsync((long)detail.MonthId);
                //    var YearMonth = string.Format("{0}/{1}/{2}", year.YearName, month.MonthName, day);
                //    ws.Cells[string.Format("A{0}", rowStart)].Value = YearMonth;
                //}
                if (item.ClientId != null)
                {
                    var client = await _clientRepo.GetAllClientAsync();
                    var clients = client.Where(x => x.Id == item.ClientId).FirstOrDefault().OwnerName;
                    ws.Cells[string.Format("A{0}", rowStart)].Value = clients;
                }
                if (item.BlockId != null)
                    {
                        var blocks = await _blockRepo.GetAllBlockAsync();
                        var block = blocks.Where(x => x.Id == item.BlockId).FirstOrDefault().Name;
                        ws.Cells[string.Format("B{0}", rowStart)].Value = block;
                    }
                    if (item.RoomId != null)
                    {
                        var rooms = await _roomRepo.GetAllRoomAsync();
                        var room = rooms.Where(x => x.Id == item.RoomId).FirstOrDefault().Name;
                        ws.Cells[string.Format("C{0}", rowStart)].Value = room;
                    }
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.PreviousUnit;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.CurrentUnit;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.Unit;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.Rate;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.Amount;

                    rowStart++;
                }
            ws.Cells["A:AZ"].AutoFitColumns();

            Response.Clear();

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment; filename=" + "ElectricityReportExcelReport.xlsx");
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