using FiboInfraStructure.Entity.FiboAddress;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboOffice
{
    public class Office : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string FAX { get; set; }
        public string PANNo { get; set; }
        [ForeignKey("ProvienceId")]
        public long? ProvienceId { get; set; }
        public virtual Provience Provience { get; set; }

        [ForeignKey("DistrictId")]
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }

        [ForeignKey("LocalLevelId")]
        public long? LocalLevelId { get; set; }
        public virtual LocalLevel LocalLevel { get; set; }
        [NotMapped()]
        public IFormFile OfficeLogo { get; set; }
    }
}

