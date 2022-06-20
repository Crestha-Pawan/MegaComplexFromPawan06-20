using FiboInfraStructure.Entity.FiboAddress;
using FiboInfraStructure.Entity.Payroll;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Src.Dto
{
    public class EmployeeDto: BaseDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public long? ProvienceId { get; set; }
        public long? DistrictId { get; set; }
        public long? LocalLevelId { get; set; }
        public long? PostId { get; set; }
        public string Status { get; set; }
        public string WardNumber { get; set; }
        public string Address { get; set; }
        public string Kosh { get; set; }
        public string BasicSalary { get; set; }
        public string TDS { get; set; }
        public IList<Provience> Proviences { get; set; } = new List<Provience>();
        public SelectList ProvienceList => new SelectList(Proviences, nameof(Provience.Id), nameof(Provience.Name));
        public IList<District> Districts { get; set; } = new List<District>();
        public SelectList DistrictList => new SelectList(Districts, nameof(District.Id), nameof(District.Name));
        public IList<LocalLevel> LocalLevels { get; set; } = new List<LocalLevel>();
        public SelectList LocalLevelList => new SelectList(LocalLevels, nameof(LocalLevel.Id), nameof(LocalLevel.Name));
        public IList<Post> Posts { get; set; } = new List<Post>();
        public SelectList PostList => new SelectList(Posts, nameof(Post.Id), nameof(Post.Name));

        public IList<Employee> Employees { get; set; } = new List<Employee>();
        public SelectList EmployeeList => new SelectList(Employees, nameof(Employee.Id), nameof(Employee.Name));
    }
}
