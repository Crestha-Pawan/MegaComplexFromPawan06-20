using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Entity.Ledger
{
   public  class Ledger:BaseEntity
    {
        public long? PartyId { get; set; }
        public string PartiesType { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal BalanceAmount { get; set; }
        public string Address { get; set; }
        public long? FiscalYearId { get; set; }
    }
}
