using FiboInfraStructure.Entity.Payroll;
using Payroll.InfraStructure.Assembler;
using Payroll.InfraStructure.Repository;
using Payroll.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.InfraStructure.Service
{
    public interface ISalarySheetService
    {
        Task<SalarySheetDto> Insertasync(SalarySheetDto dto);
        Task<SalarySheet> Delete(long Id);
        Task<SalarySheetDto> UpdateAsync(SalarySheetDto dto);
    }
    public class SalarySheetService : ISalarySheetService
    {
        private readonly ISalarySheetRepository _salarySheetRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPostRepository _postRepository;
        private readonly ISalarySheetAssembler _assembler;
        public SalarySheetService(ISalarySheetRepository salarySheetRepository, ISalarySheetAssembler assembler,IPostRepository postRepository,IEmployeeRepository employeeRepository)
        {
            _salarySheetRepository = salarySheetRepository;
            _employeeRepository = employeeRepository;
            _postRepository = postRepository;
            _assembler = assembler;
        }
        public async Task<SalarySheetDto> Insertasync(SalarySheetDto dto)
        {
            SalarySheet salarySheet = new SalarySheet();
            _assembler.copyTo(salarySheet, dto);
            await _salarySheetRepository.AddSync(salarySheet);
            dto.Id = salarySheet.Id;            
            return dto;
        }

        public async Task<SalarySheetDto> UpdateAsync(SalarySheetDto dto)
        {
            SalarySheet salarySheet = new SalarySheet();
            _assembler.modifyTo(salarySheet, dto);
            await _salarySheetRepository.UpdateAsync(salarySheet);
            return dto;
        }

        public async Task<SalarySheet> Delete(long Id)
        {
            var salarySheet = await _salarySheetRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _salarySheetRepository.DeleteAsync(salarySheet).ConfigureAwait(true);
        }
    }
}
