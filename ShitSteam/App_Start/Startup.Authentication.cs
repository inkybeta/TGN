using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ShitSteam.Infastructure.OAuth;

namespace ShitSteam
{
	public partial class Startup
	{
		/// <exception cref="OverflowException"><paramref name="value" /> is less than <see cref="F:System.TimeSpan.MinValue" /> or greater than <see cref="F:System.TimeSpan.MaxValue" />. -or-<paramref name="value" /> is <see cref="F:System.Double.PositiveInfinity" />.-or-<paramref name="value" /> is <see cref="F:System.Double.NegativeInfinity" />.</exception>
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
