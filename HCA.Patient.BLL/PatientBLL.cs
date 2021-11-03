using System;
using System.Collections.Generic;
using HCA.Patient.BO;
using HCA.Patient.DAL;
using HCA.Utilities;

namespace HCA.Patient.BLL
{
    public class PatientBLL
    {
        #region Declarations
        private PatientDAL patientDAL;
        private AppSettings appSettings;
        #endregion

        #region Constructor
        public PatientBLL(AppSettings appSettings)
        {
            patientDAL = new PatientDAL(appSettings);
            this.appSettings = appSettings;
        }
        #endregion

        #region Get Patient by EmailID

        public PatientBO GetPatientbyEmailID(string patientEmail)
        {
            PatientBO patientBO;
            patientBO = patientDAL.GetPatientbyEmailID(patientEmail);
           return patientBO;
        }
        #endregion

        #region Get Patient by  Patient ID

        public PatientBO GetPatientbyPatientId(int patientId)
        {
            PatientBO patientBO;
            patientBO = patientDAL.GetPatientbyPatientId(patientId);
            return patientBO;
        }
        #endregion

        #region Get all Patients

        public List<PatientBO> GetPatients()
        {
            return patientDAL.GetPatients();
        }
        #endregion

        #region Delete Return by Return Id 

        public void DeletePatientbyPatientID(int patientId)
        {
            patientDAL.DeletePatientbyPatientID(patientId);          
        }
        #endregion

        #region Create and Update Patient

        public int PatientCreateUpdate(PatientBO patientBO)
        {
            return patientDAL.PatientCreateUpdate(patientBO);
        }

        #endregion
    }

}
