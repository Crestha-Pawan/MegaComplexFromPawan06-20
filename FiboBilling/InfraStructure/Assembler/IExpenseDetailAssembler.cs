
using FiboBilling.Src.Dto;
using FiboInfraStructure.Entity.FiboBilling;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBilling.InfraStructure.Assembler
{
    public interface IExpenseDetailAssembler
    {
        void copyTo(ExpenseDetail detail, ExpenseDetailDto dto);
        void copyFrom(ExpenseDetailDto dto, ExpenseDetail detail);
        void modifyTo(ExpenseDetail detail, ExpenseDetailDto dto);
    }

    public class ExpenseDetailAssembler : IExpenseDetailAssembler
    {
        public void copyFrom(ExpenseDetailDto dto, ExpenseDetail detail)
        {
            dto.Id = detail.Id;
            dto.ExpenseId = detail.ExpenseId;
            dto.Rate = detail.Rate;
            dto.Quantity = detail.Quantity;
            dto.Amount = detail.Amount;
            dto.CreatedBy = detail.CreatedBy;
            dto.CreatedDate = detail.CreatedDate;
            dto.ModifiedBy = detail.ModifiedBy;
            dto.ModifiedDate = detail.ModifiedDate;
            dto.Name = detail.Name;
        }

        public void copyTo(ExpenseDetail detail, ExpenseDetailDto dto)
        {
            detail.ExpenseId = dto.ExpenseId;
            detail.Rate = dto.Rate;
            detail.Quantity = dto.Quantity;
            detail.Amount = dto.Amount;
            detail.CreatedBy = dto.CreatedBy;
            detail.CreatedDate = dto.CreatedDate;
            detail.ModifiedBy = dto.ModifiedBy;
            detail.ModifiedDate = dto.ModifiedDate;
            detail.Name = dto.Name;
        }

        public void modifyTo(ExpenseDetail detail, ExpenseDetailDto dto)
        {
            detail.Id = dto.Id;
            detail.ExpenseId = dto.ExpenseId;
            detail.Rate = dto.Rate;
            detail.Quantity = dto.Quantity;
            detail.Amount = dto.Amount;
            detail.CreatedBy = dto.CreatedBy;
            detail.CreatedDate = dto.CreatedDate;
            detail.ModifiedBy = dto.ModifiedBy;
            detail.ModifiedDate = dto.ModifiedDate;
            detail.Name = dto.Name;
        }
    }
}
