using FiboInfraStructure.Entity.FiboBlock;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.Src.Dto
{
    public class BlockDto:BaseDto
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
        public long? RoomId { get; set; }
        public IList<Room> rooms { get; set; } = new List<Room>();
        public SelectList Roomlist => new SelectList(rooms, nameof(Room.Id), nameof(Room.Name), nameof(Room.MonthlyAmount));
        public List<RoomDto> RoomDtos { get; set; }
        public bool hasRoom()
        {
            return RoomDtos.Count > 0;
        }
    }
}
