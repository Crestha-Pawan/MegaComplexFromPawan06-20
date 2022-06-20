using FiboInfraStructure.Entity.FiboOffice;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBlock
{
    public class ElectricityUnitSetup : BaseEntity
    {
        [ForeignKey("ClientId")]
        public long? ClientId{get;set;}
        [ForeignKey("BlockId")]
        public long? BlockId { get; set; }
        [ForeignKey("RoomId")]
        public long? RoomId { get; set; }
        public string PreviousUnit { get; set; }
        public string CurrentUnit { get; set; }
        public string Unit { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        [ForeignKey("MonthId")]
        public long? MonthId { get; set; }
        [ForeignKey("YearId")] 
        public long? YearId { get; set; }

    }
}
