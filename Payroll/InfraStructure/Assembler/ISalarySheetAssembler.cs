using FiboInfraStructure.Entity.Payroll;
using Payroll.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.InfraStructure.Assembler
{
    public interface ISalarySheetAssembler
    {
        void copyTo(SalarySheet salarySheet, SalarySheetDto dto);
        void copyFrom(SalarySheetDto dto, SalarySheet salarySheet);
        void modifyTo(SalarySheet salarySheet, SalarySheetDto dto);
    }

    public class SalarySheetAssembler : ISalarySheetAssembler
    {
        //copy to entity(table)
        public void copyTo(SalarySheet salarySheet, SalarySheetDto dto)
        {
            salarySheet.CreatedBy = dto.CreatedBy;
            salarySheet.CreatedDate = DateTime.Now;
            salarySheet.EmployeeId = dto.EmployeeId;
            salarySheet.PostId = dto.PostId;
            salarySheet.Deduction = dto.Deduction;
            salarySheet.Tax = dto.Tax;
            salarySheet.Bonus = dto.Bonus;
            salarySheet.DueDate = dto.DueDate;
            salarySheet.AdvanceSalary = dto.AdvanceSalary;
            salarySheet.AdvanceSalaryDate = dto.AdvanceSalaryDate;
            salarySheet.BasicSalary = dto.BasicSalary;
            salarySheet.Tds = dto.Tds;
            salarySheet.Kosh = dto.Kosh;
            salarySheet.PartiallyDeducted = dto.PartiallyDeducted;
            salarySheet.IsAdvance = dto.IsAdvance;
            salarySheet.NetSalary = dto.NetSalary;
            salarySheet.Housing = dto.Housing;
            salarySheet.TravelAllowance = dto.TravelAllowance;
            salarySheet.SpecialAllowance = dto.SpecialAllowance;
            salarySheet.TelephoneAllowance = dto.TelephoneAllowance;
            salarySheet.OvertimeAllowance = dto.OvertimeAllowance;
            salarySheet.Loan = dto.Loan;

        }
        //copy from entity(table)
        public void copyFrom(SalarySheetDto dto, SalarySheet salarySheet)
        {
            dto.CreatedBy = salarySheet.CreatedBy;
            dto.CreatedDate = salarySheet.CreatedDate;
            dto.Id = salarySheet.Id;
            dto.EmployeeId = salarySheet.EmployeeId;
            dto.PostId = salarySheet.PostId;
            dto.DueDate = salarySheet.DueDate;
            dto.Deduction = salarySheet.Deduction;
            dto.Tax = salarySheet.Tax;
            dto.Bonus = salarySheet.Bonus;
            dto.AdvanceSalary = salarySheet.AdvanceSalary;
            dto.AdvanceSalaryDate = salarySheet .AdvanceSalaryDate;
            dto.BasicSalary = salarySheet.BasicSalary;
            dto.Tds = salarySheet.Tds;
            dto.Kosh = salarySheet.Kosh;
            dto.PartiallyDeducted = salarySheet.PartiallyDeducted;
            dto.IsAdvance = salarySheet.IsAdvance;
            dto.NetSalary = salarySheet.NetSalary;
            dto.Housing = salarySheet.Housing;
            dto.TravelAllowance = salarySheet.TravelAllowance;
            dto.SpecialAllowance = salarySheet.SpecialAllowance;
            dto.TelephoneAllowance = salarySheet.TelephoneAllowance;
            dto.OvertimeAllowance = salarySheet.OvertimeAllowance;
            dto.Loan = salarySheet.Loan;
        }

        //modified to entity(table)
        public void modifyTo(SalarySheet salarySheet, SalarySheetDto dto)
        {
            salarySheet.Id = dto.Id;
            salarySheet.CreatedBy = dto.CreatedBy;
            salarySheet.CreatedDate = dto.CreatedDate;
            salarySheet.ModifiedBy = dto.ModifiedBy;
            salarySheet.ModifiedDate = DateTime.Now;
            salarySheet.EmployeeId = dto.EmployeeId;
            salarySheet.PostId = dto.PostId;
            salarySheet.Deduction = dto.Deduction;
            salarySheet.Tax = dto.Tax;
            salarySheet.DueDate = dto.DueDate;
            salarySheet.Bonus = dto.Bonus;
            salarySheet.AdvanceSalary = dto.AdvanceSalary;
            salarySheet.AdvanceSalaryDate = dto.AdvanceSalaryDate;
            salarySheet.BasicSalary = dto.BasicSalary;
            salarySheet.Tds = dto.Tds;
            salarySheet.Kosh = dto.Kosh;
            salarySheet.PartiallyDeducted = dto.PartiallyDeducted;
            salarySheet.IsAdvance = dto.IsAdvance;
            salarySheet.NetSalary = dto.NetSalary;
            salarySheet.Housing = dto.Housing;
            salarySheet.TravelAllowance = dto.TravelAllowance;
            salarySheet.SpecialAllowance = dto.SpecialAllowance;
            salarySheet.TelephoneAllowance = dto.TelephoneAllowance;
            salarySheet.OvertimeAllowance = dto.OvertimeAllowance;
            salarySheet.Loan = dto.Loan;
        }
    }
}
