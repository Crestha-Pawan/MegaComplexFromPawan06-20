using FiboAddress.InfraStructure.Repository;
using FiboInfraStructure.Entity;
using FiboInfraStructure.Entity.Payroll;
using Payroll.InfraStructure.Assembler;
using Payroll.InfraStructure.Repository;
using Payroll.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.InfraStructure.Service
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> Insertasync(EmployeeDto dto);
        Task<Employee> Delete(long Id);
        Task<Employee> ToggleStatus(Employee emp);
        Task<EmployeeDto> UpdateAsync(EmployeeDto dto);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeAssembler _assembler;
        private readonly ILocalLevelRepository _localRepository;
        private readonly IDistrictRepository _districtRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeAssembler assembler,
            ILocalLevelRepository localRepository, IDistrictRepository districtRepository)
        {
            _employeeRepository = employeeRepository;
            _assembler = assembler;
            _localRepository = localRepository;
            _districtRepository = districtRepository;
        }
        public async Task<EmployeeDto> Insertasync(EmployeeDto dto)
        {
            Employee employee = new Employee();
            _assembler.copyTo(employee, dto);
            await setAddress(dto.LocalLevelId.Value, dto.DistrictId.Value, employee);
            await _employeeRepository.AddSync(employee);
            dto.Id = employee.Id;
            return dto;
        }

        public async Task<EmployeeDto> UpdateAsync(EmployeeDto dto)
        {
            Employee employee = new Employee();
            _assembler.modifyTo(employee, dto);
            await setAddress(dto.LocalLevelId.Value, dto.DistrictId.Value, employee);
            await _employeeRepository.UpdateAsync(employee);
            return dto;
        }

        public async Task<Employee> Delete(long Id)
        {
            var employee = await _employeeRepository.GetByIdAsync(Id) ?? throw new Exception();
            return await _employeeRepository.DeleteAsync(employee).ConfigureAwait(true);
        }

        public async Task<Employee> ToggleStatus(Employee emp)
        {
            if (emp != null)
            {
                emp.ChangeStatus();
            }
            return await _employeeRepository.UpdateAsync(emp).ConfigureAwait(true);
        }

        private async Task<string> setAddress(long LocalLevelId, long DistrictId, Employee employee)
        {
            string address = string.Empty;
            var local = await _localRepository.GetByIdAsync(LocalLevelId);
            var district = await _districtRepository.GetByIdAsync(DistrictId);
            if (local != null && district != null)
            {
                address = employee.setAddress(local, district);
            }
            return address;
        }
    }
}
