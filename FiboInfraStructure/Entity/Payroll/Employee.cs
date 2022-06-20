using FiboInfraStructure.Entity.FiboAddress;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.Payroll
{
    public class Employee : BaseEntity
    {
        private readonly string StatusActive = "Active";
        private readonly string StatusInactive = "Inactive";

        public bool IsActive()
        {
            return Status == StatusActive;
        }

        public bool IsInactive()
        {
            return Status == StatusInactive;
        }

        public void Activate()
        {
            Status = StatusActive;
        }

        public void Deactive()
        {
            Status = StatusInactive;
        }

        public void ChangeStatus()
        {
            if (IsActive())
            {
                Deactive();
            }
            else
            {
                Activate();
            }
        }
        public string setAddress(LocalLevel local, District district)
        {
            return Address = local.Name + "-" + WardNumber + ", " + district.Name;
        }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [ForeignKey("ProvienceId")]
        public long? ProvienceId { get; set; }

        [ForeignKey("DistrictId")]
        public long? DistrictId { get; set; }

        [ForeignKey("LocalLevelId")]
        public long? LocalLevelId { get; set; }

        [ForeignKey("PostId")]
        public long? PostId { get; set; }
      
        public string WardNumber { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Kosh { get; set;}
        public string BasicSalary { get; set;}
        public string TDS { get; set; }

        public virtual Provience Provience { get; set; }
        public virtual District District { get; set; }
        public virtual LocalLevel LocalLevel { get; set; }
        public virtual Post Post { get; set; }
        [NotMapped()]
        public virtual List<SalarySheet> SalarySheets { get; set; }

        [NotMapped()]
        public virtual List<Employee> Employees { get; set; }

        public bool hasEmployee()
        {
            return Employees.Count > 0;
        }
    }
}
