using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpirePersonellLedger.RequestsAndResponses
{
    public class AddTrooperTypeRequest
    {
        public string TypeName { get; set; }
        public string Speciality { get; set; }
        public string Weapon { get; set; }
    }
}
