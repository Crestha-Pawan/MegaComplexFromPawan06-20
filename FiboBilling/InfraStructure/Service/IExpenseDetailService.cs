using FiboBilling.InfraStructure.Assembler;
using FiboBilling.InfraStructure.Repository;
using FiboBilling.Src.Dto;
using FiboInfraStructure.Entity.FiboBilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboBilling.InfraStructure.Service
{
    public interface IExpenseDetailService
    {
        Task<ExpenseDetailDto> InsertAsync(ExpenseDetailDto dto);
        Task<ExpenseDetail> Delete(long Id);
        Task<List<ExpenseDetailDto>> InsertAndDelete(List<ExpenseDetailDto> dto);
    }
    public class ExpenseDetailService : IExpenseDetailService
    {
        private readonly IExpenseDetailRepository _repository;
        private readonly IExpenseDetailAssembler _assembler;

        public ExpenseDetailService(IExpenseDetailRepository repository, IExpenseDetailAssembler assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }
        public async Task<ExpenseDetail> Delete(long Id)
        {
            var detail = await _repository.GetByIdAsync(Id) ?? throw new Exception();
            return await _repository.DeleteAsync(detail).ConfigureAwait(true);
        }

        public async Task<List<ExpenseDetailDto>> InsertAndDelete(List<ExpenseDetailDto> dtos)
        {
            var details = await _repository.GetAllExpenseDetailById(dtos.First().ExpenseId.Value);
            if (details.Count > 0)
            {
                foreach (var detail in details)
                {
                    await Delete(detail.Id);
                }
            }

            foreach (var dto in dtos)
            {
                await InsertAsync(dto);
            }
            return dtos;
        }

        public async Task<ExpenseDetailDto> InsertAsync(ExpenseDetailDto dto)
        {
            ExpenseDetail detail = new ExpenseDetail();
            _assembler.copyTo(detail, dto);
            await _repository.AddSync(detail).ConfigureAwait(true);
            return dto;
        }
    }
}
