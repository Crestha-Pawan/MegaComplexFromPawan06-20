using FiboInfraStructure.Entity.FiboBilling;
using FiboInfraStructure.Entity.FiboBlock;
using FiboInfraStructure.Entity.FiboOffice;
using FiboInfraStructure.Src;
using FiboOffice.InfraStructure.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FiboBilling.Src.Dto
{
    public class BillingDto : BaseDto
    {
        public long? BlockId { get; set; }
        public long? RoomId { get; set; }
        public long? YearId { get; set; }
        public long? ClientId { get; set; }
        public string BillingAmount { get; set; }
        public string DueAmount { get; set; }
        public string DueDate { get; set; }
        public string DebitTotal { get; set; }
        public string CreditTotal { get; set; }
        public bool IsPaid { get; set; }
        public string Fine { get; set; }
        public string Discount { get; set; }
        public string MaintenanceCharge { get; set; }
        public string CashReceived { get; set; }
        public string GrandTotal { get; set; }
        public bool IsRent { get; set; }
        public bool IsElectricity { get; set; }
        public bool IsDue { get; set; }
        public string ElectricityFineAmount { get; set; }
        public string BillNo { get; set; }
        public string DuePaid { get; set; }
        public List<BillingDetailDto> billingDetailDtos { get; set; }
        public List<BillingDetail> billingDetails { get; set; }

        public List<Client> ClientsList { get; set; }
        public Billing billing { get; set; }
        public IList<Block> Blocks { get; set; } = new List<Block>();
        public SelectList BlockList => new SelectList(Blocks, nameof(Block.Id), nameof(Block.Name));
        public IList<Room> Rooms { get; set; } = new List<Room>();
        public SelectList RoomList => new SelectList(Rooms, nameof(Room.Id), nameof(Room.Name));
        public IList<Client> Clients { get; set; } = new List<Client>();
        public SelectList ClientList => new SelectList(Clients, nameof(Client.Id), nameof(Client.OwnerName));
        public IList<Month> Months { get; set; } = new List<Month>();
        public SelectList MonthList => new SelectList(Months, nameof(Month.Id), nameof(Month.MonthName));
        public IList<Year> Years { get; set; } = new List<Year>();
        public SelectList YearList => new SelectList(Years, nameof(Year.Id), nameof(Year.YearName));

    }
}
