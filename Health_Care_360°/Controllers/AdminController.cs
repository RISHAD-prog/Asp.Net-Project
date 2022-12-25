using BLL.DTOs;
using BLL.Services;
using Health_Care_360_.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Health_Care_360_.Controllers
{
    [EnableCors("*", "*", "*")]
    [Logged]
    public class AdminController : ApiController
    {

        [HttpPost]
        [Route("api/admin/add")]
        public HttpResponseMessage Register(AdminDTO admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = AdminService.Add(admin);
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
        [Route("api/admin/list")]
        public HttpResponseMessage GetAllAdmins()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }

        [HttpGet]
        [Route("api/admin/{id}")]
        public HttpResponseMessage GetSinglAdmin(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }


        [HttpPost]
        [Route("api/admin/delete/{id}")]
        public HttpResponseMessage DeleteAdmin(/*DoctorDTO doctor*/ int id)
        {
            try
            {
                var data = AdminService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }


        [HttpPost]
        [Route("api/admin/update")]
        public HttpResponseMessage UpdateAdmin(AdminDTO admin)
        {
            try
            {
                var data = AdminService.Update(admin);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }

        //________________________________________________

        [HttpGet]
        [Route("api/all/list/count")]
        public HttpResponseMessage AllDoctorsCount()
        {
            try
            {
                var data = DoctorService.Get().Count;
                var data1 = PatientService.Get().Count;
                var data2 = StaffService.Get().Count;
                var data3=AdminService.Get().Count;
                List<int> numberList = new List<int>() { data, data1, data2,data3 };
                return Request.CreateResponse(HttpStatusCode.OK, numberList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //______________________________________________

        [HttpGet]
        [Route("api/doctor/count/by/qual")]
        public HttpResponseMessage GetDoctorCountByQualification()
        {
            try
            {
                var data1 = DoctorService.GetDoctorCountByQualification("Surgeon").Count;
                var data2 = DoctorService.GetDoctorCountByQualification("Dermatologist").Count;
                var data3 = DoctorService.GetDoctorCountByQualification("Orthopedist").Count;
                var data4 = DoctorService.GetDoctorCountByQualification("Urologist").Count;
                var data5 = DoctorService.GetDoctorCountByQualification("Neurologist").Count;
                var data6 = DoctorService.GetDoctorCountByQualification("Orthodontist").Count;
                var data7 = DoctorService.GetDoctorCountByQualification("Anesthesiologist").Count;
                var data8 = DoctorService.GetDoctorCountByQualification("Cardiology physician").Count;
            
                List<int> numberList = new List<int>() {data1, data2, data3, data4, data5,data6,data7,data8 };
                return Request.CreateResponse(HttpStatusCode.OK, numberList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/admin/get/{email}")]
        public HttpResponseMessage GetSingleAdminByEmail(string email)
        {
            try
            {
                var data = AdminService.GetChecker(email);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }






    }
}
