using FiboInfraStructure.Src;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboOffice.Src.Dto
{
    public class ElectricityFineSetupDto : BaseDto
    {
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        public string FinePercent { get; set; }
    }
}
