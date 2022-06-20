using FiboInfraStructure.Entity.FiboParty;
using FiboInfraStructure.Entity.Ledger;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartySetup.Src.ViewModel
{
     public class DashBoardViewModel
    { 
        public List<Party> Parties { get; set; }
        public List<Ledger> Ledgers { get; set; }
        
    }
}
