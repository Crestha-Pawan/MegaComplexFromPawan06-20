using FiboInfraStructure.Entity.FiboParty;
using FiboInfraStructure.Entity.Ledger;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboParty.Src.Dto
{
    public class LedgerDto : BaseDto
    {
        public long? PartyId { get; set; }
        public string PartiesType { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal BalanceAmount { get; set; }
        public long? FiscalYearId { get; set; }

        public string Address { get; set; }
        public List<LedgerDetailDto> LedgerDetailDtos { get; set; }
        public List<LedgerDetail> ledgerDetails { get; set; }
        public IList<Party> Partys { get; set; } = new List<Party>();
        public SelectList PartyList => new SelectList(Partys, nameof(Party.Id), nameof(Party.Name));
    }
}
