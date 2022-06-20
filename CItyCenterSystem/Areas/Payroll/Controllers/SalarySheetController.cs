using FiboInfraStructure;
using FiboInfraStructure.Entity.Payroll;
using FiboOffice.InfraStructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Payroll.InfraStructure.Assembler;
using Payroll.InfraStructure.Repository;
using Payroll.InfraStructure.Service;
using Payroll.Src.Dto;
using Payroll.Src.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem.Areas.Payroll.Controllers
{
    public class SalarySheetController : Controller
    {
        private readonly ISalarySheetService _salarySheetService;
        private readonly ISalarySheetRepository _salarySheetRepository;
        private readonly ISalarySheetAssembler _salarySheetAssembler;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPostRepository _postRepository;
        private readonly IYearRepository _yearRepo;
        private readonly IMonthRepository _monthRepo;
        public SalarySheetController(ISalarySheetService salarySheetService
            , ISalarySheetRepository salarySheetRepository
            , ISalarySheetAssembler salarySheetAssembler
            , IEmployeeRepository employeeRepository
            , IPostRepository postRepository
            , IYearRepository yearRepo
            , IMonthRepository monthRepo)
        {
            _salarySheetRepository = salarySheetRepository;
            _salarySheetService = salarySheetService;
            _salarySheetAssembler = salarySheetAssembler;
            _employeeRepository = employeeRepository;
            _postRepository = postRepository;
            _yearRepo = yearRepo;
            _monthRepo = monthRepo;
        }
        public async Task<IActionResult> Index(SalarySheetViewModel vm,string message,string messege)
        {
            vm.SalarySheets = new List<SalarySheet>();
            var salarySheets = await _salarySheetRepository.GetAllSalarySheetAsync();
            vm.SalarySheets = salarySheets;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        public async Task<ActionResult> MonthlyReport(long id, string actionName)
        {
            SalarySheetViewModel vm = new SalarySheetViewModel()
            {
                MonthList = await _monthRepo.GetAllMonthAsync(),
                Years = await _yearRepo.GetAllYearAsync()
            };

            vm.EmployeeId = id;
            vm.ActionName = actionName;
            return View(vm);
        }
        public async Task<IActionResult> SalarySheetReport(SalarySheetViewModel vm)
        {
            //vm.SalarySheets = new List<SalarySheet>();

            //var salarysheet = await _salarySheetRepository.GetAllSalarySheetAsync();
            vm.Employees = await _employeeRepository.GetAllEmployeeAsync();
            //vm.Employeee = await _employeeRepository.GetAllEmployeeAsync();
            

            //vm.SalarySheets = salarysheet;
            //return View(vm);
            var salary = await _salarySheetRepository.GetAllSalarySheetAsync();

            var employee = await _employeeRepository.GetAllEmployeeAsync();


            var query = (from b in employee
                         join bl in salary on b.Id equals bl.EmployeeId
                         into q
                         select b).ToList();

            List<SalarySheetViewModel> salarySheetList = query.GroupBy(l => new { l.Id, l.Name }).Select(cl => new SalarySheetViewModel
            {
                EmployeeId = (long)cl.Key.Id,
                EmployeeName = cl.Key.Name
            }).ToList();
            if (vm.EmployeeId > 0)
            {
                salarySheetList = salarySheetList.Where(x => x.EmployeeId == vm.EmployeeId).ToList();
            }
            vm.SalarySheetVMList = salarySheetList;
            return View(vm);
        }
        public async Task<IActionResult> Report(string id)
        {
            long? employeeId = long.Parse(id.Split("-")[0].Trim());
            string yearId = id.Split("-")[1].Trim();
            long lYearId = long.Parse(yearId);
            string monthNo = id.Split("-")[2].Trim();
            var yearRepo = await _yearRepo.GetByIdAsync(lYearId);
            string nepstartDate = string.Empty;
            string nependDate = string.Empty;
            if (monthNo == "12")
            {
                nepstartDate = yearRepo.YearName + "/" + monthNo + "/" + "1";
                nependDate = (Convert.ToDecimal(yearRepo.YearName) + Convert.ToDecimal(1)).ToString() + "/" + "1" + "/" + "1";
            }
            else
            {
                nepstartDate = yearRepo.YearName + "/" + monthNo + "/" + "1";
                nependDate = yearRepo.YearName + "/" + (Convert.ToDecimal(monthNo) + Convert.ToDecimal(1)).ToString() + "/" + "1";
            }
            DateTime? startDate = nepstartDate.ToEnglishDate();
            DateTime? endDate = nependDate.ToEnglishDate();

            SalarySheetViewModel vm = new SalarySheetViewModel();

            var salarySheets = await _salarySheetRepository.GetAllSalarySheetAsync();
            var employee = await _employeeRepository.GetAllEmployeeAsync();
            vm.Employeee = employee;
            vm.SalarySheets = salarySheets.Where(x => x.EmployeeId == employeeId).ToList();
            vm.SalarySheets = vm.SalarySheets.Where(x => x.AdvanceSalaryDate.ToEnglishDate() >= startDate && x.AdvanceSalaryDate.ToEnglishDate() < endDate).ToList();
            ViewBag.MonthOrder = monthNo;
            ViewBag.EmployeeId = employeeId;
            return View(vm);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            var salarySheets = await _salarySheetRepository.GetAllSalarySheetAsync();
            SalarySheetDto dto = new SalarySheetDto
            {
                Employees = await _employeeRepository.GetAllEmployeeAsync(),

                Posts = await _postRepository.GetAllPostAsync()

            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(SalarySheetDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _salarySheetService.Insertasync(dto);
                    return RedirectToAction("SalaryIndex","Employee", new { message = "Salary has been saved successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid data !";
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View(dto);
        }

        [HttpGet()]
        public async Task<IActionResult> Update(long? id)
        {
            if (!id.HasValue)
            {
                throw new Exception();
            }
            var salarySheet = await _salarySheetRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            SalarySheetDto dto = new SalarySheetDto()
            {
                Employees = await _employeeRepository.GetAllEmployeeAsync(),
                Posts = await _postRepository.GetAllPostAsync()
            };
            _salarySheetAssembler.copyFrom(dto, salarySheet);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(SalarySheetDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _salarySheetService.UpdateAsync(dto);
                    return RedirectToAction("Index", "SalarySheet", new { message = "Salary has been update successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid data !";
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View();
        }
        [HttpGet()]
        public async Task<IActionResult> Delete(long id)
        {
            var salarySheet = await _salarySheetRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(salarySheet);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(SalarySheet salarySheet)
        {
            try
            {
                if (salarySheet != null)
                {
                    await _salarySheetService.Delete(salarySheet.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "SalarySheet", new { messege = "Salary has been Deleted successfully." });
                }
            }
            catch (Exception ex)
            {

            }
            return View(salarySheet);
        }

        public async Task<ActionResult> ExportToExcel()
        {
            var employee = await _employeeRepository.GetAllEmployeeAsync();
            var salary = await _salarySheetRepository.GetAllSalarySheetAsync();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage pck = new ExcelPackage();

            using (var package = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
            {

            }
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.TabColor = System.Drawing.Color.Black;

            ws.Cells["A1"].Value = "PARICHAYA AWAS BIKASH PVT. LTD.";

            ws.Cells["A3"].Value = "Shalaryt Sheet Report";

            ws.Cells["A6"].Value = "Name";
            ws.Cells["B6"].Value = "Salary";

            ws.Row(6).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Row(6).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#228b22")));
            int rowStart = 7;
            foreach (var emp in employee)
            {
                ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("#F7F4F3")));

                foreach (var item in salary.Where(x=>x.EmployeeId==emp.Id))
                {
                   
                        ws.Cells[string.Format("A{0}", rowStart)].Value = emp.Name;
                        ws.Cells[string.Format("B{0}", rowStart)].Value = emp.BasicSalary;
                }
                rowStart++;
            }
           
            ws.Cells["A:AZ"].AutoFitColumns();

            Response.Clear();

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment; filename=" + "SalarySheetReport.xlsx");
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

        //[HttpGet()]
        //public async Task<IActionResult> AddSalary(long id)
        //{
        //    int tds = 0;
        //    var employee = await _employeeRepository.GetAllEmployeeAsync();
        //    var post = await _postRepository.GetAllPostAsync();
        //    var salary = await _salarySheetRepository.GetByIdAsync(id);
        //    SalarySheetDto salarySheetDto = new SalarySheetDto
        //    {
        //        EmployeeId = salary.EmployeeId,
        //        Employees = await _employeeRepository.GetAllEmployeeAsync(),
        //        BasicSalary = salary.BasicSalary,
        //        Deduction = salary.Deduction,
        //        Bonus = salary.Bonus,
        //        NetSalary = salary.NetSalary,
        //        PostId = salary.PostId,
        //    };
        //    return View(salarySheetDto);
        //}
        //[HttpPost()]
        //[ValidateAntiForgeryToken()]
        //public async Task<IActionResult> AddSalary(SalarySheetDto salarySheetDto)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            await _salarySheetService.Insertasync(salarySheetDto);
        //            return RedirectToAction("Index", "SalarySheet", new { message = "Salary has been Added successfully."});
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Message = "Error: Please contact Administrator.";
        //    }
        //    return View(salarySheetDto);
        //}


        //[HttpGet()]
        //public async Task<IActionResult> AdvanceSalary(long id)
        //{
        //    var employee = await _employeeRepository.GetAllEmployeeAsync();
        //    var post = await _postRepository.GetAllPostAsync();
        //    var salary = await _salarySheetRepository.GetByIdAsync(id);
        //    SalarySheetDto salarySheetDto = new SalarySheetDto
        //    {
        //        EmployeeId = salary.EmployeeId,
        //        BasicSalary = salary.BasicSalary,
        //        Deduction = salary.Deduction,
        //        Bonus = salary.Bonus,
        //        NetSalary = salary.NetSalary,
        //        PostId = salary.PostId,
        //        Employees = await _employeeRepository.GetAllEmployeeAsync(),

        //    };
        //    return View(salarySheetDto);
        //}
        //[HttpPost()]
        //[ValidateAntiForgeryToken()]
        //public async Task<IActionResult> AdvanceSalary(SalarySheetDto salarySheetDto)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            await _salarySheetService.Insertasync(salarySheetDto);
        //            return RedirectToAction("Index", "SalarySheet", new { message = "Salary has been Added successfully." });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Message = "Error: Please contact Administrator.";
        //    }
        //    return View(salarySheetDto);
        //}


    }


}
