using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ShitSteam.Infastructure.OAuth;

namespace ShitSteam
{
	public partial class Startup
	{
		public void ConfigureAuthentication(IAppBuilder app)
		{
			var options = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = false,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(3),
				Provider = new TokenServerProvider()
			};

			app.UseOAuthAuthorizationServer(options);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}
