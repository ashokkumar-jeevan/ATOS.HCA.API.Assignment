using System;
using HCA.Users.BO;
using HCA.UsersClient;
using HCA.Utilities;
using HCA.Users.BLL;

namespace HCA.UsersClient
{
    public class UserClient
    {

        #region Declarations
        UserBLL userBLL;
        private AppSettings appSettings;
        #endregion


        public UserClient(AppSettings appSettings)
        {
            //we just assume for now, will be direct access client.
            //UserService = new UserService(appSettings);
            //this.appSettings = appSettings;

            userBLL = new UserBLL(appSettings);
            this.appSettings = appSettings;
        }

        #region Validate User
        public UsersBO ValidateUser(string userName, string password)
        {
            UsersBO usersBO = userBLL.ValidateUser(userName, password);
            return usersBO;
        }
        #endregion
    }



}




