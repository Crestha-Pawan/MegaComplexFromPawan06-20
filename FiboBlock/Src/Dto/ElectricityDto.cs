using FiboInfraStructure.Src;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.Src.Dto
{
    public class ElectricityDto:BaseDto
    {
        public decimal? Unit { get; set; }
        public decimal? Charge { get; set; }
        public string Status { get; set; }
    }
}
