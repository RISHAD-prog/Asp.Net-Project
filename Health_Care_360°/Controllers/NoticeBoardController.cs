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
    [EnableCors("*", "*", "*")]
    //[Logged]
    public class NoticeBoardController : ApiController
    {

        [HttpPost]
        [Route("api/notice/add")]
        public HttpResponseMessage Register(NoticeBoardDTO noticeBoardDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = NoticeBoardService.Add(noticeBoardDTO);
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
        [Route("api/notice/list")]
        public HttpResponseMessage GetAllNotices()
        {
            try
            {
                var data = NoticeBoardService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }

        [HttpGet]
        [Route("api/notice/{id}")]
        public HttpResponseMessage GetSinglNotice(int id)
        {
            try
            {
                var data = NoticeBoardService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }


        [HttpPost]
        [Route("api/notice/delete/{id}")]
        public HttpResponseMessage DeleteNotice(/*DoctorDTO doctor*/ int id)
        {
            try
            {
                var data = NoticeBoardService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }


        [HttpPost]
        [Route("api/notice/update")]
        public HttpResponseMessage UpdateNotice(NoticeBoardDTO noticeBoardDTO)
        {
            try
            {
                var data = NoticeBoardService.Update(noticeBoardDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }
    }
}
