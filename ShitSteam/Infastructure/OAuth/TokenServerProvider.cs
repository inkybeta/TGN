using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using ShitSteam.Infastructure.Database;
using ShitSteam.Infastructure.Models;

namespace ShitSteam.Infastructure.OAuth
{
	public class TokenServerProvider : OAuthAuthorizationServerProvider
	{
		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			if (context.HasError)
				context.Rejected();
			string clientId;
			string clientSecret;
			if (context.TryGetBasicCredentials(out clientId, out clientSecret))
			{
				var userManager = context.OwinContext.Get<UserManager<User>>();
				var userDatabase = context.OwinContext.Get<ApplicationDatabase>();
				try
				{
					var user = await userManager.FindByNameAsync(clientId);
					if (user == null || !user.EmailConfirmed)
					{
						context.Rejected();
						return;
					}
					var token =
						await userDatabase.Tokens.Where(c => c.UserName == clientId && c.Guid == clientSecret).FirstOrDefaultAsync();
					if (token == null)
						context.Rejected();
					else
						context.Validated();
				}
				catch (SqlException e)
				{
					context.SetError("server_error", e.Message);
					context.Rejected();
				}
			}
		}
	}
}
