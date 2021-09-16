using Microsoft.AspNet.Identity;
using OperationBier.Models.BeerModels;
using OperationBier.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OperationBier.Controllers
{
    [Authorize]
    public class BeerController : ApiController
    {
        private BeerService CreateBeerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var beerService = new BeerService(userId);
            return beerService;
        }

        public IHttpActionResult Post([FromBody] BeerCreate beer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBeerService();

            if (!service.CreateBeer(beer))
                return InternalServerError();

            return Ok("The beer has been successfully Added!");
        }

        public IHttpActionResult Get()
        {
            BeerService beerService = CreateBeerService();
            var beers = beerService.GetBeers();
            return Ok(beers);
        }

        public IHttpActionResult Get([FromUri]int id)
        {
            BeerService beerService = CreateBeerService();
            var beer = beerService.GetBeerById(id);
            return Ok(beer);
        }

        [Route("api/Beer/Name")]
        public IHttpActionResult Get([FromBody] string name)
        {
            BeerService beerService = CreateBeerService();
            var beer = beerService.GetBeerByName(name);
            return Ok(beer);
        }

        [Route("api/Beer/Recommended")]
        public IHttpActionResult GetRecommended()
        {
            BeerService beerService = CreateBeerService();
            var beers = beerService.GetRecommendedBeers();
            return Ok(beers);
        }

        public IHttpActionResult Put([FromBody] BeerEdit beer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBeerService();

            if (!service.UpdateBeer(beer))
                return InternalServerError();

            return Ok("The beer has been successfully updated");
        }

        public IHttpActionResult Delete([FromUri]int id)
        {
            var service = CreateBeerService();

            if (!service.DeleteBeer(id))
                return InternalServerError();

            return Ok("The beer has been successfully deleted.");
        }
    }
}
