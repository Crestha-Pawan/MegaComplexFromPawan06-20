using FiboBilling.InfraStructure.Repository;
using FiboBlock.InfraStructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiboInfraStructure;
using FiboOffice.InfraStructure.Repository;

namespace CItyCenterSystem.Areas.FiboBilling.Controllers
{
    public class JsonRequestController : Controller
    {
        private readonly IRoomRepository _repo;
        private readonly IBillingRepository _bRepo;
        private readonly IBillingDetailRepository _bdRepo;
        private readonly IElectricityRepository _eRepo;
        private readonly IElectricityUnitSetupRepository _eSetupRepo;
        private readonly IFineSetupRepository _fineRepo;

        public JsonRequestController(IRoomRepository repo
            , IBillingRepository bRepo
            , IBillingDetailRepository bdRepo
            , IElectricityRepository eRepo
            , IElectricityUnitSetupRepository eSetupRepo
            , FineSetupRepository fineRepo
            )
        {
            _bRepo = bRepo;
            _bdRepo = bdRepo;
            _repo = repo;
            _eRepo = eRepo;
            _eSetupRepo = eSetupRepo;
            _fineRepo = fineRepo;
        }
        public async Task<JsonResult> LoadRoomRent(long id)
        {
            var rent = await _repo.GetByIdAsync(id);
            return Json(rent.MonthlyAmount);
        }
        public async Task<JsonResult> LoadDueAmount(long id)
        {
            string due="0";
            decimal total =0;
            decimal crTotal =0;
            var billingList = await _bRepo.GetAllBillingAsync();
            var billing = billingList.Where(x=>x.ClientId == id).ToList();

            foreach (var item in billing)
            {
                total += item.BillingAmount.ToDecimal();
                crTotal += item.CreditTotal.ToDecimal();
            }
            due = (crTotal - total).ToString();
            return Json(due);
        }
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
    }
}
