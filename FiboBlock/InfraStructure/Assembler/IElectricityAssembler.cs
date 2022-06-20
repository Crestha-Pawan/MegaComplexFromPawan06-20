using FiboBlock.Src.Dto;
using FiboInfraStructure.Entity.FiboBlock;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBlock.InfraStructure.Assembler
{
    public interface IElectricityAssembler
    {
        void copyTo(Electricity electricity, ElectricityDto dto);
        void copyFrom(ElectricityDto dto, Electricity electricity);
        void modifyTo(Electricity electricity, ElectricityDto dto);
    }

    public class ElectricityAssembler : IElectricityAssembler
    {
        public void copyFrom(ElectricityDto dto, Electricity electricity)
        {
            dto.Id = electricity.Id;
            dto.CreatedBy = electricity.CreatedBy;
            dto.CreatedDate = electricity.CreatedDate;
            dto.Unit = electricity.Unit;
            dto.Charge = electricity.Charge;
            dto.Status = electricity.Status;
        }

        public void copyTo(Electricity electricity, ElectricityDto dto)
        {
            electricity.CreatedBy = dto.CreatedBy;
            electricity.CreatedDate = DateTime.Now;
            electricity.Unit = dto.Unit;
            electricity.Charge = dto.Charge;
            electricity.Activate();
        }

        public void modifyTo(Electricity electricity, ElectricityDto dto)
        {
            electricity.Id = dto.Id;
            electricity.CreatedBy = dto.CreatedBy;
            electricity.CreatedDate = dto.CreatedDate;
            electricity.ModifiedBy = dto.ModifiedBy;
            electricity.ModifiedDate = DateTime.Now;
            electricity.Unit = dto.Unit;
            electricity.Charge = dto.Charge;
            electricity.Status = dto.Status;

        }
    }
}
