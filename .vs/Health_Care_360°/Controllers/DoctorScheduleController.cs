using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Health_Care_360_.Controllers
{
    [EnableCors("*","*","*")]
    public class DoctorScheduleController : ApiController
    {

        [HttpGet]
        [Route("api/DoctorSchedule/Add")]
        public HttpResponseMessage Add()
        {
            try
            {
                 var data = DoctorService.Get();
                 return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [HttpPost]
        [Route("api/DoctorSchedule/Add")]
        public HttpResponseMessage Add(DoctorScheduleDTO doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = DoctorScheduleService.Add(doctor);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }




        [HttpGet]
        [Route("api/DoctorSchedule/get/all")]
        public HttpResponseMessage GetAllDoctorSchedule()
        {
            try
            {
                var data = DoctorScheduleService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }

        [HttpGet]
        [Route("api/DoctorSchedule/get/{id}")]
        public HttpResponseMessage GetSingleDoctorSchedule(int id)
        {
            try
            {
                var data = DoctorScheduleService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }


        [HttpPost]
        [Route("api/DoctorSchedule/delete/{id}")]
        public HttpResponseMessage DeleteDoctorSchedule(/*DoctorDTO doctor*/ int id)
        {
            try
            {
                var data = DoctorScheduleService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }


        [HttpPost]
        [Route("api/DoctorSchedule/update")]
        public HttpResponseMessage UpdateDoctorSchedule(DoctorScheduleDTO doctor)
        {
            try
            {
                var data = DoctorScheduleService.Update(doctor);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }
    }
}
