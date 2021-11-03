using System;
using HCA.LabReports.BO;
using HCA.LabReports.BLL;
using HCA.Utilities;


namespace HCA.LabReportsClient
{   

    public class LabReportsClient
    {
        #region Declarations
        LabReportBLL labReportBLL;
        private AppSettings appSettings;
        #endregion


        public LabReportsClient(AppSettings appSettings)
        {
            //we just assume for now, will be direct access client.
            //UserService = new UserService(appSettings);
            //this.appSettings = appSettings;

            labReportBLL = new LabReportBLL(appSettings);
            this.appSettings = appSettings;
        }

        #region Create and Update LabReport

        public int LapReportCreateUpdate(LabReportBO labReportBO)
        {
            return labReportBLL.LapReportCreateUpdate(labReportBO);
        }

        #endregion

        #region Get Lab Report by LabReportID

        public LabReportBO GetLabReportByLabReportID(int labReportId)
        {
            LabReportBO labReportBO;
            labReportBO = labReportBLL.GetLabReportByLabReportID(labReportId);
            return labReportBO;
        }
        #endregion
    }
}
