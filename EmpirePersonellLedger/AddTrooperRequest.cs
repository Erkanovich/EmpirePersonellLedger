using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpirePersonellLedger
{
    public class AddTrooperRequest
    {
        public string OperatingNumber { get; set; }
        public string Nickname { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string TrooperTypePrimaryKey { get; set; }
    }
}
