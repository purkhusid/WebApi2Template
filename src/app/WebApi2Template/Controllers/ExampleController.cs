using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using WebApi2Template.Models;

namespace WebApi2Template.Controllers
{
    public class ExampleController : ApiController
    {
        [HttpGet]
        [Route("api/orders/{orderId}")]
        [SwaggerResponse(HttpStatusCode.OK, null, typeof(ExampleModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Order was not found.")]
        public HttpResponseMessage ExampleGet()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
