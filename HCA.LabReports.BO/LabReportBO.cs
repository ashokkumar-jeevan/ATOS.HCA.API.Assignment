using System;
using HCA.Patient.BO;
using HCA.Tests.BO;
using System.Collections.Generic;
using System.Text;

namespace HCA.LabReports.BO
{
    public class LabReportBO
    {
        public int LabReportID { get; set; }

        public int PatientID { get; set; }
        public PatientBO Patient { get; set; }

        public DateTime SampleTakenTime { get; set; }
        public DateTime LabReportGeneratedTime { get; set; }
        public string DoctorName { get; set; }


        public UrineAnalysisBO UrineAnalysisReport { get; set; }


        public GluoseBO GluoseReport { get; set; }


        public BloodProfileBO BloodProfileReport { get; set; }

        public VitaminDBO VitaminDReport { get; set; }

        public LipidProfileBO LipidProfileReport { get; set; }


        public VitaminB12BO VitaminB12Report { get; set; }
    }
}
