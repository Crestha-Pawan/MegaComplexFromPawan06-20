using FiboBlock.InfraStructure.Assembler;
using FiboBlock.InfraStructure.Repository;
using FiboBlock.InfraStructure.Service;
using FiboBlock.Src.Dto;
using FiboBlock.Src.ViewModel;
using FiboInfraStructure.Entity.FiboBlock;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem.Areas.FiboBlock.Controllers
{
    public class ElectricityController : Controller
    {
        private readonly IElectricityRepository _electricityRepository;
        private readonly IElectricityAssembler _assembler;
        private readonly IElectricityService _electricityService;
        public ElectricityController(IElectricityRepository electicityRepository
            , IElectricityAssembler assembler
            , IElectricityService electicityService)
        {
            _assembler = assembler;
            _electricityRepository = electicityRepository;
            _electricityService = electicityService;
        }
        public async Task<IActionResult> Index(ElectricityViewModel vm, string message, string messege)
        {
            vm.Electricities = new List<Electricity>();
            var electricity = await _electricityRepository.GetAllElectricityAsync();
            vm.Electricities = electricity;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public IActionResult Create()
        {
          
            return View();
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(ElectricityDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _electricityService.Insertasync(dto);
                    return RedirectToAction("Index", "Electricity", new { message = "Electricity has been saved successfully." });
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
            var entity = await _electricityRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            ElectricityDto dto = new ElectricityDto();
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(ElectricityDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _electricityService.UpdateAsync(dto);
                    return RedirectToAction("Index", "Electricity", new { message = "Electricity has been update successfully." });
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
            var electricity = await _electricityRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(electricity);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Electricity electricity)
        {
            try
            {
                if (electricity != null)
                {
                    await _electricityService.Delete(electricity.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Electricity", new { messege = "Electricity has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View(electricity);
        }
        public async Task<IActionResult> ToggleStatus(long id)
        {
            var tax = await _electricityRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(tax);
        }

        [HttpPost()]
        public async Task<IActionResult> ToggleStatus(Electricity electricity)
        {
            try
            {
                if (electricity != null)
                {
                    electricity = await _electricityRepository.GetByIdAsync(electricity.Id) ?? throw new Exception();
                    await _electricityService.ToggleStatus(electricity).ConfigureAwait(true);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View(electricity);
        }

    }
}
