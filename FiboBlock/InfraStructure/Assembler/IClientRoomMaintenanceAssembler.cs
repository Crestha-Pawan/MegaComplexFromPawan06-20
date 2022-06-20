using FiboBlock.Src.Dto;
using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.InfraStructure.Assembler
{
    
    public interface IClientRoomMaintenanceAssembler
    {
        void copyTo(ClientRoomMaintenance crm, ClientRoomMaintenanceDto dto);
        void copyFrom(ClientRoomMaintenanceDto dto, ClientRoomMaintenance crm);
        void modifyTo(ClientRoomMaintenance crm, ClientRoomMaintenanceDto dto);
    }

    public class ClientRoomMaintenanceAssembler : IClientRoomMaintenanceAssembler
    {
        public void copyFrom(ClientRoomMaintenanceDto dto, ClientRoomMaintenance crm)
        {
            dto.Id = crm.Id;
            dto.CreatedBy = crm.CreatedBy;
            dto.CreatedDate = crm.CreatedDate;
            dto.ClientId = crm.ClientId;
            dto.RoomId = crm.RoomId;
            dto.YearId = crm.YearId;
            dto.MaintenanceCharge = crm.MaintenanceCharge;
            dto.MonthId = crm.MonthId;
        }

        public void copyTo(ClientRoomMaintenance crm, ClientRoomMaintenanceDto dto)
        {
            crm.CreatedBy = dto.CreatedBy;
            crm.CreatedDate = DateTime.Now;
            crm.ClientId = dto.ClientId;
            crm.RoomId = dto.RoomId;
            crm.YearId = dto.YearId;
            crm.MaintenanceCharge = dto.MaintenanceCharge;
            crm.MonthId = dto.MonthId;
        }

        public void modifyTo(ClientRoomMaintenance crm, ClientRoomMaintenanceDto dto)
        {
            crm.Id = dto.Id;
            crm.CreatedBy = dto.CreatedBy;
            crm.CreatedDate = dto.CreatedDate;
            crm.ModifiedBy = dto.ModifiedBy;
            crm.ModifiedDate = DateTime.Now;
            crm.ClientId = dto.ClientId;
            crm.RoomId = dto.RoomId;
            crm.YearId = dto.YearId;
            crm.MaintenanceCharge = dto.MaintenanceCharge;
            crm.MonthId = dto.MonthId;
        }
    }
}
