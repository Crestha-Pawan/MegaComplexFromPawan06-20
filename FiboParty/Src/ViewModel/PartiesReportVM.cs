using FiboInfraStructure.Entity.FiboOffice;
using FiboInfraStructure.Entity.FiboParty;
using FiboInfraStructure.Entity.Ledger;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboParty.Src.ViewModel
{
    public class PartiesReportVM
    {
        public List<PartiesReportVM> PartiesReportVMList { get; set; }
        public List<Ledger> LedgerList { get; set; }
        public List<Ledger> Ledger { get; set; }
        //public List<Party> Parties { get; set; }
        public List<LedgerDetail> LedgerDetailList { get; set; }
        public List<LedgerDetail> PMLedgerDetailList { get; set; }
        public long? PartyId { get; set; }

        public long? FiscalYearId { get; set; }
        public string EntryDate { get; set; }
        public string PartiesType { get; set; }
        public string Dr { get; set; }
        public string Cr { get; set; }
        public string Balance { get; set; }
        public long? YearId { get; set; }
        public List<Month> MonthList { get; set; }
        public IList<Year> Years { get; set; } = new List<Year>();
        public SelectList YearList => new SelectList(Years, nameof(Year.Id), nameof(Year.YearName));
        public IList<Party> Partys { get; set; } = new List<Party>();
        public SelectList PartyList => new SelectList(Partys, nameof(Party.Id), nameof(Party.Name));
    }
}
