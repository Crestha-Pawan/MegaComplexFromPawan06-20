using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBlock
{
   public  class Room:BaseEntity
    {
        public string Name { get; set; }
        public decimal MonthlyAmount { get; set; }
        [ForeignKey("BlockId")]
        public long? BlockId { get; set; }
        public virtual Block Block { get; set; }
               //public decimal Electricity { get; set; }
        //public decimal Rent { get; set; }
        //public decimal TotalAmount { get; set; }
        //public decimal FIne { get; set; }
        //public decimal AmountPaid { get; set; }
    }
}
