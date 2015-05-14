using System.Web.Http;

namespace ShitSteam
{
    public partial class Startup
    {
	    public static HttpConfiguration ConfigureWebApi(HttpConfiguration config)
	    {
		    config.MapHttpAttributeRoutes();
		    config.Routes.MapHttpRoute("DefaultRoutes", "{controller}/{id}", new {id = RouteParameter.Optional});
		    return config;
	    }
    }
}
