using FiboBlock.InfraStructure.Assembler;
using FiboBlock.InfraStructure.Repository;
using FiboBlock.InfraStructure.Service;
using FiboBlock.Src.Dto;
using FiboBlock.Src.ViewModel;
using FiboInfraStructure.Entity.FiboBlock;
using FiboOffice.InfraStructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem.Areas.FiboBlock.Controllers
{
    public class ClientRoomMaintenanceController : Controller
    {
        private readonly IClientRoomMaintenanceAssembler _clientAssembler;
        private readonly IClientRoomMaintenanceRepository _clientRepository;
        private readonly IClientRoomMaintenanceService _clientService;
        private readonly IBlockRepository _blockRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IClientRepository _clientRepo;
        private readonly IMonthRepository _monthRepo;
        private readonly IYearRepository _yearRepo;
        public ClientRoomMaintenanceController(IClientRoomMaintenanceAssembler clientAssembler, IClientRoomMaintenanceRepository clientRepository,
            IClientRoomMaintenanceService clientService, IBlockRepository blockRepository
            , IRoomRepository roomRepository
            , IClientRepository clientRepo
            , IMonthRepository monthRepo
            , IYearRepository yearRepo
            )
        {
            _blockRepository = blockRepository;
            _clientAssembler = clientAssembler;
            _clientRepository = clientRepository;
            _clientService = clientService;
            _roomRepository = roomRepository;
            _clientRepo = clientRepo;
            _monthRepo = monthRepo;
            _yearRepo = yearRepo;
        }
        public async Task<IActionResult> Index(ClientRoomMaintenanceViewModel vm, string message, string messege)
        {
            vm.ClientRoomMaintenanceList = new List<ClientRoomMaintenance>();
            var clients = await _clientRepository.GetAllClientRoomMaintenanceAsync();
            vm.ClientRoomMaintenanceList = clients;
            //vm.ClientList = await _clientRepository.GetAllClientAsync();

            //if (vm.ClientId > 0)
            //{
            //    vm.Clients = vm.Clients.Where(x => x.Id == vm.ClientId).ToList();
            //}
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ClientRoomMaintenanceDto dto = new ClientRoomMaintenanceDto()
            {
                ClientList = await _clientRepo.GetAllClientAsync(),
                Rooms = await _roomRepository.GetAllRoomAsync(),
                Months = await _monthRepo.GetAllMonthAsync(),
                Years = await _yearRepo.GetAllYearAsync()
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(ClientRoomMaintenanceDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _clientService.Insertasync(dto);
                    return RedirectToAction("Index", "ClientRoomMaintenance", new { message = "Maintenance Charge has been saved successfully." });
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
    }
}
