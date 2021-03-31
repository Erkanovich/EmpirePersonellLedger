using System;

namespace EmpirePersonellLedger.RequestsAndResponses
{
    public class TrooperResponse
    {
        public int TrooperId { get; set; }
        public string OperatingNumber { get; set; }
        public string Nickname { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public TrooperTypeResponse TrooperType { get; set; }
    }
}
