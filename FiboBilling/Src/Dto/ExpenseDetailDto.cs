using FiboInfraStructure.Src;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBilling.Src.Dto
{
    public class ExpenseDetailDto : BaseDto
    {
        public long? ExpenseId { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
