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
    public class RoomController : Controller
    {
        private readonly IBlockRepository _blockRepository;
        public readonly IRoomRepository _roomRepository;
        private readonly IRoomAssembler _roomAssembler;
        private readonly IRoomService _roomService;
        public RoomController(IBlockRepository blockRepository
            ,IRoomAssembler roomAssembler
            , IRoomService roomService
            ,IRoomRepository roomRepository)
        {
           
            _blockRepository = blockRepository;
            _roomAssembler = roomAssembler;
            _roomService = roomService;
            _roomRepository = roomRepository;

        }
        public async Task<IActionResult> Index(BlockViewModel vm, string message, string messege)
        {
            vm.Rooms = new List<Room>();
            var room = await _roomRepository.GetAllRoomAsync();
            vm.Rooms = room.OrderBy(x=>x.Name).ToList();
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            RoomDto dto = new RoomDto
            {
            };
            return View(dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(RoomDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _roomService.Insertasync(dto);
                    return RedirectToAction("Index", "Room", new { message = "Room has been saved successfully." });
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
            var entity = await _roomRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            RoomDto dto = new RoomDto
            {
               
            };
            _roomAssembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(RoomDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _roomService.UpdateAsync(dto);
                    return RedirectToAction("Index", "Room", new { message = "Room has been update successfully." });
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
            var room = await _roomRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(room);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Room room)
        {
            try
            {
                if (room != null)
                {
                    await _roomService.Delete(room.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Room", new { messege = "Room has been Deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return View(room);
        }
    }
}
