using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using HCA.PatientClient;
using Microsoft.Extensions.Options;
using HCA.Utilities;
using HCA.Patient.BO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HCA.LabReports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PatientController : ControllerBase
    {

        private AppSettings appSettings;

        public PatientController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        [Route("GetPatientbyEmailID")]
        [HttpGet]
        public IActionResult GetPatientbyEmailID(string email)
        {
            try
            {               
                PatientBO patientBO;
                PatientClient.PatientClient patientClient = new PatientClient.PatientClient(appSettings);
                patientBO = patientClient.GetPatientbyEmailID(email);
                return Ok(patientBO);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("GetPatientbyPatientId")]
        [HttpGet]
        public IActionResult GetPatientbyPatientId(int patientID)
        {
            try
            {
                PatientBO patientBO;
                PatientClient.PatientClient patientClient = new PatientClient.PatientClient(appSettings);
                patientBO = patientClient.GetPatientbyPatientId(patientID);
                return Ok(patientBO);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("GetPatients")]
        [HttpGet]
        public IActionResult GetPatients()
        {
            try
            {
                List<PatientBO> lstPatientBO;
                PatientClient.PatientClient patientClient = new PatientClient.PatientClient(appSettings);
                lstPatientBO = patientClient.GetPatients();
                return Ok(lstPatientBO);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("DeletePatientbyPatientID")]
        [HttpGet]
        public IActionResult DeletePatientbyPatientID(int patientID)
        {
            try
            {              
                PatientClient.PatientClient patientClient = new PatientClient.PatientClient(appSettings);
                patientClient.DeletePatientbyPatientID(patientID);
                return Ok();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("CreateUpdatePatient")]
        [HttpPost]
        public IActionResult PatientCreateUpdate([FromBody] PatientBO patientBO)
        {
            try
            {
                PatientClient.PatientClient patientClient = new PatientClient.PatientClient(appSettings);
                int patientID = patientClient.PatientCreateUpdate(patientBO);
                return Ok(patientID);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
