using FiboInfraStructure.Entity.FiboBlock;
using FiboInfraStructure.Entity.FiboOffice;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboBlock.Src.Dto
{
    public class ElectricityUnitSetupDto:BaseDto
    {
        [ForeignKey("ClientId")]
        public long? ClientId { get; set; }
        public virtual Client Client { get; set; }
        [ForeignKey("BlockId")]
        public long? BlockId { get; set; }
        public virtual Block Block { get; set; }
        [ForeignKey("RoomId")]
        public long? RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string PreviousUnit { get; set; }
        public string CurrentUnit { get; set; }
        public string Unit { get; set; }
        public string Amount { get; set; }
        public string Rate { get; set; }
        public long? YearId { get; set; }
        public long? MonthId { get; set; }
        public List<ElectricityUnitSetupDto> ElectricityDtos { get; set; }
        public IList<Block> Blocks { get; set; } = new List<Block>();
        public SelectList BlockList => new SelectList(Blocks, nameof(Block.Id), nameof(Block.Name));
        public IList<Room> Rooms { get; set; } = new List<Room>();
        public SelectList RoomList => new SelectList(Rooms, nameof(Room.Id), nameof(Room.Name));
        public IList<Client> Clients { get; set; } = new List<Client>();
        public SelectList ClientList => new SelectList(Clients, nameof(Client.Id), nameof(Client.OwnerName));

        public IList<Year> Years { get; set; } = new List<Year>();
        public SelectList YearList => new SelectList(Years, nameof(Year.Id), nameof(Year.YearName));
        public IList<Month> Months { get; set; } = new List<Month>();
        public SelectList MonthList => new SelectList(Months, nameof(Month.Id), nameof(Month.MonthName));

    }
}
