using FiboInfraStructure.Entity.FiboParty;
using FiboInfraStructure.Entity.Ledger;
using FiboParty.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using FiboInfraStructure;

namespace FiboParty.Infrastructure.Assembler
{
    public interface ILedgerDetailAssembler
    {
        void copyTo(LedgerDetail ledgerDetail, LedgerDetailDto dto);
        void copyFrom(LedgerDetailDto dto, LedgerDetail ledgerDetail);
        void modifyTo(LedgerDetail ledgerDetail, LedgerDetailDto dto);
    }
    public class LedgerDetailAssembler : ILedgerDetailAssembler
    {
        //copy to entity(table)
        public void copyTo(LedgerDetail ledgerDetail, LedgerDetailDto dto)
        {
            ledgerDetail.CreatedDate = DateTime.Now;
            ledgerDetail.CreatedBy = dto.CreatedBy;
            ledgerDetail.BillNo = dto.BillNo;
            ledgerDetail.CreditAmount = dto.CreditAmount;
            ledgerDetail.DebitAmount = dto.DebitAmount;
            ledgerDetail.Remarks = dto.Remarks;
            ledgerDetail.LedgerId = dto.LedgerId;
            ledgerDetail.PartyId = dto.PartyId;
            ledgerDetail.Date = dto.Date.ToEnglishDate();
        }
        //copy from entity(table)
        public void copyFrom(LedgerDetailDto dto, LedgerDetail ledgerDetail)
        {

            dto.CreatedBy = ledgerDetail.CreatedBy;
            dto.CreatedDate = DateTime.Now;
            dto.BillNo = ledgerDetail.BillNo;
            dto.CreditAmount = ledgerDetail.CreditAmount;
            dto.DebitAmount = ledgerDetail.DebitAmount;
            dto.Remarks = ledgerDetail.Remarks;
            dto.LedgerId = ledgerDetail.LedgerId;
            dto.PartyId = ledgerDetail.PartyId;
            dto.Date = ledgerDetail.Date.ToNepDate();
        }

        //modified to entity(table)
        public void modifyTo(LedgerDetail ledgerDetail, LedgerDetailDto dto)
        {
            ledgerDetail.Id = dto.Id;
            ledgerDetail.CreatedBy = dto.CreatedBy;
            ledgerDetail.CreatedDate = dto.CreatedDate;
            ledgerDetail.ModifiedBy = dto.ModifiedBy;
            ledgerDetail.ModifiedDate = DateTime.Now.Date;
            ledgerDetail.BillNo = dto.BillNo;
            ledgerDetail.CreditAmount = dto.CreditAmount;
            ledgerDetail.DebitAmount = dto.DebitAmount;
            ledgerDetail.Remarks = dto.Remarks;
            ledgerDetail.LedgerId = dto.LedgerId;
            ledgerDetail.PartyId = dto.PartyId;
            ledgerDetail.Date = dto.Date.ToEnglishDate();
        }
    }
}

