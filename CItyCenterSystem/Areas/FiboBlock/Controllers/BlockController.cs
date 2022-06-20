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
    public class BlockController : Controller
    {
        private readonly IBlockRepository _blockRepository;
        private readonly IBlockAssembler _blockAssembler;
        private readonly IBlockService _blockService;
        public readonly IRoomRepository _roomRepository;
        public readonly IRoomAssembler _roomAssembler;
        public BlockController(IBlockRepository blockRepository
            , IBlockAssembler blockAssembler
            ,IBlockService blockService
            ,IRoomRepository roomRepository
            , IRoomAssembler roomAssembler)
        {
            _blockAssembler = blockAssembler;
            _blockRepository = blockRepository;
            _blockService = blockService;
            _roomRepository = roomRepository;
            _roomAssembler = roomAssembler;
        }
        public async Task<IActionResult> Index(BlockViewModel vm, string message, string messege)
        {
            vm.Blocks = new List<Block>();
            var block = await _blockRepository.GetAllBlockAsync();
                vm.Blocks = block;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public async Task<IActionResult> Create( long BlockId)
        {
            BlockDto dto = new BlockDto();
            dto.RoomId = BlockId;
            dto.Rooms = new List<Room>();
            var rooms = await _roomRepository.GetAllRoomAsync();
            dto.Rooms = rooms;
            //var block = rooms.Where(x => x.BlockId == BlockId).LastOrDefault();
            //if (block != null)
            //{
            //    var roomss = await _roomRepository.GetAllByRoomId(block.Id);
            //    dto.Id = block.Id;
            //    dto.Name = block.Name;

            //    foreach (var info in roomss)
            //    {
            //        RoomDto info_dto = new RoomDto();
            //        _roomAssembler.copyFrom(info_dto, info);
            //        dto.RoomDtos.Add(info_dto);
            //    }
            //}
            return  View (dto);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(BlockDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _blockService.Insertasync(dto);
                    return RedirectToAction("Index", "Block", new { message = "Block has been saved successfully." });
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
            var entity = await _blockRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            BlockDto dto = new BlockDto();
            _blockAssembler.copyFrom(dto, entity);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(BlockDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _blockService.UpdateAsync(dto);
                    return RedirectToAction("Index","Block", new { message="Block has been update successfully."});
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
            var block = await _blockRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(block);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Block block)
        {
            try
            {
                if (block != null)
                {
                    await _blockService.Delete(block.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Block", new { message = "Block has been deleted successfully." });
                }
            }
            catch (Exception ex)
            {

            }
            return View(block);
        }
        public async Task<IActionResult> BlockList(long RoomId)
        {
           BlockViewModel vm = new BlockViewModel
            {
               Roooms= await _roomRepository.GetAllRoomAsync(),
               blocks = await _blockRepository.GetByIdAsync(RoomId),
                Roomss = await _roomRepository.GetByIdAsync(RoomId)
            };
            return View(vm);
        }
    }
}
