using FiboBilling.Src.Dto;
using FiboInfraStructure.Entity.FiboBilling;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBilling.InfraStructure.Assembler
{
    public interface IBillingDetailAssembler
    {
        void copyTo(BillingDetail billing, BillingDetailDto dto);
        void copyFrom(BillingDetailDto dto, BillingDetail billing);
        void modifyTo(BillingDetail billing, BillingDetailDto dto);
    }
    public class BillingDetailAssembler : IBillingDetailAssembler
    {
        public void copyFrom(BillingDetailDto dto, BillingDetail billing)
        {
            dto.Id = billing.Id;
            dto.CreatedBy = billing.CreatedBy;
            dto.CreatedDate = billing.CreatedDate;
            dto.ModifiedBy = dto.ModifiedBy;
            dto.ModifiedDate = dto.ModifiedDate;
            dto.BillingId = billing.BillingId;
            dto.ElectricityBillAmount = billing.ElectricityBillAmount;
            dto.ElectricityUnit = billing.ElectricityUnit;
            dto.RentAmount = billing.RentAmount;
            dto.YearId = billing.YearId;
            dto.MonthId = billing.MonthId;
            dto.BlockId = billing.BlockId;
            dto.RoomId = billing.RoomId;
            //dto.Debit = billing.Debit;
            //dto.Credit = billing.Credit;
            dto.Remarks = billing.Remarks;
            dto.Total = billing.Total;

        }

        public void copyTo(BillingDetail billing, BillingDetailDto dto)
        {
            billing.CreatedBy = dto.CreatedBy;
            billing.CreatedDate = DateTime.Now;
            billing.BillingId = dto.BillingId;
            billing.ElectricityBillAmount = dto.ElectricityBillAmount;
            billing.ElectricityUnit = dto.ElectricityUnit;
            billing.RentAmount = dto.RentAmount;
            billing.YearId = dto.YearId;
            billing.MonthId = dto.MonthId;
            billing.BlockId = dto.BlockId;
            billing.RoomId = dto.RoomId;
            //billing.Debit = dto.Debit;
            //billing.Credit = dto.Credit;
            billing.Remarks = dto.Remarks;
            billing.Total = dto.Total;
        }

        public void modifyTo(BillingDetail billing, BillingDetailDto dto)
        {
            billing.Id = dto.Id;
            billing.CreatedBy = dto.CreatedBy;
            billing.CreatedDate = dto.CreatedDate;
            billing.ModifiedBy = dto.ModifiedBy;
            billing.ModifiedDate = DateTime.Now;
            billing.BillingId = dto.BillingId;
            billing.ElectricityBillAmount = dto.ElectricityBillAmount;
            billing.ElectricityUnit = dto.ElectricityUnit;
            billing.RentAmount = dto.RentAmount;
            billing.YearId = dto.YearId;
            billing.MonthId = dto.MonthId;
            billing.BlockId = dto.BlockId;
            billing.RoomId = dto.RoomId;
            //billing.Debit = dto.Debit;
            //billing.Credit = dto.Credit;
            billing.Remarks = dto.Remarks;
            billing.Total = dto.Total;
        }
    }
}
