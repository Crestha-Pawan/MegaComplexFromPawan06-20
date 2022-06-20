using FiboInfraStructure.Entity.FiboParty;
using FiboInfraStructure.Entity.Ledger;
using FiboParty.Infrastructure.Assembler;
using FiboParty.Infrastructure.Repository;
using FiboParty.Infrastructure.Service;
using FiboParty.Src.Dto;
using FiboParty.Src.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FiboInfraStructure;
namespace CItyCenterSystem.Areas.PartySetup.Controllers
{
    public class PartyController : Controller
    {
        private readonly IPartyService _partyService;
        private readonly IPartyRepository _partyRepository;
        private readonly IPartyAssembler _partyAssembler;
        //private readonly IProvienceRepository _provienceRepository;
        //private readonly IDistrictRepository _districtRepository;
        //private readonly ILocalLevelRepository _localLevelRepository;
        private readonly ILedgerRepository _ledgerRepository;
        private readonly ILedgerService _ledgerService;
        private readonly ILedgerAssembler _ledgerAssembler;
        public PartyController(IPartyService partyService,
            IPartyRepository partyRepository,
            IPartyAssembler partyAssembler,
            //IProvienceRepository provienceRepository,
            //IDistrictRepository districtRepository,
            //ILocalLevelRepository localLevelRepository,
            ILedgerRepository ledgerRepository,
            ILedgerService ledgerService,
            ILedgerAssembler ledgerAssembler)
        {
            _partyRepository = partyRepository;
            _partyAssembler = partyAssembler;
            _partyService = partyService;
            //_provienceRepository = provienceRepository;
            //_districtRepository = districtRepository;
            //_localLevelRepository = localLevelRepository;
            _ledgerRepository = ledgerRepository;
            _ledgerService = ledgerService;
            _ledgerAssembler = ledgerAssembler;
        }
        public async Task<IActionResult> Index(PartyViewModel vm, string message)
        {
            vm.Parties = new List<Party>();
            var party = await _partyRepository.GetAllPartyAsync();
            vm.Parties = party;
            ViewBag.Message = message;
            return View(vm);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            PartyDto dto = new PartyDto
            {
                PartiesCreatedDate =DateTime.Now.ToDateTime().ToNepDate(),
                //Proviencess = await _provienceRepository.GetAllProvienceAsync(),
                //Districts = await _districtRepository.GetAllDistrictAsync(),
                //LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),

            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(PartyDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _partyService.Insertasync(dto);
                    return RedirectToAction("Create", "PartyLedger", new { message = "Party has been saved successfully.", id = dto.Id });
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
        public async Task<IActionResult> Update(long? id)
        {
            if (!id.HasValue)
            {

            }
            var entity = await _partyRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            PartyDto dto = new PartyDto();
            _partyAssembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(PartyDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _partyService.UpdateAsync(dto);
                    return RedirectToAction("Index", "Party", new { message = "Party has been update successfully." });
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



        [HttpGet()]
        public async Task<IActionResult> Delete(long id)
        {
            var provience = await _partyRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(provience);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Party party)
        {
            try
            {
                if (party != null)
                {
                    await _partyService.Delete(party.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Party", new { message = "Party has been delete successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(party);
        }
        [HttpGet()]
        public async Task<IActionResult> Details(long id)
        {
            var party = await _partyRepository.GetByIdAsync(id);
            PartyDto dto = new PartyDto
            {
                //Proviencess = await _provienceRepository.GetAllProvienceAsync(),
                //Districts = await _districtRepository.GetAllDistrictAsync(),
                //LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),
                //Ledgers = await _ledgerRepository.GetAllLedgerAsync(),
                PartiesType = party.PartiesType,
                Name = party.Name,
                Address = party.Address,

            };
            return View(dto);
        }
        [HttpGet()]
        public async Task<IActionResult> PartiesReport()
        {
            var ledger = await _ledgerRepository.GetAllLedgerAsync();
            var parties = await _partyRepository.GetAllPartyAsync();
           
            return View();
        }

       

    }
}




