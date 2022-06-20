using FiboInfraStructure.Entity.FiboBilling;
using FiboInfraStructure.Entity.FiboBlock;
using FiboInfraStructure.Entity.FiboOffice;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboBilling.Src.ViewModel
{
    public class BillingViewModel
    {
        public List<Billing> BillingList { get; set; }
        public List<BillingDetail> BillingDetailList { get; set; }
        public List<BillingViewModel> billingViewModelslist { get; set; }
        public List<Month> MonthList { get; set; }
        public long? RoomId { get; set; }
        public long? BlockId { get; set; }
        public string ClientName { get; set; }
        public string Block { get; set; }
        public string Room { get; set; }
        public long? ClientId { get; set; }
        public long? YearId { get; set; }
        public long? MonthId { get; set; }
        public long? BillingId { get; set; }
        [NotMapped]
        public DateTime? FromDate { get; set; }
        [NotMapped]
        public DateTime? ToDate { get; set; }
        [NotMapped]
        public string FromMiti { get; set; }
        [NotMapped]
        public string ToMiti { get; set; }
        public string ActionName { get; set; }
        public string ElectricityUnit { get; set; }
        public string ElectricityBillAmount { get; set; }
        public string GrandTotal { get; set; }
        public string Fine { get; set; }
        public string ElectricityFineAmount { get; set; }
        public string Discount { get; set; }
        public string CashReceived { get; set; }
        public IList<Year> Years { get; set; } = new List<Year>();
        public SelectList YearList => new SelectList(Years, nameof(Year.Id), nameof(Year.YearName));
        public IList<Client> Clients { get; set; } = new List<Client>();
        public SelectList ClientList => new SelectList(Clients, nameof(Client.Id), nameof(Client.OwnerName));

    }
}
