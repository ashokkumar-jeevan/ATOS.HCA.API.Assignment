using System;
using System.Collections.Generic;
using System.Text;
using HCA.Tests.BO;
using HCA.LabReports.BLL;
using HCA.Utilities;

namespace HCA.LabReportsClient
{
    public class BloodProfileClient
    {
        #region Declarations
        BloodProfileBLL bloodProfileBLL;
        private AppSettings appSettings;
        #endregion


        public BloodProfileClient(AppSettings appSettings)
        {
            bloodProfileBLL = new BloodProfileBLL(appSettings);
            this.appSettings = appSettings;
        }

        #region Create and Update Patient

        public int BloodProfileCreateUpdate(BloodProfileBO bloodProfileBO)
        {
            return bloodProfileBLL.BloodProfileCreateUpdate(bloodProfileBO);
        }

        #endregion
    }
}
