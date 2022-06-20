using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBlock
{
    public class Block:BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey("RoomId")]
        public long? RoomId { get; set; }
    }
}
