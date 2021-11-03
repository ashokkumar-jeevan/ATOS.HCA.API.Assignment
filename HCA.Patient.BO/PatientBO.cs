using System;
using System.Collections.Generic;
using System.Text;

namespace HCA.Patient.BO
{
    public class PatientBO
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public DateTime PatientDOB { get; set; }
        public string Gender { get; set; }
        public string PatientContactNo { get; set; }
        public string PatientEmail { get; set; }
        public string PatientAddressLine1 { get; set; }
        public string PatientAddressLine2 { get; set; }
        public string PatientCity { get; set; }
        public string PatientState { get; set; }
        public string PatientCountry { get; set; }
        public string PrimaryDoctorName { get; set; }
    }
}
