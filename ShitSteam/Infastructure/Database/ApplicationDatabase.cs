using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShitSteam.Infastructure.Models;

namespace ShitSteam.Infastructure.Database
{
	public class ApplicationDatabase : IdentityDbContext<User>
	{
		public DbSet<Token> Tokens { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Game> Games { get; set; }

		public ApplicationDatabase() : base("ApplicationConnection")
		{
			
		}
	}
}
