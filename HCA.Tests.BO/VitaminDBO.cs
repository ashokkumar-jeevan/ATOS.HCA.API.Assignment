using System;
using System.Collections.Generic;
using System.Text;

namespace HCA.Tests.BO
{
    public class VitaminDBO
    {
        public int VitaminDTestId { get; set; }
        public string VitaminD { get; set; } // 38.30 ng/dl <20 ng/ml : Deficient 20 - 30 ng/ml insufficient 30-100 ng/ml Desirable
        public string TestMethod { get; set; }
        public int LabReportId { get; set; }
    }
}
