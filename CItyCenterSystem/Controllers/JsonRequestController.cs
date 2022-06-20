using FiboBlock.InfraStructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem.Controllers
{
    public class JsonRequestController : Controller
    {
        private readonly IBlockRepository _blockRepository;
        private readonly IRoomRepository _roomRepository;
        public JsonRequestController(IBlockRepository blockRepository
            , IRoomRepository roomRepository)
        {
            
            _blockRepository = blockRepository;
            _roomRepository = roomRepository;
        }
        public async Task<JsonResult> LoadMonthlyCharge(long roomId)
        {
            //var block = await _blockRepository.GetAllBlockAsync();
            var room = await _roomRepository.GetAllRoomAsync();
            var monthlyCharge = room.Where(x => x.Id == roomId).FirstOrDefault();
            return Json(monthlyCharge.MonthlyAmount);
        }
        public async Task<JsonResult> LoadCharge(long id)
        {
            var rooms = await _roomRepository.GetAllRoomAsync();
            var charge = rooms.Where(x => x.Id == id).FirstOrDefault();
            return Json(charge.MonthlyAmount);
        }
        public async Task<JsonResult> LoadRoom(long id)
        {
            var roomList = await _roomRepository.GetAllRoomAsync();
            var room = roomList.Where(x => x.BlockId == id).ToList();
            return Json(room);
        }
    }
}
