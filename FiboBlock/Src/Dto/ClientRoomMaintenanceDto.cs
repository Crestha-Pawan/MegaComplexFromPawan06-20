using FiboInfraStructure.Entity.FiboBlock;
using FiboInfraStructure.Entity.FiboOffice;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.Src.Dto
{
    public class ClientRoomMaintenanceDto: BaseDto
    {
        public long? ClientId { get; set; }
        public long? RoomId { get; set; }
        public string MaintenanceCharge { get; set; }
        public long? MonthId { get; set; }
        public long? YearId { get; set; }
        public List<ClientRoomMaintenanceDto> clientRoomMaintenanceDtos { get; set; }
        public IList<Client> ClientList { get; set; } = new List<Client>();
        public SelectList ClientSelectList => new SelectList(ClientList, nameof(Client.Id), nameof(Client.OwnerName));
        public IList<Room> Rooms { get; set; } = new List<Room>();
        public SelectList RoomList => new SelectList(Rooms, nameof(Room.Id), nameof(Room.Name));

        public IList<Month> Months { get; set; } = new List<Month>();
        public SelectList MonthList => new SelectList(Months, nameof(Month.Id), nameof(Month.MonthName));

        public IList<Year> Years { get; set; } = new List<Year>();
        public SelectList YearList => new SelectList(Years, nameof(Year.Id), nameof(Year.YearName));
    }
}
