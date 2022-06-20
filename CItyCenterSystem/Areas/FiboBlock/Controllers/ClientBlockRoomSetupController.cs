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
    public class ClientBlockRoomSetupController : Controller
    {
        private readonly IClientBlockRoomSetupRepository _repo;
        private readonly IClientBlockRoomSetupAssembler _assembler;
        private readonly IClientBlockRoomSetupService _service;
        public readonly  IRoomRepository _roomRepository;
        public readonly  IBlockRepository _blockRepository;
        public readonly  IClientRepository _clientRepository;
        public ClientBlockRoomSetupController(IClientBlockRoomSetupRepository repo
            , IClientBlockRoomSetupAssembler assembler
            , IClientBlockRoomSetupService service
            , IRoomRepository roomRepository
            , IBlockRepository blockRepository
            , IClientRepository clientRepository
            )
        {
            _repo = repo;
            _assembler = assembler;
            _service = service;
            _roomRepository = roomRepository;
            _blockRepository = blockRepository;
            _clientRepository = clientRepository;
           
        }
        public async Task<IActionResult> Index(ClientBlockRoomSetupViewModel vm, string message, string messege)
        {
            vm.ClientBlockRoomSetups = new List<ClientBlockRoomSetup>();
            var client = await _repo.GetAllClientBlockRoomSetupAsync();
            vm.ClientBlockRoomSetups = client;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ClientBlockRoomSetupDto dto = new ClientBlockRoomSetupDto()
            {
                Rooms =  await _roomRepository.GetAllRoomAsync(),
                Blocks = await _blockRepository.GetAllBlockAsync(),
                Clients = await _clientRepository.GetAllClientAsync()
            };
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(ClientBlockRoomSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    await _service.Insertasync(dto);
                    return RedirectToAction("Index", "ClientBlockRoomSetup", new { message = "ClientBlockRoomSetup has been saved successfully." });
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
            var entity = await _repo.GetByIdAsync(id.Value) ?? throw new Exception();
            ClientBlockRoomSetupDto dto = new ClientBlockRoomSetupDto();
            _assembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(ClientBlockRoomSetupDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(dto);
                    return RedirectToAction("Index", "ClientBlockRoomSetup", new { message = "ClientBlockRoomSetup has been update successfully." });
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
            var client = await _repo.GetByIdAsync(id) ?? throw new Exception();
            return View(client);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(ClientBlockRoomSetup client)
        {
            try
            {
                if (client != null)
                {
                    await _service.Delete(client.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "ClientBlockRoomSetup", new { message = "ClientBlockRoomSetup has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {

            }
            return View(client);
        }
    }
}
