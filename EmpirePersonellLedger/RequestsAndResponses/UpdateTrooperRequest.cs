using System;

namespace EmpirePersonellLedger.RequestsAndResponses
{
    public class UpdateTrooperRequest
    {
        public string OperatingNumber { get; set; }
        public string Nickname { get; set; }
        public DateTime AcquisitionDate { get; set; }
    }
}