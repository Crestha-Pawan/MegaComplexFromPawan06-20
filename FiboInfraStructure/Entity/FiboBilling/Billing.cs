using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBilling
{
    public class Billing : BaseEntity
    {
        public long? YearId { get; set; }
        [ForeignKey("ClientId")]
        public long? ClientId { get; set; }
        public string BillingAmount { get; set; }
        public string GrandTotal { get; set; }
        public string DueAmount { get; set; }
        public DateTime? DueDate { get; set; }
        public string DebitTotal { get; set; }
        public string CreditTotal { get; set; }
        public bool IsPaid { get; set; }
        public string Fine { get; set; }
        public string Discount { get; set; }
        public string MaintenanceCharge { get; set; }
        public string CashReceived { get; set; }
        public string ElectricityFineAmount { get; set; }
        public bool IsRent { get; set; }
        public bool IsElectricity { get; set; }
        public bool IsDue { get; set; }
        public string BillNo { get; set; }
        public string DuePaid { get; set; }
    }
}
