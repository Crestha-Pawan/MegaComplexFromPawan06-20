using FiboInfraStructure.Entity.Payroll;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Src.ViewModel
{
    public class EmployeeViewModel
    {
        public string Status { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public string Name { get; set; }
        public long? EmployeeId { get; set; }
        public IList<Employee> Employeelist { get; set; } = new List<Employee>();
        public SelectList EmployeeSelectlist => new SelectList(Employeelist, nameof(Employee.Id), nameof(Employee.Name));
    }
}
