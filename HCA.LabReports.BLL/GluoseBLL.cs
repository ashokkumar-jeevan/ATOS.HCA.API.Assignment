using System;
using System.Collections.Generic;
using System.Text;
using HCA.Tests.BO;
using HCA.LabReports.DAL;
using HCA.Utilities;


namespace HCA.LabReports.BLL
{
    public class GluoseBLL
    {
        #region Declarations
        private GluoseDAL gluoseDAL;
        private AppSettings appSettings;
        #endregion

        #region Constructor
        public GluoseBLL(AppSettings appSettings)
        {
            gluoseDAL = new GluoseDAL(appSettings);
            this.appSettings = appSettings;
        }
        #endregion


        #region Create and Update Gluose Report

        public int GluoseCreateUpdate(GluoseBO gluoseBO)
        {
            return gluoseDAL.GluoseCreateAndUpdate(gluoseBO);
        }

        #endregion
    }
}
