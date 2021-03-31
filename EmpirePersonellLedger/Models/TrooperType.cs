using System;

namespace EmpirePersonellLedger.Models
{
    public class TrooperType
    {
        public string TypeName { get; set; }
        public string Speciality { get; set; }
        public string Weapon { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}