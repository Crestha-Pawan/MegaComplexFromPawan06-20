using FiboInfraStructure.Entity.FiboBlock;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.Src.ViewModel
{
   public  class BlockViewModel
    {
        public virtual List<Block> Blocks { get; set; }
        public virtual Block blocks { get; set; }
        public List<Room> Rooms { get; set; }
        public virtual Room Roomss { get; set; }
        public long? RoomId { get; set; }
        public long? BlockId { get; set; }
        public IList<Room> Roooms { get; set; } = new List<Room>();
        public SelectList RoomsList => new SelectList(Roooms, nameof(Room.Id), nameof(Room.Name));
    }
}
