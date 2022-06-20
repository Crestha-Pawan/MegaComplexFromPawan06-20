using FiboInfraStructure.Entity.FiboBilling;
using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBilling.Src.ViewModel
{
    public  class DashBoardViewModel
    {
        public long? ClientId { get; set; }
        public decimal Cash { get; set; }
        public decimal Notreceived { get; set; }
        public List<ElectricityUnitSetup> Electricities { get; set; }
        public List<Billing> Billings { get; set; }
        public List<DashBoardViewModel> dashBoardViewModels { get; set; }
    }
}
