using System;
using System.Collections.Generic;
using System.Text;

namespace HCA.Tests.BO
{
    public class VitaminB12BO
    {
        public int VitaminB12TestId { get; set; }
        public string VitaminB12 { get; set; } // 542 mg/dl <197 pg/ml : Deficient 197 - 771 pg/ml
        public string TestMethod { get; set; }
        public int LabReportId { get; set; }
    }
}
