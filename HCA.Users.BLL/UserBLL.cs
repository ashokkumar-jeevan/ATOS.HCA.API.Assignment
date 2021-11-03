using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using HCA.Users.BO;
using HCA.Users.DAL;
using HCA.Utilities;

namespace HCA.Users.BLL
{
    public class UserBLL
    {
        #region Declarations
        private UserDAL userDAL;
        private AppSettings appSettings;
        #endregion

        #region Constructor
        public UserBLL(AppSettings appSettings)
        {
            userDAL = new UserDAL(appSettings);
            this.appSettings = appSettings;
        }
        #endregion


        #region Login Check
        /// <summary>
        /// Checks for Authendicated User.
        /// </summary>
        /// <param name="userInfo">The user info.</param>
        /// <returns></returns>
        public UsersBO ValidateUser(string userName, string password)
        {
            UsersBO userBO;

            userBO = this.userDAL.ValidateUser(userName);     
            
            if(userBO.IsUserExist && userBO.Password == password)
            {
                userBO.IsValidUser = true;
            }

            return userBO;
        }
        #endregion
    }
}
