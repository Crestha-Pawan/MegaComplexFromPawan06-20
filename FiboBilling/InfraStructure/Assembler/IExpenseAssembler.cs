
using System;
using System.Collections.Generic;
using System.Text;
using FiboBilling.Src.Dto;
using FiboInfraStructure;
using FiboInfraStructure.Entity.FiboBilling;

namespace FiboBilling.InfraStructure.Assembler
{
    public interface IExpenseAssembler
    {
        void copyTo(Expense expense, ExpenseDto dto);
        void copyFrom(ExpenseDto dto, Expense expense);
        void modifyTo(Expense expense, ExpenseDto dto);
    }

    public class ExpenseAssembler : IExpenseAssembler
    {
        public void copyFrom(ExpenseDto dto, Expense expense)
        {
            dto.Id = expense.Id;
            dto.Amount = expense.Amount;
            dto.CreatedBy = expense.CreatedBy;
            dto.CreatedDate = expense.CreatedDate;
            dto.Date = expense.Miti.ToEnglishDate();
            dto.Miti = expense.Miti;
            dto.ModifiedBy = expense.ModifiedBy;
            dto.ModifiedDate = expense.ModifiedDate;
            dto.Name = expense.Name;
            dto.IsExpense = expense.IsExpense;
        }

        public void copyTo(Expense expense, ExpenseDto dto)
        {
            expense.Amount = dto.Amount;
            expense.CreatedBy = dto.CreatedBy;
            expense.CreatedDate = DateTime.Now;
            expense.Date = dto.Miti.ToEnglishDate();
            expense.Miti = dto.Miti;
            expense.Name = dto.Name;
            expense.IsExpense = dto.IsExpense;
        }

        public void modifyTo(Expense expense, ExpenseDto dto)
        {
            expense.Id = dto.Id;
            expense.Amount = dto.Amount;
            expense.CreatedBy = dto.CreatedBy;
            expense.CreatedDate = dto.CreatedDate;
            expense.Date = dto.Miti.ToEnglishDate();
            expense.Miti = dto.Miti;
            expense.ModifiedBy = dto.ModifiedBy;
            expense.ModifiedDate = DateTime.Now;
            expense.Name = dto.Name;
            expense.IsExpense = dto.IsExpense;
        }
    }
}
