using FiboInfraStructure.Entity.FiboParty;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboParty.Src.ViewModel
{
    public class PartyViewModel
    {
        public virtual List<Party> Parties { get; set; }
        public string Name { get; set; }
        public string LastEntryDate { get; set; }
        public decimal Balance { get; set; }
        public virtual PartyViewModel PartyVMList { get; set; }

    }
   
}
