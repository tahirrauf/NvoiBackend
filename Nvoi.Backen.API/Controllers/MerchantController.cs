using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Nvoi.Backen.API.Repositories;
using AutoMapper;
using Nvoi.Backen.API.DAL;

namespace Nvoi.Backen.API.Controllers
{
    [EnableCors(origins: "http://localhost:49280", headers: "*", methods: "*")]
    public class MerchantController : ApiController
    {
        private UnitOfWork uow = null;

        public MerchantController()
        {
            uow = new UnitOfWork();
        }

        [Route("api/merchants")]
        public HttpResponseMessage GetAllMerchants()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Merchant, Models.Merchant>());

            Models.Merchant[] merchantModelArray = Mapper.Map<Merchant[], Models.Merchant[]>(uow.MerchantRepository.GetAll().ToList().ToArray());

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, merchantModelArray);
            return response;
        }

        [Route("api/merchants/{id?}")]
        public HttpResponseMessage GetMerchantbyId(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Merchant, Models.Merchant>());
            Models.Merchant merchantModel = Mapper.Map<Merchant, Models.Merchant>(uow.MerchantRepository.Get(m => m.Id == id));

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, merchantModel);
            return response;
        }

        [Route("api/merchants/active")]
        public HttpResponseMessage GetActiveMerchants()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Merchant, Models.Merchant>());
            Models.Merchant merchantModel = Mapper.Map<Merchant, Models.Merchant>(uow.MerchantRepository.Get(m => m.Status == true));

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, merchantModel);
            return response;
        }

        [Route("api/merchants")]
        public HttpResponseMessage Post(Object merchantModelObject)
        {
            Merchant merchantToAdd = Newtonsoft.Json.JsonConvert.DeserializeObject<Merchant>(merchantModelObject.ToString());

            uow.MerchantRepository.Add(merchantToAdd);
            uow.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, merchantToAdd);
            return response;
        }

        [Route("api/merchants")]
        public HttpResponseMessage Put(Object merchantObject)
        {
            Merchant merchantToEdit = Newtonsoft.Json.JsonConvert.DeserializeObject<Merchant>(merchantObject.ToString());

            uow.MerchantRepository.Attach(merchantToEdit);
            uow.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, merchantToEdit);
            return response;
        }

        [Route("api/merchants")]
        public HttpResponseMessage Delete(Object merchantObject)
        {
            Merchant merchantToDelete = Newtonsoft.Json.JsonConvert.DeserializeObject<Merchant>(merchantObject.ToString());

            uow.MerchantRepository.Delete(merchantToDelete);
            uow.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, merchantToDelete);
            return response;
        }
    }
   }