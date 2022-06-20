using FiboInfraStructure.Entity.Payroll;
using Payroll.Src.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.InfraStructure.Assembler
{
    public interface IEmployeeAssembler
    {
        void copyTo(Employee employee, EmployeeDto dto);
        void copyFrom(EmployeeDto dto, Employee employee);
        void modifyTo(Employee employee, EmployeeDto dto);
    }

    public class EmployeeAssembler : IEmployeeAssembler
    {
        //copy to entity(table)
        public void copyTo(Employee employee, EmployeeDto dto)
        {
            employee.CreatedBy = dto.CreatedBy;
            employee.CreatedDate = DateTime.Now;
            employee.Name = dto.Name;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.Email = dto.Email;
            employee.ProvienceId = dto.ProvienceId;
            employee.DistrictId = dto.DistrictId;
            employee.LocalLevelId = dto.LocalLevelId;
            employee.PostId = dto.PostId;
            employee.WardNumber = dto.WardNumber;
            employee.Kosh = dto.Kosh;
            employee.BasicSalary = dto.BasicSalary;
            employee.TDS = dto.TDS;
            employee.Activate();

        }
        //copy from entity(table)
        public void copyFrom(EmployeeDto dto, Employee employee)
        {
            dto.Id = employee.Id;
            dto.CreatedBy = employee.CreatedBy;
            dto.CreatedDate = employee.CreatedDate;
            dto.Name = employee.Name;
            dto.PhoneNumber = employee.PhoneNumber;
            dto.Email = employee.Email;
            dto.Address = employee.Address;
            dto.ProvienceId = employee.ProvienceId;
            dto.DistrictId = employee.DistrictId;
            dto.LocalLevelId = employee.LocalLevelId;
            dto.PostId = employee.PostId;
            dto.Kosh = employee.Kosh;
            dto.BasicSalary = employee.BasicSalary;
            dto.TDS = employee.TDS;
            dto.WardNumber = employee.WardNumber;
            dto.Status = employee.Status;
        }

        //modified to entity(table)
        public void modifyTo(Employee employee, EmployeeDto dto)
        {
            employee.Id = dto.Id;
            employee.CreatedBy = dto.CreatedBy;
            employee.CreatedDate = DateTime.Now;
            employee.ModifiedBy = dto.ModifiedBy;
            employee.ModifiedDate = DateTime.Now;
            employee.Name = dto.Name;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.Email = dto.Email;
            employee.ProvienceId = dto.ProvienceId;
            employee.DistrictId = dto.DistrictId;
            employee.LocalLevelId = dto.LocalLevelId;
            employee.PostId = dto.PostId;
            employee.WardNumber = dto.WardNumber;
            employee.Kosh = dto.Kosh;
            employee.BasicSalary = dto.BasicSalary;
            employee.TDS = dto.TDS;
            employee.Status = dto.Status;
        }
    }
}
