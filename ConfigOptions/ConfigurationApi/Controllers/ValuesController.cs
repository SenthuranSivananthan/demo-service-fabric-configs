using System.Web.Http;

namespace ConfigurationApi.Controllers
{
    [ServiceRequestActionFilter]
    public class ValuesController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
