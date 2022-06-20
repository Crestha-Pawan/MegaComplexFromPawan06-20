using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBlock
{
    public class Electricity:BaseEntity
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
        public decimal? Unit { get; set; }
        public decimal? Charge { get; set; }
        public string Status { get; set; }
    }
}
