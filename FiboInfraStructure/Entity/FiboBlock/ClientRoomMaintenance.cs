using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBlock
{
    public class ClientRoomMaintenance: BaseEntity
    {
        public long? ClientId { get; set; }
        public long? RoomId { get; set; }
        public string MaintenanceCharge { get; set; }
        public long? MonthId { get; set; }
        public long? YearId { get; set; }
    }
}
