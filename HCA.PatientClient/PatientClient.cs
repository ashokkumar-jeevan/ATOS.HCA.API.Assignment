using System;
using HCA.Patient.BO;
using HCA.Patient.BLL;
using HCA.Utilities;
using System.Collections.Generic;

namespace HCA.PatientClient
{
    public class PatientClient
    {
        #region Declarations
        PatientBLL patientBLL;
        private AppSettings appSettings;
        #endregion


        public PatientClient(AppSettings appSettings)
        {

            patientBLL = new PatientBLL(appSettings);
            this.appSettings = appSettings;
        }

        # region Patient by EmailID
        public PatientBO GetPatientbyEmailID(string email)
        {
            PatientBO patientBO = patientBLL.GetPatientbyEmailID(email);
            return patientBO;
        }
        #endregion

        #region Get Patient by  Patient ID

        public PatientBO GetPatientbyPatientId(int patientId)
        {
            PatientBO patientBO;
            patientBO = patientBLL.GetPatientbyPatientId(patientId);
            return patientBO;
        }
        #endregion

        #region Get all Patients

        public List<PatientBO> GetPatients()
        {
            return patientBLL.GetPatients();
        }
        #endregion

        #region Delete Return by Return Id 

        public void DeletePatientbyPatientID(int patientId)
        {
            patientBLL.DeletePatientbyPatientID(patientId);
        }
        #endregion


        #region Create and Update Patient

        public int PatientCreateUpdate(PatientBO patientBO)
        {
            return patientBLL.PatientCreateUpdate(patientBO);
        }

        #endregion

    }
}
