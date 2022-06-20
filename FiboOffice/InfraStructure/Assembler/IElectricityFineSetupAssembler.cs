using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboOffice.InfraStructure.Assembler
{
    
    public interface IElectricityFineSetupAssembler
    {
        void copyTo(ElectricityFineSetup fineSetup, ElectricityFineSetupDto dto);
        void copyFrom(ElectricityFineSetupDto dto, ElectricityFineSetup fineSetup);
        void modifyTo(ElectricityFineSetup fineSetup, ElectricityFineSetupDto dto);
    }

    public class ElectricityFineSetupAssembler : IElectricityFineSetupAssembler
    {
        public void copyFrom(ElectricityFineSetupDto dto, ElectricityFineSetup fineSetup)
        {
            dto.Id = fineSetup.Id;
            dto.CreatedBy = fineSetup.CreatedBy;
            dto.CreatedDate = fineSetup.CreatedDate;
            dto.StartDay = fineSetup.StartDay;
            dto.EndDay = fineSetup.EndDay;
            dto.FinePercent = fineSetup.FinePercent;
        }

        public void copyTo(ElectricityFineSetup fineSetup, ElectricityFineSetupDto dto)
        {
            fineSetup.CreatedBy = dto.CreatedBy;
            fineSetup.CreatedDate = DateTime.Now;
            fineSetup.StartDay = dto.StartDay;
            fineSetup.EndDay = dto.EndDay;
            fineSetup.FinePercent = dto.FinePercent;
        }

        public void modifyTo(ElectricityFineSetup fineSetup, ElectricityFineSetupDto dto)
        {
            fineSetup.Id = dto.Id;
            fineSetup.CreatedBy = dto.CreatedBy;
            fineSetup.CreatedDate = DateTime.Now;
            fineSetup.ModifiedBy = dto.ModifiedBy;
            fineSetup.ModifiedDate = DateTime.Now;
            fineSetup.StartDay = dto.StartDay;
            fineSetup.EndDay = dto.EndDay;
            fineSetup.FinePercent = dto.FinePercent;
        }
    }
}
