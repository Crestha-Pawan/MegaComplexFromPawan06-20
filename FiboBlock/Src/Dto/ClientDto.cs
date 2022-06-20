using FiboInfraStructure.Entity.FiboBlock;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboBlock.Src.Dto
{
   public  class ClientDto:BaseDto
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
