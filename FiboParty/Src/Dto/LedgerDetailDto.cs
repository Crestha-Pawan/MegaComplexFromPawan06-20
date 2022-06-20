using FiboInfraStructure.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboParty.Src.Dto
{
   public class LedgerDetailDto : BaseDto
    {
        public long? LedgerId { get; set; }
        public long? PartyId { get; set; }
        public string CreditAmount { get; set; }
        public string DebitAmount { get; set; }
        public string Remarks { get; set; }
        public string BillNo { get; set; }
        public string Date { get; set; }

    }
}
