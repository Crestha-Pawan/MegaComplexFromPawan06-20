using FiboInfraStructure.Entity.FiboParty;
using FiboInfraStructure.Entity.Ledger;
using FiboParty.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboParty.Infrastructure.Assembler
{
    public interface ILedgerAssembler
    {
        void copyTo(Ledger ledger, LedgerDto dto);
        void copyFrom(LedgerDto dto, Ledger ledger);
        void modifyTo(Ledger ledger, LedgerDto dto);
    }
    public class LedgerAssembler : ILedgerAssembler
    {
        //copy to entity(table)
        public void copyTo(Ledger ledger, LedgerDto dto)
        {
            ledger.CreatedBy = dto.CreatedBy;
            ledger.CreatedDate = DateTime.Now;
            ledger.PartyId = dto.PartyId;
            ledger.BalanceAmount = dto.BalanceAmount;
            ledger.Credit = dto.Credit;
            ledger.Debit = dto.Debit;
            ledger.PartiesType = dto.PartiesType;
            ledger.Address = dto.Address;
            ledger.FiscalYearId = dto.FiscalYearId;
        }
        //copy from entity(table)
        public void copyFrom(LedgerDto dto, Ledger ledger)
        {
            dto.Id = ledger.Id;
            dto.CreatedBy = ledger.CreatedBy;
            dto.CreatedDate = ledger.CreatedDate;
            dto.PartyId = ledger.PartyId;
            dto.BalanceAmount = ledger.BalanceAmount;
            dto.PartiesType = ledger.PartiesType;
            dto.Credit = ledger.Credit;
            dto.Debit = ledger.Debit;
            dto.Address = ledger.Address;
            dto.FiscalYearId = ledger.FiscalYearId;
        }

        //modified to entity(table)
        public void modifyTo(Ledger ledger, LedgerDto dto)
        {
            ledger.Id = dto.Id;
            ledger.CreatedBy = dto.CreatedBy;
            ledger.CreatedDate = dto.CreatedDate;
            ledger.ModifiedDate = DateTime.Now;
            ledger.PartyId = dto.PartyId;
            ledger.PartiesType = dto.PartiesType;
            ledger.BalanceAmount = dto.BalanceAmount;
            ledger.Credit = dto.Credit;
            ledger.Debit = dto.Debit;
            ledger.Address = dto.Address;
            ledger.FiscalYearId = dto.FiscalYearId;
        }
    }
}

