using System;
using System.Collections.Generic;
using System.Text;

namespace HCA.Tests.BO
{
    public class GluoseBO
    {
        public int GluoseTestId { get; set; }
        public string GlucoseFasting { get; set; } // 94mg/dl 74-99 Normal 100-125 IFG Fair Control
        public string GlucosePP { get; set; } // 145 mg/dl upto 140mg/dl
        public int LabReportId { get; set; }
    }
}
