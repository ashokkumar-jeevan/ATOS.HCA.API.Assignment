using System;
using System.Collections.Generic;
using System.Text;
using HCA.Utilities;
using HCA.Users.BO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace HCA.Users.DAL
{
    public class UserDAL 
    {
        private AppSettings appSettings;

        public UserDAL(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }


        #region Declaration
        internal struct StoredProcedure
        {
            public const string GetUserByUserName = "GetUserByUserName";         
        }

        internal struct Parameters
        {
            public const string UserID = "UserID";
            public const string UserName = "UserName";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string Password = "Password";
            public const string DOB = "DOB";
            public const string ContactNo = "ContactNo";
            public const string Email = "Email";             
        }
        #endregion

        #region Validate User

        public UsersBO ValidateUser(string userName)
        {
            UsersBO userBO;
            int userId;
            SqlConnection con = new SqlConnection(appSettings.DefaultConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUserByUserName";
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                userBO = new UsersBO();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader[Parameters.UserID].ToString(), out userId);
                        userBO.UserId = userId;
                        userBO.Email = reader[Parameters.Email].ToString();
                        userBO.Password = reader[Parameters.Password].ToString();
                        userBO.UserName = userName;
                        userBO.IsUserExist = true;
                    }
                }
              
                reader.Close();
                return userBO;
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
