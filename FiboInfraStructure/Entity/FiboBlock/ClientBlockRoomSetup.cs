using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBlock
{
    public class ClientBlockRoomSetup : BaseEntity
    {
        public long? ClientId { get; set; }
        public long? BlockId { get; set; }
        public string RoomId { get; set; }
    }
}
