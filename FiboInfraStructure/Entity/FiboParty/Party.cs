using FiboInfraStructure.Entity.FiboAddress;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboParty
{
  public  class Party : BaseEntity
    {
        //public string setAddress(LocalLevel local, District district)
        //{
        //    return Address = local.Name + "-" + WardNumber + ", " + district.Name;
        //}
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal CreditLimit { get; set; }
        public string CreditLimitDay { get; set; }
        public string PartiesType { get; set; }
        public DateTime? PartiesCreatedDate { get; set; }
        public string WardNumber { get; set; }
        public decimal Credit { get; set; }
        public string Remarks { get; set; }
        public decimal Debit { get; set; }
        public decimal BillNumber { get; set; }
        public DateTime? LastEntryDate { get; set; }
        public decimal Balance { get; set; }


        public void SetAddress(LocalLevel local, District district)
        {
            Address = local.Name + "-" + WardNumber + ", " + district.Name;
        }


        [ForeignKey("ProvienceId")]
        public long? ProvienceId { get; set; }
        public virtual Provience Provience { get; set; }

        [ForeignKey("DistrictId")]
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }

        [ForeignKey("LocalLevelId")]
        public long? LocalLevelId { get; set; }
        public virtual LocalLevel LocalLevel { get; set; }
    }
}
