using System;
using System.Collections.Generic;
using System.Text;

namespace HCA.Tests.BO
{
    public class UrineAnalysisBO
    {
        public int UrineAnalysisTestId { get; set; }
        public string Color { get; set; } // Straw Yellow Pale Yello
        public string PH { get; set; } // 5.0 5.0-9.0
        public string Proteins { get; set; } //Negative Negative 
        public string Rbcs { get; set; } //  Nil 0-2 hpf
        public string BilePigments { get; set; } //Absent Absent 
        public string Urobilinogen { get; set; } //Present in Normal Amount Present in Normal Amount
        public string TestMethod { get; set; }
        public int LabReportId { get; set; }
    }
}
