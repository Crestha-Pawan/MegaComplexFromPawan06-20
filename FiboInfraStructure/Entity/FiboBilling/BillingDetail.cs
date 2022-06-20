using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBilling
{
    public class BillingDetail : BaseEntity
    {
        [ForeignKey("BillingId")]
        public long? BillingId { get; set; }
        public string RentAmount { get; set; }
        public string ElectricityUnit { get; set; }
        public string ElectricityBillAmount { get; set; }
        public long? YearId { get; set; }
        [ForeignKey("MonthId")]
        public long? MonthId { get; set; }

        [ForeignKey("BlockId")]
        public long? BlockId { get; set; }
        [ForeignKey("RoomId")]
        public long? RoomId { get; set; }

        public string Debit { get; set; }

        public string Credit { get; set; }
        public string Total { get; set; }
        public string Remarks { get; set; }
    }
}
