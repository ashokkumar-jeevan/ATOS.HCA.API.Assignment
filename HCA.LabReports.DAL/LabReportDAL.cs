using System;
using HCA.Utilities;
using HCA.Patient.BO;
using HCA.LabReports.BO;
using HCA.Tests.BO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace HCA.LabReports.DAL
{
    public class LabReportDAL
    {
        private AppSettings appSettings;

        public LabReportDAL(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }


        #region Declaration
        internal struct StoredProcedure
        {
            public const string GetLabReports = "GetLabReports";
            public const string GetLabReportByPatientEmailId = "GetLabReportByPatientEmailId";
            public const string GetLabReportByLabReportID = "GetLabReportByLabReportID";
            public const string InsertUpdate_LabReport = "InsertUpdate_LabReport";
        }

        internal struct Parameters
        {
            public const string PatientID = "PatientID";
            public const string LabReportID = "LabReportID";
            public const string SampleTakenDate = "SampleTakenDate";
            public const string LabReportGeneratedTime = "LabReportGeneratedTime";
            public const string CreatedDate = "CreatedDate";
            public const string UpdatedDate = "UpdatedDate";
            public const string DoctorName = "DoctorName";

            public const string PatientName = "PatientName";
            public const string PatientDOB = "PatientDOB";
            public const string PatientContactNo = "PatientContactNo";
            public const string PatientEmaill = "PatientEmaill";
            public const string PatientAddressLine1 = "PatientAddressLine1";
            public const string PatientAddressLine2 = "PatientAddressLine2";
            public const string PatientCity = "PatientCity";
            public const string PatientState = "PatientState";
            public const string PrimaryDoctorName = "PrimaryDoctorName";
            public const string PatientCountry = "PatientCountry";
            public const string Gender = "Gender";

            public const string BloodProfieTestId = "BloodProfieTestId";
            public const string Haemoglobin = "Haemoglobin";
            public const string RBCCount = "RBCCount";
            public const string WBCCount = "WBCCount";
            public const string Platelets = "Platelets";
            public const string TestMethod = "TestMethod";

            public const string GluoseTestId = "GluoseTestId";
            public const string GlucoseFasting = "GlucoseFasting";
            public const string GlucosePP = "GlucosePP";

            public const string LipidProfileTestId = "LipidProfileTestId";
            public const string TotalCholesterol = "TotalCholesterol";
            public const string HDLCholesterol = "HDLCholesterol";
            public const string Triglycerides = "Triglycerides";
            public const string LDLCholesterol = "LDLCholesterol";
            public const string VLDLCholesterol = "VLDLCholesterol";


            public const string UrineAnalysisTestId = "UrineAnalysisTestId";
            public const string Color = "Color";
            public const string PH = "PH";
            public const string Proteins = "Proteins";
            public const string Rbcs = "Rbcs";
            public const string BilePigments = "BilePigments";
            public const string Urobilinogen = "Urobilinogen";

            public const string VitaminB12TestId = "VitaminB12TestId";
            public const string VitaminB12 = "VitaminB12";

            public const string VitaminDTestId = "VitaminDTestId";
            public const string VitaminD = "VitaminD";
        }
        #endregion

        #region Get all Lab Reports

        public List<LabReportBO> GetLabReports()
        {
            List<LabReportBO> lstLabReportBO = new List<LabReportBO>();
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLabReports";

            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LabReportBO labReportBO = new LabReportBO();
                        int patientID;
                        int.TryParse(reader[Parameters.PatientID].ToString(), out patientID);
                        labReportBO.PatientID = patientID;

                        int labReportID;
                        int.TryParse(reader[Parameters.LabReportID].ToString(), out labReportID);
                        labReportBO.LabReportID = labReportID;

                        //labReportBO.TestName = reader[Parameters.TestName].ToString();

                        DateTime sampleTakenTime;
                        DateTime.TryParse(reader[Parameters.SampleTakenDate].ToString(), out sampleTakenTime);
                        labReportBO.SampleTakenTime = sampleTakenTime;

                        DateTime LabReportGeneratedTime;
                        DateTime.TryParse(reader[Parameters.LabReportGeneratedTime].ToString(), out LabReportGeneratedTime);
                        labReportBO.LabReportGeneratedTime = LabReportGeneratedTime;

                        labReportBO.DoctorName = reader[Parameters.DoctorName].ToString();
                      
                        lstLabReportBO.Add(labReportBO);
                    }
                }

                reader.Close();
                return lstLabReportBO;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                con.Close();
                con.Dispose();
            }
        } 
        #endregion

        #region Get Lab Reportby EmailID

        public List<LabReportBO> GetLabReportbyEmailID(string patientEmail)
        {
            List<LabReportBO> lstLabReportBO = new List<LabReportBO>();
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLabReportByPatientEmailId";
            cmd.Parameters.Add("@PatientEmaill", SqlDbType.VarChar).Value = patientEmail;

            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
              
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LabReportBO labReportBO = new LabReportBO();
                        int patientID;
                        int.TryParse(reader[Parameters.PatientID].ToString(), out patientID);
                        labReportBO.PatientID = patientID;

                        int labReportID;
                        int.TryParse(reader[Parameters.LabReportID].ToString(), out labReportID);
                        labReportBO.LabReportID = labReportID;

                        //labReportBO.TestName = reader[Parameters.TestName].ToString();

                        DateTime sampleTakenDate;
                        DateTime.TryParse(reader[Parameters.SampleTakenDate].ToString(), out sampleTakenDate);
                        labReportBO.SampleTakenTime = sampleTakenDate;

                        DateTime LabReportGeneratedTime;
                        DateTime.TryParse(reader[Parameters.LabReportGeneratedTime].ToString(), out LabReportGeneratedTime);
                        labReportBO.LabReportGeneratedTime = LabReportGeneratedTime;

                        labReportBO.DoctorName = reader[Parameters.DoctorName].ToString();

                        lstLabReportBO.Add(labReportBO);

                    }
                }

                reader.Close();
                return lstLabReportBO;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        #endregion
        
        #region Get Lab Report by LabReportID

        public LabReportBO GetLabReportByLabReportID(int labReportId)
        {
            LabReportBO labReportBO = new LabReportBO();
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLabReportByLabReportID";
            cmd.Parameters.Add("@LabReportID", SqlDbType.Int).Value = labReportId;

            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                       
                        int patientID;
                        int.TryParse(reader[Parameters.PatientID].ToString(), out patientID);
                        labReportBO.PatientID = patientID;

                        int labReportID;
                        int.TryParse(reader[Parameters.LabReportID].ToString(), out labReportID);
                        labReportBO.LabReportID = labReportID;

                        DateTime labReportGeneratedTime;
                        DateTime.TryParse(reader[Parameters.LabReportGeneratedTime].ToString(), out labReportGeneratedTime);
                        labReportBO.LabReportGeneratedTime = labReportGeneratedTime;

                        labReportBO.DoctorName = reader[Parameters.DoctorName].ToString();

                        DateTime sampleTakenDate;
                        DateTime.TryParse(reader[Parameters.SampleTakenDate].ToString(), out sampleTakenDate);
                        labReportBO.SampleTakenTime = sampleTakenDate;

                        if (patientID > 0)
                        {
                            PatientBO patientBO = new PatientBO();
                            patientBO.PatientID = patientID;
                            patientBO.PatientName = reader[Parameters.PatientName].ToString();

                            DateTime patientDOB;
                            DateTime.TryParse(reader[Parameters.PatientDOB].ToString(), out patientDOB);
                            patientBO.PatientDOB = patientDOB;
                            patientBO.Gender = reader[Parameters.Gender].ToString();
                            patientBO.PatientEmail = reader[Parameters.PatientEmaill].ToString();
                            patientBO.PatientContactNo = reader[Parameters.PatientContactNo].ToString();
                            patientBO.PatientAddressLine1 = reader[Parameters.PatientAddressLine1].ToString();
                            patientBO.PatientAddressLine2 = reader[Parameters.PatientAddressLine2].ToString();

                            patientBO.PatientCity = reader[Parameters.PatientCity].ToString();
                            patientBO.PatientState = reader[Parameters.PatientState].ToString();

                            patientBO.PrimaryDoctorName = reader[Parameters.PrimaryDoctorName].ToString();
                            patientBO.PatientCountry = reader[Parameters.PatientCountry].ToString();

                            labReportBO.Patient = patientBO;
                        }

                        int bloodProfieTestId;
                        int.TryParse(reader[Parameters.BloodProfieTestId].ToString(), out bloodProfieTestId);

                        if (bloodProfieTestId > 0)
                        {
                            BloodProfileBO bloodProfileBO = new BloodProfileBO();
                            bloodProfileBO.BloodProfieTestId = bloodProfieTestId;

                            bloodProfileBO.RBCCount = reader[Parameters.RBCCount].ToString();
                            bloodProfileBO.Haemoglobin = reader[Parameters.Haemoglobin].ToString();
                            bloodProfileBO.WBCCount = reader[Parameters.WBCCount].ToString();
                            bloodProfileBO.Platelets = reader[Parameters.Platelets].ToString();
                            bloodProfileBO.TestMethod = reader[Parameters.TestMethod].ToString();
                      
                            int.TryParse(reader[Parameters.LabReportID].ToString(), out labReportID);
                            bloodProfileBO.LabReportId = labReportID;

                            labReportBO.BloodProfileReport = bloodProfileBO;
                        }
                        
                        int gluoseTestId;
                        int.TryParse(reader[Parameters.GluoseTestId].ToString(), out gluoseTestId);
                        
                        if (gluoseTestId > 0)
                        {
                            GluoseBO gluoseBO = new GluoseBO();
                            gluoseBO.GluoseTestId = gluoseTestId;

                            gluoseBO.GlucoseFasting = reader[Parameters.GlucoseFasting].ToString(); ;
                            gluoseBO.GlucosePP = reader[Parameters.GlucosePP].ToString();
                            int.TryParse(reader[Parameters.LabReportID].ToString(), out labReportID);
                            gluoseBO.LabReportId = labReportID;

                            labReportBO.GluoseReport = gluoseBO;

                        }


                        int lipidProfileTestId;
                        int.TryParse(reader[Parameters.LipidProfileTestId].ToString(), out lipidProfileTestId);
                        if (lipidProfileTestId > 0)
                        {
                            LipidProfileBO lipidProfileBO = new LipidProfileBO();
                            lipidProfileBO.LipidProfileTestId = lipidProfileTestId;
                            lipidProfileBO.TotalCholesterol = reader[Parameters.TotalCholesterol].ToString();
                            lipidProfileBO.HDLCholesterol = reader[Parameters.HDLCholesterol].ToString();
                            lipidProfileBO.Triglycerides = reader[Parameters.Triglycerides].ToString();
                            lipidProfileBO.LDLCholesterol = reader[Parameters.LDLCholesterol].ToString();
                            lipidProfileBO.VLDLCholesterol = reader[Parameters.VLDLCholesterol].ToString();

                            int.TryParse(reader[Parameters.LabReportID].ToString(), out labReportID);
                            lipidProfileBO.LabReportId = labReportID;

                            labReportBO.LipidProfileReport = lipidProfileBO;
                        }


                        int urineAnalysisTestId;
                        int.TryParse(reader[Parameters.UrineAnalysisTestId].ToString(), out urineAnalysisTestId);
                        if (urineAnalysisTestId > 0)
                        {
                            UrineAnalysisBO urineAnalysisBO = new UrineAnalysisBO();
                            urineAnalysisBO.UrineAnalysisTestId = urineAnalysisTestId;
                            urineAnalysisBO.Color = reader[Parameters.Color].ToString(); ;
                            urineAnalysisBO.PH = reader[Parameters.PH].ToString();
                            urineAnalysisBO.Proteins = reader[Parameters.Proteins].ToString();
                            urineAnalysisBO.Rbcs = reader[Parameters.Rbcs].ToString();
                            urineAnalysisBO.BilePigments = reader[Parameters.BilePigments].ToString();
                            urineAnalysisBO.Urobilinogen = reader[Parameters.Urobilinogen].ToString();
                            urineAnalysisBO.TestMethod = reader[Parameters.TestMethod].ToString();
                            int.TryParse(reader[Parameters.LabReportID].ToString(), out labReportID);
                            urineAnalysisBO.LabReportId = labReportID;

                            labReportBO.UrineAnalysisReport = urineAnalysisBO;
                        }


                        int vitaminDTestId;
                        int.TryParse(reader[Parameters.VitaminDTestId].ToString(), out vitaminDTestId);

                        if (vitaminDTestId > 0)
                        {
                            VitaminDBO vitaminDBO = new VitaminDBO();
                            vitaminDBO.VitaminDTestId = vitaminDTestId;
                            vitaminDBO.VitaminD = reader[Parameters.VitaminD].ToString();
                            vitaminDBO.TestMethod = reader[Parameters.TestMethod].ToString();
                            int.TryParse(reader[Parameters.LabReportID].ToString(), out labReportID);
                            vitaminDBO.LabReportId = labReportID;

                            labReportBO.VitaminDReport = vitaminDBO;
                        }

                        int vitaminB12TestId;
                        int.TryParse(reader[Parameters.VitaminB12TestId].ToString(), out vitaminB12TestId);

                        if (vitaminB12TestId > 0)
                        {
                            VitaminB12BO vitaminB12BO = new VitaminB12BO();
                            vitaminB12BO.VitaminB12TestId = vitaminB12TestId;

                            vitaminB12BO.VitaminB12 = reader[Parameters.VitaminB12].ToString();
                            vitaminB12BO.TestMethod = reader[Parameters.TestMethod].ToString();
                            int.TryParse(reader[Parameters.LabReportID].ToString(), out labReportID);
                            vitaminB12BO.LabReportId = labReportID;

                            labReportBO.VitaminB12Report = vitaminB12BO;
                        }
                    }
                }

                reader.Close();
                return labReportBO;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        #endregion

        #region Create and Update LabReport

        public int LapReportCreateUpdate(LabReportBO labReportBO)
        {
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertUpdate_LabReport";
            cmd.Parameters.Add("@PatientID", SqlDbType.Int).Value = labReportBO.PatientID;
            cmd.Parameters.Add("@LabReportID", SqlDbType.VarChar).Value = labReportBO.LabReportID;
            cmd.Parameters.Add("@@SampleTakenDate", SqlDbType.DateTime).Value = labReportBO.SampleTakenTime;
            cmd.Parameters.Add("@LabReportGeneratedTime", SqlDbType.DateTime).Value = labReportBO.LabReportGeneratedTime;
            cmd.Parameters.Add("@DoctorName", SqlDbType.VarChar).Value = labReportBO.DoctorName;
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Connection = con;

            try
            {
                con.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        #endregion
    }
}
