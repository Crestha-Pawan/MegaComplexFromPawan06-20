using FiboInfraStructure;
using FiboInfraStructure.Common;
using FiboInfraStructure.Entity.Ledger;
using FiboOffice.InfraStructure.Repository;
using FiboParty.Infrastructure.Assembler;
using FiboParty.Infrastructure.Repository;
using FiboParty.Infrastructure.Service;
using FiboParty.Src.Dto;
using FiboParty.Src.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem.Areas.PartySetup.Controllers
{
    public class PartyLedgerController : Controller
    {
        private readonly ILedgerService _LedgerService;
        private readonly ILedgerRepository _ledgerRepository;
        private readonly ILedgerAssembler _ledgerAssembler;
        private readonly IFiscalYearRepository _fiscalYearRepository;
        //private readonly IDistrictRepository _districtRepository;
        //private readonly ILocalLevelRepository _localLevelRepository;
        private readonly IPartyRepository _partyRepository;
        private readonly ILedgerDetailRepository _ledgerDetailRepo;
        private readonly ILedgerDetailService _ledgerDetailService;
        private readonly IMonthRepository _monthRepo;
        private readonly IYearRepository _yearRepo;
        private readonly ILedgerDetailAssembler _ledgerDetailAssembler;

        public PartyLedgerController(ILedgerService ledgerService,
            ILedgerRepository ledgerRepository,
            ILedgerAssembler ledgerAssembler,
            IFiscalYearRepository fiscalYearRepository,
            //IDistrictRepository districtRepository,
            //ILocalLevelRepository localLevelRepository,
            IPartyRepository partyRepository
            , ILedgerDetailRepository ledgerDetailRepo
            , ILedgerDetailService ledgerDetailService
            , IMonthRepository monthRepo
            , IYearRepository yearRepo
            , ILedgerDetailAssembler ledgerDetailAssembler
            )
        {
            _ledgerRepository = ledgerRepository;
            _ledgerAssembler = ledgerAssembler;
            _LedgerService = ledgerService;
            //_provienceRepository = provienceRepository;
            //_districtRepository = districtRepository;
            //_localLevelRepository = localLevelRepository;
            _partyRepository = partyRepository;
            _ledgerDetailRepo = ledgerDetailRepo;
            _ledgerDetailService = ledgerDetailService;
            _monthRepo = monthRepo;
            _yearRepo = yearRepo;
            _ledgerDetailAssembler = ledgerDetailAssembler;
            _fiscalYearRepository = fiscalYearRepository;
        }
        public async Task<IActionResult> Index(LedgerViewModel vm, string message, long id)
        {
            vm.Ledgers = new List<Ledger>();
            var party = await _partyRepository.GetAllPartyAsync();
            vm.Partys = party;
            var ledger = await _ledgerRepository.GetAllLedgerAsync();
            if (vm.PartyId > 0)
            {
                ledger = ledger.Where(x => x.PartyId == vm.PartyId).ToList();

            }
            vm.Ledgers = ledger;
            ViewBag.Message = message;
            return View(vm);
        }

        //public async Task<IActionResult> PartyList(LedgerViewModel vm)
        //{
        //    vm.Ledgers = new List<Ledger>();
        //    var parti = await _partyRepository.GetAllPartyAsync();
        //    vm.Parties = parti;
        //    return View(vm);
        //}
        public async Task<IActionResult> PartyDetails(long? id)
        {
            LedgerViewModel vm = new LedgerViewModel();
            vm.LedgerDetails = new List<LedgerDetail>();
            var ledgerdetail = await _ledgerDetailRepo.GetAllLedgerDetailAsync();
            vm.LedgerDetails = ledgerdetail.Where(x => x.PartyId == id).ToList();

            vm.LedgerDetails = vm.LedgerDetails;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create(long id)
        {
            var party = await _partyRepository.GetByIdAsync(id);
            LedgerDto dto = new LedgerDto()
            {
                PartiesType = party.PartiesType,
                PartyId = party.Id,
                Address = party.Address,
                Partys = await _partyRepository.GetAllPartyAsync(),
            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(LedgerDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _LedgerService.Insertasync(dto);
                    return RedirectToAction("Index", "PartyLedger", new { message = "Ledger has been saved successfully." });
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
        public async Task<IActionResult> AddEntry(long id)
        {
            var ledger = await _ledgerRepository.GetByIdAsync(id);
            var ledgerDetailList = await _ledgerDetailRepo.GetAllLedgerDetailAsync();
            var ledgerDetail = ledgerDetailList.Where(x => x.LedgerId == ledger.Id).ToList();
            LedgerDto dto = new LedgerDto()
            {
                PartiesType = ledger.PartiesType,
                PartyId = ledger.PartyId,
                FiscalYearId = ledger.FiscalYearId,
                Address = ledger.Address,
                ledgerDetails = ledgerDetail,
                CreatedDate = ledger.CreatedDate,
                CreatedBy = ledger.CreatedBy,
                Partys = await _partyRepository.GetAllPartyAsync(),
            };
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> AddEntry(LedgerDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _LedgerService.UpdateAsync(dto);
                    await _ledgerDetailService.InsertAsyncFromAddEntry(dto);
                    return RedirectToAction("Index", "PartyLedger", new { message = "Ledger has been saved successfully." });
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
        public async Task<IActionResult> Update(long id)
        {
            var ledger = await _ledgerRepository.GetByIdAsync(id);
            var ledgerDetailList = await _ledgerDetailRepo.GetAllLedgerDetailAsync();

            LedgerDto dto = new LedgerDto()
            {
                PartiesType = ledger.PartiesType,
                PartyId = ledger.PartyId,
                Address = ledger.Address,
                CreatedDate = ledger.CreatedDate,
                CreatedBy = ledger.CreatedBy,
                LedgerDetailDtos = new List<LedgerDetailDto>(),
                Partys = await _partyRepository.GetAllPartyAsync(),
            };
            if (ledger != null)
            {
                _ledgerAssembler.copyFrom(dto, ledger);
                var entities = ledgerDetailList.Where(x => x.LedgerId == ledger.Id).ToList();
                foreach (var info in entities)
                {
                    LedgerDetailDto info_dto = new LedgerDetailDto();
                    _ledgerDetailAssembler.copyFrom(info_dto, info);
                    dto.LedgerDetailDtos.Add(info_dto);
                }
            }
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(LedgerDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _LedgerService.UpdateAsync(dto);


                    return RedirectToAction("Index", "PartyLedger", new { message = "Ledger has been saved successfully." });
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
        public async Task<IActionResult> Delete(long id)
        {
            var ledger = await _ledgerRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(ledger);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Ledger ledger)
        {
            try
            {
                if (ledger != null)
                {
                    await _LedgerService.Delete(ledger.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "PartyLedger", new { message = "Ledger been Delete successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(ledger);
        }
        //[HttpGet()]
        //public async Task<IActionResult> Details(long id)
        //{
        //    var party = await _partyRepository.GetByIdAsync(id);
        //    LedgerDto dto = new LedgerDto
        //    {
        //        PartiesType = party.PartiesType,
        //        Name = party.Name,
        //        Address = party.Address,

        //    };
        //    return View(dto);
        //}
        //[HttpPost()]
        //[ValidateAntiForgeryToken()]
        //public async Task<IActionResult> Details(LedgerDto dto)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            await _LedgerService.Insertasync(dto);
        //            return RedirectToAction("Index", "Ledger", new { message = "ledger has been saved successfully.", id = dto.Id });
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Error: Invalid data !";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Message = "Error: Please contact Administrator.";
        //    }
        //    return View(dto);
        //}
        [HttpGet()]
        public async Task<IActionResult> PartiesReport(PartiesReportVM vm)
        {
            var ledger = await _ledgerRepository.GetAllLedgerAsync();
            var parties = await _partyRepository.GetAllPartyAsync();
            var ledgerDetail = await _ledgerDetailRepo.GetAllLedgerDetailAsync();
            var fiscalyear = await _fiscalYearRepository.GetAllFiscalYearAsync();
            var fiscalyr = fiscalyear.Where(x => x.IsActive()).FirstOrDefault();

            var query = (from l in ledger
                         join p in parties on l.PartyId equals p.Id
                         join ld in ledgerDetail on l.Id equals ld.LedgerId
                         where l.FiscalYearId == fiscalyr.Id
                         select new
                         {
                             PartyId = ld.Ledger.PartyId,
                             EntryDate = ld.Date,
                             PartiesType = ld.Ledger.PartiesType,
                             Dr = CommaSeperatedDigit.getCommaSeperatedValue (ld.Ledger.Debit.ToString()),
                             Cr = CommaSeperatedDigit.getCommaSeperatedValue(ld.Ledger.Credit.ToString()),
                             Balance = CommaSeperatedDigit.getCommaSeperatedValue(ld.Ledger.BalanceAmount.ToString())

                         }).ToList();

            //1,00,00,00,000


            List<PartiesReportVM> list = query.GroupBy(l => new { l.PartyId }).Select(cl => new PartiesReportVM
            {
                PartyId = cl.Key.PartyId,
                EntryDate = cl.Select(x => x.EntryDate).LastOrDefault().ToString(),
                PartiesType = cl.Select(x => x.PartiesType).FirstOrDefault(),
                Dr = cl.Select(x => x.Dr).FirstOrDefault().ToString(),
                Cr = cl.Select(x => x.Cr).FirstOrDefault().ToString(),
                Balance = cl.Select(x => x.Balance).FirstOrDefault().ToString(),

            }).ToList();
            #region Filter
            var party = await _partyRepository.GetAllPartyAsync();
            vm.Partys = party;
            if (vm.PartyId > 0)
            {
                list = list.Where(x => x.PartyId == vm.PartyId).ToList();
            }
            vm.PartiesReportVMList = list;
            #endregion

            vm.PartiesReportVMList = list;
            return View(vm);
        }

        public async Task<ActionResult> MonthlyReport(long id)
        {
            PartiesReportVM vm = new PartiesReportVM()
            {
                MonthList = await _monthRepo.GetAllMonthAsync(),
                Years = await _yearRepo.GetAllYearAsync()
            };

            vm.PartyId = id;
            return View(vm);
        }
        public async Task<ActionResult> PartyLedger(string id)
        {
            long? Id = long.Parse(id.Split("-")[0].Trim());
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


            PartiesReportVM vm = new PartiesReportVM();

            var ledgerList = await _ledgerRepository.GetAllLedgerAsync();
            var ledgerDetail = await _ledgerDetailRepo.GetAllLedgerDetailAsync();
            var ledger = ledgerList.Where(x => x.PartyId == Id).FirstOrDefault();
            ledgerDetail = ledgerDetail.Where(x => x.LedgerId == ledger.Id).ToList();
            vm.LedgerList = ledgerList;
            vm.LedgerDetailList = ledgerDetail;
            vm.LedgerDetailList = vm.LedgerDetailList.Where(x => x.Date.ToDateTime() >= startDate && x.Date.ToDateTime() < endDate).ToList();
            ViewBag.MonthOrder = monthNo;
            vm.PartyId = Id;


            #region Balance BD
            string PreviousMonthstartDate = string.Empty;
            string PreviousMonthendDate = string.Empty;
            if (monthNo == "1")
            {
                PreviousMonthstartDate = ((yearRepo.YearName).ToDecimal() - 1) + "/" + "12" + "/" + "1";
                PreviousMonthendDate = yearRepo.YearName + "/" + "1" + "/" + "1";
            }
            else
            {
                PreviousMonthstartDate = yearRepo.YearName + "/" + (monthNo.ToDecimal() - 1).ToString() + "/" + "1";
                PreviousMonthendDate = yearRepo.YearName + "/" + monthNo + "/" + "1";
            }
            DateTime? sDate = PreviousMonthstartDate.ToEnglishDate();
            DateTime? eDate = PreviousMonthendDate.ToEnglishDate();
            var pmledgerDetail = await _ledgerDetailRepo.GetAllLedgerDetailAsync();
            pmledgerDetail = pmledgerDetail.Where(x => x.LedgerId == ledger.Id).ToList();
            vm.PMLedgerDetailList = pmledgerDetail;
            vm.PMLedgerDetailList = vm.PMLedgerDetailList.Where(x => x.Date.ToDateTime() >= sDate && x.Date.ToDateTime() < eDate).ToList();
            ViewBag.MonthStartDate = PreviousMonthendDate;
            #endregion

            return View(vm);
        }


    }
}
