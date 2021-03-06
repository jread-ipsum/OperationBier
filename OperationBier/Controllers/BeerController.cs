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

        [Route("api/Beer/Name/{name}/")]
        public IHttpActionResult Get([FromUri] string name)
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

        [Route("api/Beer/abv/{abv}/")]
        public IHttpActionResult GetByABV([FromUri] double abv)    
        {
            BeerService beerService = CreateBeerService();
            var beers = beerService.GetBeersByABV(abv);
            return Ok(beers);
        }

        [Route("api/Beer/abvgreater/{abv}/")]
        public IHttpActionResult GetGreaterThan([FromUri] double abv)
        {
            BeerService beerService = CreateBeerService();
            var beers = beerService.GetBeersGreaterThan(abv);
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
        [HttpPut]
        [Route("api/Beer/Retailers")]
        public IHttpActionResult Put([FromBody] BeerRetailers beerRetailers)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBeerService();

            if (!service.UpdateBeerRetailers(beerRetailers))
                return InternalServerError();

            return Ok("Retailer/s has been successfully added.");
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
