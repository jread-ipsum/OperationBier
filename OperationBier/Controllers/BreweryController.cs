using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using OperationBier.Models.BreweryModels;
using OperationBier.Services;

namespace OperationBier.Controllers
{
    [Authorize]
    public class BreweryController : ApiController
    {
        private BreweryService CreateBreweryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var breweryService = new BreweryService(userId);
            return breweryService;
        }

        public IHttpActionResult Post([FromBody] BreweryCreate brewery)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBreweryService();

            if (!service.CreateBrewery(brewery))
                return InternalServerError();

            return Ok("The brewery has been successfully created!");
        }

        public IHttpActionResult Get()
        {
           BreweryService breweryService = CreateBreweryService();
            var brewery = breweryService.GetBreweries();
            return Ok(brewery);
        }

        public IHttpActionResult Get([FromUri] int id)
        {
            BreweryService breweryService = CreateBreweryService();
            var brewery = breweryService.GetBreweryById(id);
            return Ok(brewery);
        }

        public IHttpActionResult Put([FromBody] BreweryEdit brewery)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBreweryService();

            if (!service.UpdateBrewery(brewery))
                return InternalServerError();

            return Ok("The brewery has been successfully updated");
        }

        public IHttpActionResult Delete([FromUri] int id)
        {
            var service = CreateBreweryService();

            if (!service.DeleteBrewery(id))
                return InternalServerError();

            return Ok("The brewery has been successfully deleted.");
        }
    }
}