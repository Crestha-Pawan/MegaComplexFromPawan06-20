using FiboBlock.Src.Dto;
using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.InfraStructure.Assembler
{
    public interface IRoomAssembler
    {
        void copyTo(Room room, RoomDto dto);
        void copyFrom(RoomDto dto, Room room);
        void modifyTo(Room item, RoomDto dto);
    }

    public class RoomAssembler : IRoomAssembler
    {
        public void copyFrom(RoomDto dto, Room room)
        {
            dto.BlockId = room.BlockId;
            dto.MonthlyAmount = room.MonthlyAmount;
            dto.Name = room.Name;
            dto.Id = room.Id;
            dto.CreatedBy = room.CreatedBy;
            dto.CreatedDate = room.CreatedDate;
        }

        public void copyTo(Room room, RoomDto dto)
        {
            
            room.BlockId = dto.BlockId;
            room.MonthlyAmount = dto.MonthlyAmount;
            room.Name = dto.Name;
            room.Id = dto.Id;
            room.CreatedBy = dto.CreatedBy;
            room.CreatedDate = DateTime.Now;
        }

        public void modifyTo(Room room, RoomDto dto)
        {
            room.Id =dto.Id;
            room.BlockId = dto.BlockId;
            room.MonthlyAmount = dto.MonthlyAmount;
            room.Name = dto.Name;
            room.ModifiedBy = dto.ModifiedBy;
            room.ModifiedDate = DateTime.Now;
            room.CreatedBy = dto.CreatedBy;
            room.CreatedDate = dto.CreatedDate;
        }
    }
}
