using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.Ledger
{
    public class LedgerDetail : BaseEntity
    {
        [ForeignKey("LedgerId")]
        public long? LedgerId { get; set; }
        public long? PartyId { get; set; }
        public string CreditAmount { get; set; }
        public string DebitAmount { get; set; }
        public string Remarks { get; set; }
        public string BillNo { get; set; }
        public DateTime? Date { get; set; }
        public virtual Ledger Ledger { get; set; }

    }
}
