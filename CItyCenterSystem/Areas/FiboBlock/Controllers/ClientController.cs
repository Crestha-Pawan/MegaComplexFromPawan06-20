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
    public class ClientController : Controller
    {
        private readonly IClientAssembler _clientAssembler;
        private readonly IClientRepository _clientRepository;
        private readonly IClientService _clientService;
        private readonly IBlockRepository _blockRepository;
        private readonly IRoomRepository _roomRepository;
        public ClientController(IClientAssembler clientAssembler, IClientRepository clientRepository, 
            IClientService clientService, IBlockRepository blockRepository
            , IRoomRepository roomRepository)
        {
            _blockRepository = blockRepository;
            _clientAssembler = clientAssembler;
            _clientRepository = clientRepository;
            _clientService = clientService;
            _roomRepository = roomRepository;
        }
        public async Task <IActionResult> Index(ClientViewModel vm, string message, string messege)
        {
            vm.Clients = new List<Client>();
            var clients = await _clientRepository.GetAllClientAsync();
            vm.Clients = clients;
            vm.ClientList = await _clientRepository.GetAllClientAsync();

            if (vm.ClientId > 0)
            {
                vm.Clients = vm.Clients.Where(x => x.Id == vm.ClientId).ToList();
            }
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
       
        public async Task<IActionResult> BillingReport()
        {
            ClientViewModel vm = new ClientViewModel();
            vm.Rooms = await _roomRepository.GetAllRoomAsync();
            vm.Blocks = await _blockRepository.GetAllBlockAsync();
            vm.Clients = await _clientRepository.GetAllClientAsync();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ClientDto dto = new ClientDto();
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(ClientDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _clientService.Insertasync(dto);
                    return RedirectToAction("Index", "Client", new { message = "Client has been saved successfully." });
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
        [HttpGet]
        public async Task<IActionResult> Update(long? id)
        {
            if (!id.HasValue)
            {

            }
            var clients = await _clientRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            ClientDto dto = new ClientDto();
            
            _clientAssembler.copyFrom(dto, clients);
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(ClientDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _clientService.UpdateAsync(dto);
                    return RedirectToAction("Index", "Client", new { message = "Client has been update successfully." });
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
        [HttpGet]
        public async Task<IActionResult> Delete(long id )
        {
            var clients = await _clientRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(clients);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Client client)
        {
            try
            {
                if (client != null)
                {
                    await _clientService.Delete(client.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Client", new { messege = "Client has been Delete successfully." });
                }
            }
            catch (Exception ex)
            {

            }
            return View(client);
        }
    }
}
