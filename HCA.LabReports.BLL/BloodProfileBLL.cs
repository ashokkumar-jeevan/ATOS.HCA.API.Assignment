using System;
using System.Collections.Generic;
using System.Text;
using HCA.Tests.BO;
using HCA.LabReports.DAL;
using HCA.Utilities;

namespace HCA.LabReports.BLL
{
    public class BloodProfileBLL
    {
        #region Declarations
        private BloodProfileDAL bloodProfileDAL;
        private AppSettings appSettings;
        #endregion

        #region Constructor
        public BloodProfileBLL(AppSettings appSettings)
        {
            bloodProfileDAL = new BloodProfileDAL(appSettings);
            this.appSettings = appSettings;
        }
        #endregion


        #region Create and Update Blood Report

        public int BloodProfileCreateUpdate(BloodProfileBO bloodProfileBO)
        {
            return bloodProfileDAL.BloodProfileCreateUpdate(bloodProfileBO);
        }

        #endregion
    }
}
