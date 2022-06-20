
using FiboBilling.InfraStructure.Assembler;
using FiboBilling.InfraStructure.Repository;
using FiboBilling.InfraStructure.Service;
using FiboBilling.Src.Dto;
using FiboBilling.Src.ViewModel;
using FiboInfraStructure;
using FiboInfraStructure.Entity.FiboBilling;
using FiboOffice.InfraStructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem.Areas.FiboBilling.Controllers
{ 
    public class ExpenseController : Controller
    {
        private readonly IExpenseAssembler _assembler;
        private readonly IExpenseDetailAssembler _detailAssembler;

        private readonly IExpenseRepository _repository;
        private readonly IExpenseDetailRepository _detailRepository;

        private readonly IExpenseService _service;
        private readonly IExpenseDetailService _detailService;

        private readonly IMonthRepository _monthRepo;
        private readonly IYearRepository _yearRepo;

        public ExpenseController(
            IExpenseAssembler assembler,
            IExpenseDetailAssembler detailAssembler,
            IExpenseRepository repository,
            IExpenseDetailRepository detailRepository,
            IExpenseService service,
            IExpenseDetailService detailService,
            IMonthRepository monthRepositor,
            IYearRepository yearRepository
            )
        {
            _assembler = assembler;
            _detailAssembler = detailAssembler;
            _repository = repository;
            _detailRepository = detailRepository;
            _service = service;
            _detailService = detailService;
            _monthRepo = monthRepositor;
            _yearRepo = yearRepository;
        }
        public async Task<IActionResult> Index(ExpenseViewModel vm, string message, string searchString)
        {

            vm.Expenses = new List<Expense>();
            var expense = await _repository.GetAllExpense();
            var expenses = _repository.GetAllExpenses();
            
            if (searchString != null)
            {
                ViewData["CurrentFilter"] = searchString;
                expenses = _repository.GetAllExpenseByFilter(searchString);
            }
            vm.Expenses = expense;
            vm.Expenses = expenses.ToList();
            ViewBag.Message = message;
            return View(vm);
        }

        public async Task<IActionResult> OfficeExpView(ExpenseViewModel vm, string message)
        {

            vm.Expenses = new List<Expense>();
            var expense = await _repository.GetAllExpense();
            if(string.IsNullOrEmpty(vm.FromMiti) && string.IsNullOrEmpty(vm.ToMiti))
            {
                vm.FromDate = DateTime.Now.AddDays(-1);
                vm.ToDate = DateTime.Now;
                expense = expense.Where(x => x.Date > vm.FromDate && x.Date < vm.ToDate).ToList();
            }
            if (!string.IsNullOrEmpty(vm.FromMiti))
            {
                vm.FromDate = vm.FromMiti.ToEnglishDate();
                expense =expense.Where(x => x.Date >= vm.FromDate).ToList();
            }
            if (!string.IsNullOrEmpty(vm.ToMiti))
            {
                vm.ToDate = vm.ToMiti.ToEnglishDate();
                expense = expense.Where(x => x.Date <= vm.ToDate).ToList();
            }
            vm.Expenses = expense;
            ViewBag.Message = message;
            return View(vm);
        }

        public async Task<IActionResult> OfficeExpensesReport(long? id)
        {
            return View();
        }

        

        [HttpGet()]
        public async Task<IActionResult> OfficeExpenses()
        {
            ExpenseDto dto = new ExpenseDto
            {
                Miti = DateTime.Now.ToDateTime().ToNepDate(),
            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> OfficeExpenses(ExpenseDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dto.IsExpense = false;
                    await _service.InsertAsync(dto).ConfigureAwait(true);
                    return RedirectToAction("OfficeExpView", "Expense", new { message = "Expense been saved successfully." });
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
        public async Task<IActionResult> Update(long Id)
        {
            var expense = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            ExpenseDto dto = new ExpenseDto();
            _assembler.copyFrom(dto, expense);

            var details = await _detailRepository.GetAllExpenseDetailById(Id);

            if (details.Count > 0)
            {
                foreach (var detail in details)
                {
                    ExpenseDetailDto detailDto = new ExpenseDetailDto();
                    _detailAssembler.copyFrom(detailDto, detail);

                    dto.ExpenseDetailDtos.Add(detailDto);
                }
            }
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(ExpenseDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto).ConfigureAwait(true);
                    return RedirectToAction("Index", "Expense", new { message = "Expense been update successfully." });
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
    }
}
