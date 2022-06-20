using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Entity.FiboOffice
{
  public class FineSetup: BaseEntity
    {
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        public string FinePercent { get; set; }

    }
}
