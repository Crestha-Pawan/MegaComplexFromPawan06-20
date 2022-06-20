using CItyCenterSystem.Models;
using FiboBilling.InfraStructure.Repository;
using FiboBilling.Src.ViewModel;
using FiboInfraStructure.Entity.FiboBilling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FiboInfraStructure;
using FiboBlock.InfraStructure.Repository;
using FiboOffice.InfraStructure.Repository;

namespace CItyCenterSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBillingRepository _billingRepository;
        private readonly IElectricityUnitSetupRepository _electricityUnitSetupRepository;
        private readonly IMonthRepository _monthRepo;
        private readonly IYearRepository _yearRepo;

        public HomeController(ILogger<HomeController> logger,
            IBillingRepository billingRepository
            , IElectricityUnitSetupRepository electricityUnitSetupRepository
            , IMonthRepository monthRepo, IYearRepository yearRepo)
        {
            _logger = logger;
            _billingRepository = billingRepository; ;
            _electricityUnitSetupRepository = electricityUnitSetupRepository;
            _monthRepo = monthRepo;
            _yearRepo = yearRepo;
        }

        public async Task<IActionResult> Index(DashBoardViewModel vm, string message)
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

            var billings = await _billingRepository.GetAllBillingAsync();
            var electricity = await _electricityUnitSetupRepository.GetAllElectricityUnitSetupAsync();
            vm.Billings = billings.Where(x => x.DueDate >= startDate && x.DueDate < endDate).ToList();
            vm.Electricities = electricity;
            List<DashBoardViewModel> List = vm.Billings.GroupBy(l => new { l.ClientId }).Select(cl => new DashBoardViewModel
            {
                ClientId = (long)cl.Key.ClientId,
                Notreceived = cl.Sum(c => c.CashReceived.ToDecimal()+c.DuePaid.ToDecimal()),
            }).ToList();
            vm.Cash = List.Select(x => x.Notreceived.ToDecimal()).Sum();
            vm.dashBoardViewModels = List;
            ViewBag.Message = message;
            ViewBag.CurrentMonth = _monthName.MonthName;
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
