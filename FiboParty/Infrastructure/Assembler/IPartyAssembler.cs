using FiboInfraStructure.Entity.FiboParty;
using FiboParty.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboParty.Infrastructure.Assembler
{
    public interface IPartyAssembler
    {
        void copyTo(Party party, PartyDto dto);
        void copyFrom(PartyDto dto, Party party);
        void modifyTo(Party party, PartyDto dto);
    }
    public class PartyAssembler : IPartyAssembler
    {
        //copy to entity(table)
        public void copyTo(Party party, PartyDto dto)
        {
            party.CreatedBy = dto.CreatedBy;
            party.CreatedDate = DateTime.Now;
            party.Name = dto.Name;
            party.Address = dto.Address;
            party.ContactNumber = dto.ContactNumber;
            party.ProvienceId = dto.ProvienceId;
            party.DistrictId = dto.DistrictId;
            party.LocalLevelId = dto.LocalLevelId;
            party.Email = dto.Email;
            party.CreditLimit = dto.CreditLimit;
            party.CreditLimitDay = dto.CreditLimitDay;
            party.PartiesType = dto.PartiesType;
            party.PartiesCreatedDate = DateTime.Now;
            party.WardNumber = dto.WardNumber;
            party.Credit = dto.Credit;
            party.Debit = dto.Debit;
            party.BillNumber = dto.BillNumber;
        }
        //copy from entity(table)
        public void copyFrom(PartyDto dto, Party party)
        {
            dto.CreatedBy = party.CreatedBy;
            dto.CreatedDate = party.CreatedDate;
            dto.Name = party.Name;
            dto.Address = party.Address;
            dto.ContactNumber = party.ContactNumber; 
            dto.ProvienceId = party.ProvienceId;
            dto.DistrictId = party.DistrictId;
            dto.LocalLevelId = party.LocalLevelId;
            dto.Email = party.Email;
            dto.CreditLimit = party.CreditLimit;
            dto.CreditLimitDay = party.CreditLimitDay;
            dto.PartiesType = party.PartiesType;
            dto.CreatedDate = party.CreatedDate;
            dto.PartiesCreatedDate = DateTime.Now.ToString();
            dto.WardNumber = party.WardNumber;
            dto.Credit = party.Credit;
            dto.Debit = party.Debit;
            dto.BillNumber = party.BillNumber;
            dto.Remarks = party.Remarks;

        }

        //modified to entity(table)
        public void modifyTo(Party party, PartyDto dto)
        {
            party.Id = dto.Id;
            party.CreatedBy = dto.CreatedBy;
            party.CreatedDate = DateTime.Now;
            party.Name = dto.Name;
            party.Address = dto.Address;
            party.ContactNumber = dto.ContactNumber;
            party.ModifiedBy = dto.ModifiedBy;
            party.ModifiedDate = DateTime.Now;
            party.ProvienceId = dto.ProvienceId;
            party.DistrictId = dto.DistrictId;
            party.LocalLevelId = dto.LocalLevelId;
            party.Email = dto.Email;
            party.CreditLimit = dto.CreditLimit;
            party.CreditLimitDay = dto.CreditLimitDay;
            party.PartiesType = dto.PartiesType;
            party.PartiesCreatedDate = DateTime.Now;
            party.WardNumber = dto.WardNumber;
            party.Credit = dto.Credit;
            party.Debit = dto.Debit;
            party.Remarks = dto.Remarks;
            party.BillNumber = dto.BillNumber;

        }
    }
}

