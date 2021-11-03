using System;
using System.Collections.Generic;
using System.Text;

namespace HCA.Tests.BO
{
    public class BloodProfileBO
    {
        public int BloodProfieTestId { get; set; }
        public string RBCCount { get; set; } // 5.83 Millions/Cmm Male : 4.5 - 5.5 Female : 3.8 - 4.8
        public string Haemoglobin { get; set; } // 15.9 gm/dl  Male : 13.0 - 17.0 Female : 12.0 - 15.0
        public string WBCCount { get; set; } //7330 Cells/cmm 4000-11000 cells/cmm
        public string Platelets { get; set; } //  2.91 Lakhs/Cmm 1.5-4.1 Lakhs/cmm
        public string TestMethod { get; set; }
        public int LabReportId { get; set; }
    }
}
