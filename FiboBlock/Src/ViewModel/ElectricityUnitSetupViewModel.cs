using FiboInfraStructure.Entity.FiboBlock;
using FiboInfraStructure.Entity.FiboOffice;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboBlock.Src.ViewModel
{
    public class ElectricityUnitSetupViewModel
    {
        public List<ElectricityUnitSetup> Electricities { get; set; }
        public List<ElectricityUnitSetup> ElectricitiesList { get; set; }
        public List<ElectricityUnitSetupViewModel> ElectricityUnitSetupViewModels { get; set; }
       
        public List<Month> MonthList { get; set; }
        public long? ElectricityUnitSetupId { get; set; }
        public long? YearId { get; set; }
        public long? MonthId { get; set; }
        public long? BlockId { get; set; }
        public long? RoomId { get; set; }
        public long? ClientId { get; set; }

        [NotMapped]
        public DateTime? FromDate { get; set; }
        [NotMapped]
        public DateTime? ToDate { get; set; }
        [NotMapped]
        public string FromMiti { get; set; }
        [NotMapped]
        public string ToMiti { get; set; }

        public string ActionName { get; set; }
        public IList<Year> Years { get; set; } = new List<Year>();
        public SelectList YearList => new SelectList(Years, nameof(Year.Id), nameof(Year.YearName));
        public IList<Block> Blocks { get; set; } = new List<Block>();
        public SelectList BlockList => new SelectList(Blocks, nameof(Block.Id), nameof(Block.Name));
        public IList<Room> Rooms { get; set; } = new List<Room>();
        public SelectList RoomList => new SelectList(Rooms, nameof(Room.Id), nameof(Room.Name));
        public IList<Client> ClientList { get; set; } = new List<Client>();
        public SelectList ClientSelectList => new SelectList(ClientList, nameof(Client.Id), nameof(Client.OwnerName));
    }
}
