using FiboInfraStructure.Entity.FiboAddress;
using FiboInfraStructure.Entity.Ledger;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboParty.Src.Dto
{
    public class PartyDto : BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public decimal CreditLimit { get; set; }
        public string CreditLimitDay { get; set; }
        public string PartiesType { get; set; }


        public decimal BillNumber { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }


        public string Remarks { get; set; }
        public string PartiesCreatedDate { get; set; }
        public string WardNumber { get; set; }
        public decimal BalancedAmount { get; set; }


        public long? ProvienceId { get; set; }
        public virtual Provience Provience { get; set; }
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }
        public long? LocalLevelId { get; set; }
        public virtual LocalLevel LocalLevel { get; set; }

        public long LedgerId { get; set; }
        public virtual Ledger Ledger { get; set; }
        public string PartyId { get; set; }


        public IList<Provience> Proviencess { get; set; } = new List<Provience>();
        public SelectList ProvienceList => new SelectList(Proviencess, nameof(Provience.Id), nameof(Provience.Name));
        public IList<District> Districts { get; set; } = new List<District>();
        public SelectList DistrictList => new SelectList(Districts, nameof(District.Id), nameof(District.Name));
        public IList<LocalLevel> LocalLevels { get; set; } = new List<LocalLevel>();
        public SelectList LocalLevelList => new SelectList(LocalLevels, nameof(LocalLevel.Id), nameof(LocalLevel.Name));
        //public IList<Ledger> Ledgers { get; set; } = new List<Ledger>();
        //public SelectList LedgerList => new SelectList(Ledgers, nameof(Ledger.Id), nameof(Ledger.Name));

    }
}
