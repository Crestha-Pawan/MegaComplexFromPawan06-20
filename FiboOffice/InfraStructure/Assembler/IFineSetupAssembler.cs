using FiboInfraStructure.Entity.FiboOffice;
using FiboOffice.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboOffice.InfraStructure.Assembler
{
    public interface IFineSetupAssembler
    {
        void copyTo(FineSetup fineSetup, FineSetupDto dto);
        void copyFrom(FineSetupDto dto, FineSetup fineSetup);
        void modifyTo(FineSetup fineSetup, FineSetupDto dto);
    }

    public class FineSetupAssembler : IFineSetupAssembler
    {
        //copy to entity(table)
        public void copyTo(FineSetup fineSetup, FineSetupDto dto)
        {
            fineSetup.CreatedBy = dto.CreatedBy;
            fineSetup.CreatedDate = DateTime.Now;
            fineSetup.StartDay = dto.StartDay;
            fineSetup.EndDay = dto.EndDay;
            //office.ProvienceId = dto.ProvienceId;
            //office.DistrictId = dto.DistrictId;
            //office.LocalLevelId = dto.LocalLevelId;
            fineSetup.FinePercent = dto.FinePercent;
            

        }
        //copy from entity(table)
        public void copyFrom(FineSetupDto dto, FineSetup fineSetup)
        {
            dto.Id = fineSetup.Id;
            dto.CreatedBy = fineSetup.CreatedBy;
            dto.CreatedDate = fineSetup.CreatedDate;
            dto.StartDay = fineSetup.StartDay;
            dto.EndDay = fineSetup.EndDay;
            dto.FinePercent = fineSetup.FinePercent;
            //dto.ProvienceId = office.ProvienceId;
            //dto.DistrictId = office.DistrictId;
            //dto.LocalLevelId = office.LocalLevelId;
            

        }

        //modified to entity(table)
        public void modifyTo(FineSetup fineSetup, FineSetupDto dto)
        {
            fineSetup.Id = dto.Id;
            fineSetup.CreatedBy = dto.CreatedBy;
            fineSetup.CreatedDate = DateTime.Now;
            fineSetup.ModifiedBy = dto.ModifiedBy;
            fineSetup.ModifiedDate = DateTime.Now;
            fineSetup.StartDay = dto.StartDay;
            fineSetup.EndDay = dto.EndDay;
            fineSetup.FinePercent = dto.FinePercent;
            //office.ProvienceId = dto.ProvienceId;
            //office.DistrictId = dto.DistrictId;
            //office.LocalLevelId = dto.LocalLevelId;
            
        }
    }
}
