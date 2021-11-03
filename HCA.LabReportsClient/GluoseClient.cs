using System;
using System.Collections.Generic;
using System.Text;
using HCA.Tests.BO;
using HCA.LabReports.BLL;
using HCA.Utilities;

namespace HCA.LabReportsClient
{
    public class GluoseClient
    {
        #region Declarations
        GluoseBLL gluoseBLL;
        private AppSettings appSettings;
        #endregion


        public GluoseClient(AppSettings appSettings)
        {
            gluoseBLL = new GluoseBLL(appSettings);
            this.appSettings = appSettings;
        }

        #region Create and Update Gluose Report

        public int GluoseCreateUpdate(GluoseBO gluoseBO)
        {
            return gluoseBLL.GluoseCreateUpdate(gluoseBO);
        }

        #endregion
    }
}
