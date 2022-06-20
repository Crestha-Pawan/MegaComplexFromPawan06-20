using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.InfraStructure.Assembler;
using FiboOffice.InfraStructure.Repository;
using FiboOffice.InfraStructure.Service;
using FiboOffice.Src.Dto;
using FiboOffice.Src.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem.Areas.FiboOffice.Controllers
{
    public class FineSetupController : Controller
    {
        private readonly  IFineSetupService _fineSetupService;
        private readonly IFineSetupRepository _fineSetupRepository;
        private readonly IFineSetupAssembler _fineSetupAssembler;

        public FineSetupController(IFineSetupService fineSetupService
        , IFineSetupRepository fineSetupRepository
            , IFineSetupAssembler fineSetupAssembler)
        //, IProvienceRepository provienceRepository
        //, IDistrictRepository districtRepository
        //, ILocalLevelRepository localLevelRepository
        //, IUserAndBranchInfo userAndBranchInfo)
        {

            _fineSetupRepository = fineSetupRepository;
            _fineSetupAssembler = fineSetupAssembler;
            _fineSetupService = fineSetupService;
        }
        public async Task<IActionResult> Index(FineSetupViewModel vm, string message,string messege)
        {
            vm.fineSetups = new List<FineSetup>();
            var fineSetups = await _fineSetupRepository.GetAllFineSetupAsync();
            vm.fineSetups = fineSetups;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            FineSetupDto dto = new FineSetupDto
            {
                //Proviencess = await _provienceRepository.GetAllProvienceAsync(),
                //Districts = await _districtRepository.GetAllDistrictAsync(),
                //LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),
                //CreatedBy = await _userAndBranchInfo.getCurrentUser(),
                //BranchId = await _userAndBranchInfo.getCurrentBranch(),
            };
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(FineSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _fineSetupService.Insertasync(dto);
                    return RedirectToAction("Index", "FineSetup", new { message = "FineSetup has been saved successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid Data !";
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
            var fineSetup = await _fineSetupRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            FineSetupDto dto = new FineSetupDto()
            {
                //Proviencess = await _provienceRepository.GetAllProvienceAsync(),
                //Districts = await _districtRepository.GetAllDistrictAsync(),
                //LocalLevels = await _localLevelRepository.GetAllLocalLevelAsync(),
            };
            _fineSetupAssembler.copyFrom(dto, fineSetup);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(FineSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _fineSetupService.UpdateAsync(dto);
                    return RedirectToAction("Index", "FineSetup", new { message = "FineSetup has been update successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid Data !";
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
            var finesetup = await _fineSetupRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(finesetup);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(FineSetup fineSetup)
        {
            try
            {
                if (fineSetup != null)
                {
                    await _fineSetupService.Delete(fineSetup.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "FineSetup", new { messege = "FineSetup has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {

            }
            return View(fineSetup);
        }

    }
}
