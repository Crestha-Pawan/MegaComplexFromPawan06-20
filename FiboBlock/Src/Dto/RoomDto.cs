using FiboInfraStructure.Entity.FiboBlock;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboBlock.Src.Dto
{
  public class RoomDto : BaseDto
    {
        public string Name { get; set; }
        public decimal MonthlyAmount { get; set; }
        [ForeignKey("BlockId")]
        public long? BlockId { get; set; }
        public virtual Block Block { get; set; }
    }
}
