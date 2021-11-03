using System;
using System.Collections.Generic;
using System.Text;
using HCA.Utilities;
using HCA.Patient.BO;
using HCA.LabReports.BO;
using HCA.Tests.BO;
using System.Data.SqlClient;
using System.Data;

namespace HCA.LabReports.DAL
{
    public class BloodProfileDAL
    {


        private AppSettings appSettings;

        public BloodProfileDAL(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }


        #region Declaration
        internal struct StoredProcedure
        {
            public const string BloodProfileCreateAndUpdate = "InsertUpdate_BloodProfile";
        }

        internal struct Parameters
        {
            public const string BloodProfieTestId = "BloodProfieTestId";
            public const string RBCCount = "RBCCount";
            public const string Haemoglobin = "Haemoglobin";
            public const string WBCCount = "WBCCount";
            public const string Platelets = "Platelets";
            public const string TestMethod = "TestMethod";
            public const string LabReportID = "LabReportID";
        }
        #endregion


        #region Create and Update Blood Report

        public int BloodProfileCreateUpdate(BloodProfileBO bloodProfileBO)
        {
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertUpdate_BloodProfile";
            cmd.Parameters.Add("@BloodProfieTestId", SqlDbType.Int).Value = bloodProfileBO.BloodProfieTestId;
            cmd.Parameters.Add("@RBCCount", SqlDbType.VarChar).Value = bloodProfileBO.RBCCount;
            cmd.Parameters.Add("@Haemoglobin", SqlDbType.VarChar).Value = bloodProfileBO.Haemoglobin;
            cmd.Parameters.Add("@WBCCount", SqlDbType.VarChar).Value = bloodProfileBO.WBCCount;
            cmd.Parameters.Add("@Platelets", SqlDbType.VarChar).Value = bloodProfileBO.Platelets;
            cmd.Parameters.Add("@TestMethod", SqlDbType.VarChar).Value = bloodProfileBO.TestMethod;
            cmd.Parameters.Add("@LabReportID", SqlDbType.VarChar).Value = bloodProfileBO.LabReportId;
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
