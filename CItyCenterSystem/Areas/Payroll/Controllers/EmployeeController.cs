using FiboAddress.InfraStructure.Repository;
using FiboInfraStructure.Entity.Payroll;
using Microsoft.AspNetCore.Mvc;
using Payroll.InfraStructure.Repository;
using Payroll.Src.Dto;
using Payroll.Src.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiboInfraStructure;
using Payroll.InfraStructure.Service;
using Payroll.InfraStructure.Assembler;

namespace CItyCenterSystem.Areas.Payroll.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeAssembler _employeeAssembler;
        private readonly IProvienceRepository _provienceRepository;
        private readonly ISalarySheetRepository _salaryrepos;
        private readonly IDistrictRepository _distictRepository;
        private readonly ILocalLevelRepository _localLevelRepository;
        private readonly IPostRepository _postRepository;
        private readonly ISalarySheetService _salarySheetService;
        public EmployeeController(IEmployeeService employeeService
            , IEmployeeRepository employeeRepository
            , IEmployeeAssembler employeeAssembler
            , IProvienceRepository provienceRepository
            , IDistrictRepository districtRepository
            , ILocalLevelRepository localLevelRepository
            , IPostRepository postRepository
            , ISalarySheetRepository salarySheeetRepository
            , ISalarySheetService salarySheetService)
        {
            _employeeRepository = employeeRepository;
            _employeeAssembler = employeeAssembler;
            _employeeService = employeeService;
            _provienceRepository = provienceRepository;
            _distictRepository = districtRepository;
            _localLevelRepository = localLevelRepository;
            _postRepository = postRepository;
            _salaryrepos = salarySheeetRepository;
            _salarySheetService = salarySheetService;
        }
        public async Task<IActionResult> Index(EmployeeViewModel vm,string message, string messege)
        {
            vm.Employees = new List<Employee>();
            var employees = await _employeeRepository.GetAllEmployeeAsync();
            //vm.Employees = emp.Where(x => x.IsActive()).ToList();
            vm.Employees = employees;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }

        public async Task<IActionResult> SalaryIndex(EmployeeViewModel vm,string message)
        {
            vm.Employees = await _employeeRepository.GetAllEmployeeAsync();
            vm.Employeelist = await _employeeRepository.GetAllEmployeeAsync();
            if (vm.EmployeeId >0)
            {
                vm.Employees = vm.Employees.Where(x => x.Id == vm.EmployeeId).ToList();
            }
            
            ViewBag.Message = message;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            var employees = await _employeeRepository.GetAllEmployeeAsync();
            EmployeeDto dto = new EmployeeDto
            {
                Proviences = await _provienceRepository.GetAllProvienceAsync(),
                Districts = await _distictRepository.GetAllDistrictAsync(),
                LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),
                Posts = await _postRepository.GetAllPostAsync()

            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(EmployeeDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeService.Insertasync(dto);
                    return RedirectToAction("Index", "Employee", new { message = "Employee been saved successfully." });
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

        [HttpGet()]
        public async Task<IActionResult> AddSalary(long id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            SalarySheetDto dto = new SalarySheetDto
            {
                EmployeeId = employee.Id,
                Employees = await _employeeRepository.GetAllEmployeeAsync(),
                BasicSalary = employee.BasicSalary.ToDecimal(),
                Tds = employee.TDS,
                Kosh = employee.Kosh,
            };
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> AddSalary(SalarySheetDto salarySheetDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _salarySheetService.Insertasync(salarySheetDto);
                    return RedirectToAction("SalaryIndex", "Employee", new { message = "Salary has been Added successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(salarySheetDto);
        }


        [HttpGet()]
        public async Task<IActionResult> AdvanceSalary(long id)
        {
            decimal? _advsalary = 0;
            decimal? _partiallyDeducted = 0;
            var employee = await _employeeRepository.GetByIdAsync(id);
            var salarysheet = await _salaryrepos.GetAllSalarySheetAsync();
            var salary =salarysheet.Where(x=>x.EmployeeId == id).ToList();
            var advancesalary = salarysheet.Where(x => x.EmployeeId == id && x.IsAdvance == true).ToList();
            foreach(var item in advancesalary){
                _advsalary += item.AdvanceSalary.ToDecimal();
            }
            foreach (var item in salary) {
                _partiallyDeducted += item.PartiallyDeducted.ToDecimal();
            }
            SalarySheetDto dto = new SalarySheetDto
            {
                EmployeeId = employee.Id,
                Employees = await _employeeRepository.GetAllEmployeeAsync(),
                CreatedDate = DateTime.Now,
                BasicSalary = employee.BasicSalary.ToDecimal(),
            };
            if(_partiallyDeducted >= _advsalary)
            {
                dto.PartiallyDeducted ="0";
            }
            else if(_advsalary> _partiallyDeducted)
            {
                dto.PartiallyDeducted =Convert.ToString( _advsalary - _partiallyDeducted);
            }
            
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> AdvanceSalary(SalarySheetDto salarySheetDto )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(!string.IsNullOrEmpty(salarySheetDto.AdvanceSalary))
                    {
                        if (salarySheetDto.AdvanceSalary.ToDecimal() > 0)
                            salarySheetDto.IsAdvance = true;
                    }
                    await _salarySheetService.Insertasync(salarySheetDto);
                    return RedirectToAction("SalaryIndex", "Employee", new { message = "Salary has been Added successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(salarySheetDto);
        }



        [HttpGet()]
        public async Task<IActionResult> Update(long? id)
        {
            if (!id.HasValue)
            {
                throw new Exception();
            }
            var emp = await _employeeRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            EmployeeDto dto = new EmployeeDto()
            {
                Proviences = await _provienceRepository.GetAllProvienceAsync(),
                Districts = await _distictRepository.GetAllDistrictAsync(),
                LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),
                Posts = await _postRepository.GetAllPostAsync()
            };
            _employeeAssembler.copyFrom(dto, emp);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(EmployeeDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeService.UpdateAsync(dto);
                    return RedirectToAction("Index", "Employee", new { message = "Employee been update successfully." });
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
            return View();
        }

        public async Task<IActionResult> ToggleStatus(long id)
        {
            var emp = await _employeeRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(emp);
        }

        [HttpPost()]
        public async Task<IActionResult> ToggleStatus(Employee emp)
        {
            try
            {
                if (emp != null)
                {
                    emp = await _employeeRepository.GetByIdAsync(emp.Id) ?? throw new Exception();
                    await _employeeService.ToggleStatus(emp).ConfigureAwait(true);
                    return RedirectToAction("Index", "Employee", new { message = "Employee been Toggle successfully." });
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
            return View(emp);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(long id)
        {
            var emp = await _employeeRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(emp);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Employee emp)
        {
            try
            {
                if (emp != null)
                {
                    await _employeeService.Delete(emp.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Employee", new { messege = "Employee been Delete successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(emp);
        }

    }
}
