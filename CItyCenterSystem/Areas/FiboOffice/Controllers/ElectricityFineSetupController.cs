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
    public class ElectricityFineSetupController : Controller
    {
        private readonly IElectricityFineSetupService _fineSetupService;
        private readonly IElectricityFineSetupRepository _fineSetupRepository;
        private readonly IElectricityFineSetupAssembler _fineSetupAssembler;

        public ElectricityFineSetupController(IElectricityFineSetupService fineSetupService, IElectricityFineSetupRepository fineSetupRepository, IElectricityFineSetupAssembler fineSetupAssembler)
        {

            _fineSetupRepository = fineSetupRepository;
            _fineSetupAssembler = fineSetupAssembler;
            _fineSetupService = fineSetupService;
        }
        public async Task<IActionResult> Index(ElectricityFineSetupViewModel vm, string message, string messege)
        {
            vm.fineSetups = new List<ElectricityFineSetup>();
            var fineSetups = await _fineSetupRepository.GetAllFineSetupAsync();
            vm.fineSetups = fineSetups;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ElectricityFineSetupDto dto = new ElectricityFineSetupDto
            {
                
            };
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(ElectricityFineSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _fineSetupService.Insertasync(dto);
                    return RedirectToAction("Index", "ElectricityFineSetup", new { message = "FineSetup has been saved successfully." });
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
            ElectricityFineSetupDto dto = new ElectricityFineSetupDto();
            
            _fineSetupAssembler.copyFrom(dto, fineSetup);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(ElectricityFineSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _fineSetupService.UpdateAsync(dto);
                    return RedirectToAction("Index", "ElectricityFineSetup", new { message = "FineSetup has been update successfully." });
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
        public async Task<IActionResult> DeleteConfirmed(ElectricityFineSetup fineSetup)
        {
            try
            {
                if (fineSetup != null)
                {
                    await _fineSetupService.Delete(fineSetup.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "ElectricityFineSetup", new { messege = "FineSetup has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {

            }
            return View(fineSetup);
        }
    }
}
