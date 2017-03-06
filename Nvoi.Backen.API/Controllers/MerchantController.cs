using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Nvoi.Backen.API.Controllers
{
    [EnableCors(origins: "http://localhost:55000", headers: "*", methods: "*")]
    public class MerchantController : ApiController
    {
        
        [Route("api/merchants")]
        public HttpResponseMessage GetAllMerchants()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "");
            return response;
        }

        [Route("api/merchants/{id?}")]
        public HttpResponseMessage GetMerchantbyId(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "");
            return response;
        }

        [Route("api/merchants/active")]
        public HttpResponseMessage GetActiveMerchants()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "");
            return response;
        }

        [Route("api/merchants")]
        public HttpResponseMessage Post(Object merchantObject)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, merchantObject);
            return response;
        }

        [Route("api/merchants")]
        public HttpResponseMessage Put(Object merchantObject)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, merchantObject);
            return response;
        }

        [Route("api/merchants")]
        public HttpResponseMessage Delete(Object merchantObject)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, merchantObject);
            return response;
        }
    }
   }