using FiboInfraStructure.Src;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBilling.Src.Dto
{
    public class BillingDetailDto: BaseDto
    {
        public long? BlockId { get; set; }
        public long? RoomId { get; set; }
        public long? BillingId { get; set; }
        public string RentAmount { get; set; }
        public string ElectricityUnit { get; set; }
        public string ElectricityBillAmount { get; set; }
        public long? MonthId { get; set; }
        public long? YearId { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Total { get; set; }
        public string Remarks { get; set; }
    }
}
