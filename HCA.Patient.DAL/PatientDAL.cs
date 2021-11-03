using System;
using System.Collections.Generic;
using System.Text;
using HCA.Utilities;
using HCA.Patient.BO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace HCA.Patient.DAL
{
    public class PatientDAL
    {
        private AppSettings appSettings;

        public PatientDAL(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }


        #region Declaration
        internal struct StoredProcedure
        {
            public const string GetPatients = "GetPatients";
            public const string GetPatientByID = "GetPatientByID";
            public const string GetPatientByEmailID = "GetPatientByEmailID";
            public const string PatientDeleteByPatientID = "PatientDeleteByPatientID";
            public const string PatientCreateAndUpdate = "InsertUpdate_Patient";
            

        }

        internal struct Parameters
        {   
            public const string PatientID = "PatientID";
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
        }
        #endregion

        #region Get Patient by EmailID

        public PatientBO GetPatientbyEmailID(string patientEmail)
        {
            PatientBO patientBO;                 
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPatientByEmailID";
            cmd.Parameters.Add("@PatientEmaill", SqlDbType.VarChar).Value = patientEmail;


            //cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = "FirstName";
            //cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = "LastName";
            //cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = "DOB";

            //cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = "ContactNo";

            //cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = "Email";

            //cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = "Password";

            //cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                patientBO = new PatientBO();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int patientID;
                        int.TryParse(reader[Parameters.PatientID].ToString(), out patientID);
                        patientBO.PatientID = patientID;
                        patientBO.PatientName = reader[Parameters.PatientName].ToString();

                        DateTime patientDOB;
                        DateTime.TryParse(reader[Parameters.PatientDOB].ToString(), out patientDOB);
                        patientBO.PatientDOB = patientDOB;
                        patientBO.PatientEmail = reader[Parameters.PatientEmaill].ToString();
                        patientBO.PatientContactNo = reader[Parameters.PatientContactNo].ToString();
                        patientBO.PatientAddressLine1 = reader[Parameters.PatientAddressLine1].ToString();
                        patientBO.PatientAddressLine2 = reader[Parameters.PatientAddressLine2].ToString();

                        patientBO.PatientCity = reader[Parameters.PatientCity].ToString();
                        patientBO.PatientState = reader[Parameters.PatientState].ToString();

                        patientBO.PrimaryDoctorName = reader[Parameters.PrimaryDoctorName].ToString();
                        patientBO.PatientCountry = reader[Parameters.PatientCountry].ToString();

                    }
                }
               
                reader.Close();
                return patientBO;
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

        #region Get Patient by Patient ID

        public PatientBO GetPatientbyPatientId(int patientId)
        {
            PatientBO patientBO;
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPatientByID";
            cmd.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientId;           

            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                patientBO = new PatientBO();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int patientID;
                        int.TryParse(reader[Parameters.PatientID].ToString(), out patientID);
                        patientBO.PatientID = patientID;
                        patientBO.PatientName = reader[Parameters.PatientName].ToString();
                        patientBO.Gender = reader[Parameters.Gender].ToString();
                        DateTime patientDOB;
                        DateTime.TryParse(reader[Parameters.PatientDOB].ToString(), out patientDOB);
                        patientBO.PatientDOB = patientDOB;

                        patientBO.PatientEmail = reader[Parameters.PatientEmaill].ToString();
                        patientBO.PatientContactNo = reader[Parameters.PatientContactNo].ToString();
                        patientBO.PatientAddressLine1 = reader[Parameters.PatientAddressLine1].ToString();
                        patientBO.PatientAddressLine2 = reader[Parameters.PatientAddressLine2].ToString();

                        patientBO.PatientCity = reader[Parameters.PatientCity].ToString();
                        patientBO.PatientState = reader[Parameters.PatientState].ToString();

                        patientBO.PrimaryDoctorName = reader[Parameters.PrimaryDoctorName].ToString();
                        patientBO.PatientCountry = reader[Parameters.PatientCountry].ToString();

                    }
                }

                reader.Close();
                return patientBO;
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

        #region Get all Patients

        public List<PatientBO> GetPatients()
        {
            List<PatientBO> lstpatientBO = new List<PatientBO>();
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPatients";           

            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();            

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PatientBO patientBO = new PatientBO();
                        int patientID;
                        int.TryParse(reader[Parameters.PatientID].ToString(), out patientID);
                        patientBO.PatientID = patientID;
                        patientBO.PatientName = reader[Parameters.PatientName].ToString();

                        DateTime patientDOB;
                        DateTime.TryParse(reader[Parameters.PatientDOB].ToString(), out patientDOB);
                        patientBO.PatientDOB = patientDOB;

                        patientBO.PatientContactNo = reader[Parameters.PatientContactNo].ToString();
                        patientBO.PatientAddressLine1 = reader[Parameters.PatientAddressLine1].ToString();
                        patientBO.PatientAddressLine2 = reader[Parameters.PatientAddressLine2].ToString();

                        patientBO.PatientCity = reader[Parameters.PatientCity].ToString();
                        patientBO.PatientState = reader[Parameters.PatientState].ToString();

                        patientBO.PrimaryDoctorName = reader[Parameters.PrimaryDoctorName].ToString();
                        patientBO.PatientCountry = reader[Parameters.PatientCountry].ToString();
                        lstpatientBO.Add(patientBO);
                    }
                }

                reader.Close();
                return lstpatientBO;
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

        #region Delete Return by Return Id      
        public void DeletePatientbyPatientID(int patientId)
        {
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PatientDeleteByPatientID";
            cmd.Parameters.Add("@PatientID", SqlDbType.VarChar).Value = patientId;
            cmd.Connection = con;
            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
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

        #region Create and Update Patient

        public int PatientCreateUpdate(PatientBO patientBO)
        {
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertUpdate_Patient";
            cmd.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientBO.PatientID;
            cmd.Parameters.Add("@PatientName", SqlDbType.VarChar).Value = patientBO.PatientName;
            cmd.Parameters.Add("@PatientDOB", SqlDbType.DateTime).Value = patientBO.PatientDOB;
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = patientBO.Gender;
            cmd.Parameters.Add("@PatientContactNo", SqlDbType.VarChar).Value = patientBO.PatientContactNo;
            cmd.Parameters.Add("@PatientEmaill", SqlDbType.VarChar).Value = patientBO.PatientEmail;
            cmd.Parameters.Add("@PatientAddressLine1", SqlDbType.VarChar).Value = patientBO.PatientAddressLine1;
            cmd.Parameters.Add("@PatientAddressLine2", SqlDbType.VarChar).Value = patientBO.PatientAddressLine2;
            cmd.Parameters.Add("@PatientCity", SqlDbType.VarChar).Value = patientBO.PatientCity;
            cmd.Parameters.Add("@PatientState", SqlDbType.VarChar).Value = patientBO.PatientState;
            cmd.Parameters.Add("@PrimaryDoctorName", SqlDbType.VarChar).Value = patientBO.PrimaryDoctorName;
            cmd.Parameters.Add("@PatientCountry", SqlDbType.VarChar).Value = patientBO.PatientCountry;
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
