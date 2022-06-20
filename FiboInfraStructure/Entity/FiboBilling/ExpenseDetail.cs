using FiboInfraStructure.Entity.FiboBilling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBilling
{
    public class ExpenseDetail : BaseEntity
    {
        [ForeignKey("ExpenseId")]
        public long? ExpenseId { get; set; }

        [NotMapped()]
        public virtual Expense Expense { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
