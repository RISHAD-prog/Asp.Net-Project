using BLL.DTOs;
using BLL.Services;
using Health_Care_360_.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Health_Care_360_.Controllers
{
    public class AppointMentController : ApiController
    {
        //[Logged]
        [HttpGet]
        [Route("api/AppointMent/{id}")]
        public HttpResponseMessage AddPatientCheckupDetails()
        {
            try
            {
                var data = MedicineService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
           
        }
        //[Logged]
        [HttpPost]
        [Route("api/AppointMent/{id}")]
        public HttpResponseMessage AddPatientCheckupDetails(PatientCheckUpDTO patientCheckUp,int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = PatientCheckUpService.Add(patientCheckUp,id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"data is not passed");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex.Message);
            }
            
        }
        [Logged]
        [HttpGet]
        [Route("api/AppointMent/PrescriptionDetails/{id}")]
        public HttpResponseMessage SeePatientCheckupDetails(int id)
        {
            var data = PatientCheckUpService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
