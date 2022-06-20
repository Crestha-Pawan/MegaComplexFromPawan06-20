using FiboInfraStructure.Entity.Payroll;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Src.Dto
{
   public class SalarySheetDto:BaseDto
    {

        public decimal Bonus { get; set; }
        public string Housing { get; set; }
        public string TravelAllowance { get; set; }
        public string SpecialAllowance { get; set; }
        public string TelephoneAllowance { get; set; }
        public string OvertimeAllowance { get; set; }
        public string Loan { get; set; }
        public decimal NetSalary { get; set; }
        public decimal Tax { get; set; }
        public decimal Deduction { get; set; }
        public string Tds { get; set; }
        public string Kosh { get; set; }
        public decimal BasicSalary { get; set; }
        public string AdvanceSalary { get; set; }
        public string AdvanceSalaryDate { get; set; }
        public string DueDate { get; set; }
        public string PartiallyDeducted { get; set; }
        public bool IsAdvance { get; set; }

        [ForeignKey("ID")]
        public long? EmployeeId { get; set; }
        [NotMapped()]
        public virtual Employee Employee { get; set; }
        [ForeignKey("ID")]
        public long? PostId { get; set; }
        [NotMapped()]
        public virtual Post Post { get; set; }
        public IList<Post> Posts { get; set; } = new List<Post>();
        public SelectList PostList => new SelectList(Posts, nameof(Post.Id), nameof(Post.Name));

        public IList<Employee> Employees { get; set; } = new List<Employee>();
        public SelectList EmployeeList => new SelectList(Employees, nameof(Employee.Id), nameof(Employee.Name));
    }
}
