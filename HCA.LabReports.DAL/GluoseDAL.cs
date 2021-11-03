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
    public class GluoseDAL
    {

        private AppSettings appSettings;

        public GluoseDAL(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }


        #region Declaration
        internal struct StoredProcedure
        {
            public const string GluoseCreateAndUpdate = "InsertUpdate_Gluose";
        }

        internal struct Parameters
        {
            public const string GluoseTestId = "GluoseTestId";
            public const string GlucoseFasting = "GlucoseFasting";
            public const string GlucosePP = "GlucosePP";
            public const string LabReportId = "LabReportId";
        }
        #endregion


        #region Create and Update Gluose Report

        public int GluoseCreateAndUpdate(GluoseBO gluoseBO)
        {
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertUpdate_Gluose";
            cmd.Parameters.Add("@GluoseTestId", SqlDbType.Int).Value = gluoseBO.GluoseTestId;
            cmd.Parameters.Add("@GlucoseFasting", SqlDbType.VarChar).Value = gluoseBO.GlucoseFasting;
            cmd.Parameters.Add("@GlucosePP", SqlDbType.VarChar).Value = gluoseBO.GlucosePP;
            cmd.Parameters.Add("@LabReportID", SqlDbType.VarChar).Value = gluoseBO.LabReportId;
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
