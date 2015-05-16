using System.Web.Http;
using SimpleInjector;

namespace ShitSteam
{
    public partial class Startup
    {
	    public Container ResolveContainer(HttpConfiguration configuration, Container container = null)
	    {
		    if(container == null)
				container = new Container();

			container.RegisterWebApiControllers(configuration);
		    container.Verify();
		    return container;
	    }
	    public void RegisterDependencies(Container container)
	    {
	    }
    }
}
