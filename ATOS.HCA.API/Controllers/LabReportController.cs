using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCA.LabReports.BO;
using HCA.LabReportsClient;
using HCA.Utilities;
using Microsoft.Extensions.Options;
using HCA.Tests.BO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HCA.LabReports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabReportController : ControllerBase
    {
        private AppSettings appSettings;

        public LabReportController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        [Route("LapReportCreateUpdate")]
        [HttpPost]
        public IActionResult LapReportCreateUpdate([FromBody] LabReportBO labReportBO)
        {
            try
            {
                LabReportsClient.LabReportsClient labReportsClient = new LabReportsClient.LabReportsClient(appSettings);
                int patientID = labReportsClient.LapReportCreateUpdate(labReportBO);
                return Ok(patientID);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("BloodProfileCreateUpdate")]
        [HttpPost]
        public IActionResult BloodProfileCreateUpdate(BloodProfileBO bloodProfileBO)
        {
            BloodProfileClient bloodProfileClient = new BloodProfileClient(appSettings);
            int BloodProfieTestId = bloodProfileClient.BloodProfileCreateUpdate(bloodProfileBO);
            return Ok(BloodProfieTestId);
        }

        [Route("GluoseCreateUpdate")]
        [HttpPost]
        public IActionResult GluoseCreateUpdate(GluoseBO gluoseBO)
        {
            GluoseClient gluoseClient = new GluoseClient(appSettings);
            int GluoseTestId = gluoseClient.GluoseCreateUpdate(gluoseBO);
            return Ok(GluoseTestId);

        }


        [Route("GetLabReportByLabReportID")]
        [HttpGet]
        public IActionResult GetLabReportByLabReportID(int labReportId)
        {
            try
            {
                LabReportBO labReportBO;
                LabReportsClient.LabReportsClient labReportsClient = new LabReportsClient.LabReportsClient(appSettings);
                labReportBO = labReportsClient.GetLabReportByLabReportID(labReportId);
                return Ok(labReportBO);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
