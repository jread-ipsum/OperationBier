using Microsoft.AspNet.Identity;
using OperationBier.Models.RetailModels;
using OperationBier.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OperationBier.Controllers
{
    public class RetailController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            RetailService retailService = CreateRetailService();
            var retail = retailService.GetRetailById(id);
            return Ok(retail);
        }
        public IHttpActionResult Get()
        {
            RetailService retailService = CreateRetailService();
            var retail = retailService.GetRetail();
            return Ok(retail);
        }

        [Route("api/Retail/IsOnPremise")]
        public IHttpActionResult GetRetailIsOnPremise()
        {
            RetailService retailService = CreateRetailService();
            var retailers = retailService.GetRetailIsOnPremise();
            return Ok(retailers);
        }
        public IHttpActionResult Post(CreateRetail retail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRetailService();

            if (!service.RetailCreate(retail))
                return InternalServerError();

            return Ok("The Retailer has been added!");
        }
        private RetailService CreateRetailService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var retailService = new RetailService(userId);
            return retailService;
        }
        public IHttpActionResult Put(EditRetail retail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRetailService();

            if (!service.UpdateRetail(retail))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRetailService();

            if (!service.DeleteRetail(id))
                return InternalServerError();

            return Ok("Retailer Has been Deleted.");
        }
    }
}
