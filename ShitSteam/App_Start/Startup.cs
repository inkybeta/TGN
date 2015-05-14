using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using ShitSteam.Infastructure.Database;
using ShitSteam.Infastructure.Models;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

[assembly: OwinStartup(typeof(ShitSteam.Startup))]

namespace ShitSteam
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var httpConfig = ConfigureWebApi(new HttpConfiguration());
			var container = ResolveContainer(httpConfig, new Container());
			httpConfig.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

			app.CreatePerOwinContext(() => new ApplicationDatabase());
			app.CreatePerOwinContext<UserManager<User>>(
				(IdentityFactoryOptions<UserManager<User>> options, IOwinContext context) =>
					new UserManager<User>(new UserStore<User>(context.Get<ApplicationDatabase>())));

			ConfigureAuthentication(app);
			WebApiConfig.Register(httpConfig);
			app.UseWebApi(httpConfig);
			// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
		}
	}
}
