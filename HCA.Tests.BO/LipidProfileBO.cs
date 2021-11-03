using System;
using System.Collections.Generic;
using System.Text;

namespace HCA.Tests.BO
{
    public class LipidProfileBO
    {
        public int LipidProfileTestId { get; set; }
        public string TotalCholesterol { get; set; } // 277 mg/dl <200 mgdl : Desirable 200 - 239 mg/dl Boderline High >=240 mg/dl High
        public string HDLCholesterol { get; set; } // 36 mg/dl <40 mgdl : High 40 - 60 mg/dl Boderline High >=60 mg/dl High
        public string Triglycerides { get; set; } // 262 mg/dl <150 mgdl : Desirable 150 - 199 mg/dl Boderline High >=200 mg/dl High
        public string LDLCholesterol { get; set; } // 212 mg/dl <100 mgdl : Optimal 100 - 159 mg/dl Boderline High >=160 mg/dl High
        public string VLDLCholesterol { get; set; } // 52.4 mg/dl 
        public int LabReportId { get; set; }
    }
}
