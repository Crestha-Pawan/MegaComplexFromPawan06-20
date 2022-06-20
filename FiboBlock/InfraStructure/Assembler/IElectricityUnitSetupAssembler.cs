using FiboBlock.Src.Dto;
using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.InfraStructure.Assembler
{
    public interface IElectricityUnitSetupAssembler
    {
        void copyTo(ElectricityUnitSetup electricity, ElectricityUnitSetupDto dto);
        void copyFrom(ElectricityUnitSetupDto dto, ElectricityUnitSetup electricity);
        void modifyTo(ElectricityUnitSetup electricity, ElectricityUnitSetupDto dto);
    }

    public class ElectricityUnitSetupAssembler : IElectricityUnitSetupAssembler
    {
        public void copyFrom(ElectricityUnitSetupDto dto, ElectricityUnitSetup electricity)
        {
            dto.Id = electricity.Id;
            dto.CreatedBy = electricity.CreatedBy;
            dto.CreatedDate = electricity.CreatedDate;
           dto.BlockId = electricity.BlockId;
            dto.RoomId = electricity.RoomId;
            dto.ClientId = electricity.ClientId;
            dto.Rate=electricity.Rate;
            dto.PreviousUnit = electricity.PreviousUnit;
            dto.CurrentUnit = electricity.CurrentUnit;
            dto.Amount = electricity.Amount;
            dto.ModifiedDate = electricity.ModifiedDate;
            dto.MonthId = electricity.MonthId;
            dto.YearId = electricity.YearId;
            dto.Unit = electricity.Unit;
        }

        public void copyTo(ElectricityUnitSetup electricity, ElectricityUnitSetupDto dto)
        {
            electricity.CreatedBy = dto.CreatedBy;
            electricity.CreatedDate = DateTime.Now;
            electricity.BlockId = dto.BlockId;
            electricity.ClientId = dto.ClientId;
            electricity.Rate = dto.Rate;
            electricity.RoomId = dto.RoomId;
            electricity.Amount = dto.Amount;
            electricity.CurrentUnit = dto.CurrentUnit;
            electricity.PreviousUnit = dto.PreviousUnit;
            electricity.YearId = dto.YearId;
            electricity.MonthId = dto.MonthId;
            electricity.Unit = dto.Unit;
        }

        public void modifyTo(ElectricityUnitSetup electricity, ElectricityUnitSetupDto dto)
        {
            electricity.Id = dto.Id;
            electricity.CreatedBy = dto.CreatedBy;
            electricity.CreatedDate = dto.CreatedDate;
            electricity.ModifiedBy = dto.ModifiedBy;
            electricity.ModifiedDate = DateTime.Now;
            electricity.BlockId = dto.BlockId;
            electricity.ClientId = dto.ClientId;
            electricity.Rate = dto.Rate;
            electricity.RoomId = dto.RoomId;
            electricity.Amount = dto.Amount;
            electricity.CurrentUnit = dto.CurrentUnit;
            electricity.PreviousUnit = dto.PreviousUnit;
            electricity.YearId = dto.YearId;
            electricity.MonthId = dto.MonthId;
            electricity.Unit = dto.Unit;
        }
    }
}
