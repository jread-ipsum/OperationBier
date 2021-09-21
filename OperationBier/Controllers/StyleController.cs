using Microsoft.AspNet.Identity;
using OperationBier.Models.StyleModels;
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
    public class StyleController : ApiController
    {
        private StyleService CreateStyleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var styleService = new StyleService(userId);
            return styleService;
        }

        public IHttpActionResult Post([FromBody] StyleCreate style) //create
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStyleService();

            if (!service.CreateStyle(style))
                return InternalServerError();

            return Ok("This style has been created successfully.");
        }

        public IHttpActionResult Get() //read
        {
            StyleService styleService = CreateStyleService();
            var styles = styleService.GetStyles();
            return Ok(styles);
        }

        public IHttpActionResult Put([FromBody] StyleEdit style) //update
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStyleService();

            if (!service.UpdateStyle(style))
                return InternalServerError();

            return Ok("This style was updated successfully.");
        }

        public IHttpActionResult Delete([FromUri]int id) //delete
        {
            var service = CreateStyleService();

            if (!service.DeleteStyle(id))
                return InternalServerError();

            return Ok("This style has been deleted successfully");
        }
    }
}
