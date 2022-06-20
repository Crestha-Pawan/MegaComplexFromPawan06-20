using FiboInfraStructure.Entity.FiboParty;
using FiboInfraStructure.Entity.Ledger;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboParty.Src.ViewModel
{
  public  class LedgerViewModel
    {
        public virtual List<Ledger> Ledgers { get; set; }
        public virtual List<LedgerViewModel> LedgerVMList { get; set; }
        public virtual List<Party> Parties { get; set; }
        public virtual List<LedgerDetail> LedgerDetails { get; set; }
        public long? PartyId { get; set; }
        public long? LedgerId { get; set; }
        public IList<Party> Partys { get; set; } = new List<Party>();
        public SelectList PartyList => new SelectList(Partys, nameof(Party.Id), nameof(Party.Name));
    }
}
