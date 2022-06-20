using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBlock
{
     public class Client:BaseEntity
    {
        public string BusinessName { get; set; }
        public string PanNo { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string CitizenShipNo { get; set; }
        public string Collateral { get; set; }
        public string Date { get; set; }
        public string RentDue { get; set; }
        public string ElectricityDue { get; set; }

    }
}
