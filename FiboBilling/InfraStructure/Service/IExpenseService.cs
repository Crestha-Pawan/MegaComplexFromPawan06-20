
using FiboBilling.InfraStructure.Assembler;
using FiboBilling.InfraStructure.Repository;
using FiboBilling.Src.Dto;
using FiboInfraStructure.Entity.FiboBilling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiboBilling.InfraStructure.Service
{
    public interface IExpenseService
    {
        Task<ExpenseDto> InsertAsync(ExpenseDto dto);
        Task<Expense> Delete(long Id);
        Task<BillingDto> UpdateAsync(ExpenseDto dto);
    }
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        private readonly IExpenseAssembler _assembler;
        private readonly IExpenseDetailService _service;
        public ExpenseService(IExpenseRepository repository,IExpenseAssembler assembler,IExpenseDetailService service)
        {
            _repository = repository;
            _assembler = assembler;
            _service = service;
        }
        public async Task<Expense> Delete(long Id)
        {
            var expense = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(expense).ConfigureAwait(true);
        }

        public async Task<ExpenseDto> InsertAsync(ExpenseDto dto)
        {
            Expense expense = new Expense();
            _assembler.copyTo(expense, dto);
            await _repository.AddSync(expense);

            if (dto.ExpenseDetailDtos.Count > 0)
            {
                foreach(var detail_dto in dto.ExpenseDetailDtos)
                {
                    detail_dto.ExpenseId = expense.Id;
                }
                await _service.InsertAndDelete(dto.ExpenseDetailDtos);
            }
            return dto;
        }

        public Task<BillingDto> UpdateAsync(ExpenseDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
