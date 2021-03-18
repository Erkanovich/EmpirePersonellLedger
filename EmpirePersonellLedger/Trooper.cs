using System;

namespace EmpirePersonellLedger
{
    public class Trooper
    {
        public int TrooperId { get; set; }
        public string OperatingNumber { get; set; }
        public string Nickname { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public TrooperType TrooperType { get; set; }
    }
}