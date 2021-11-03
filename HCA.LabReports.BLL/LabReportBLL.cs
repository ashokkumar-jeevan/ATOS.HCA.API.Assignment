using System;
using System.Collections.Generic;
using System.Text;
using HCA.LabReports.DAL;
using HCA.LabReports.BO;
using HCA.Utilities;

namespace HCA.LabReports.BLL
{
    public class LabReportBLL
    {
        #region Declarations
        private LabReportDAL labReportDAL;
        private AppSettings appSettings;
        #endregion

        #region Constructor
        public LabReportBLL(AppSettings appSettings)
        {
            labReportDAL = new LabReportDAL(appSettings);
            this.appSettings = appSettings;
        }
        #endregion

        #region Create and Update LabReport

        public int LapReportCreateUpdate(LabReportBO labReportBO)
        {
            return labReportDAL.LapReportCreateUpdate(labReportBO);
        }

        #endregion

        #region Get Lab Report by LabReportID

        public LabReportBO GetLabReportByLabReportID(int labReportId)
        {
            LabReportBO labReportBO ;
            labReportBO = labReportDAL.GetLabReportByLabReportID(labReportId);
            return labReportBO;
        }
        #endregion

    }
}
