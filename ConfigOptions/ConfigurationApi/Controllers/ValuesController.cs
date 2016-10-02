using System.Fabric;
using System.Fabric.Description;
using System.Web.Http;

namespace ConfigurationApi.Controllers
{
    [ServiceRequestActionFilter]
    public class ValuesController : ApiController
    {
        public IHttpActionResult Get(string key)
        {
            var config = FabricRuntime.GetActivationContext().GetConfigurationPackageObject("Config");

            if (config != null)
            {
                if (config.Settings?.Sections?.Contains("Database") == true)
                {
                    var settings = config.Settings.Sections["Database"];
                    if (true == settings?.Parameters.Contains(key))
                    {
                        ConfigurationProperty prop = settings.Parameters[key];
                        return Ok(prop.Value);
                    }
                }
            }

            return NotFound();
        }
    }
}
