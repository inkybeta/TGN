using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShitSteam.Infastructure.Models
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public DateTime DateBorn { get; set; }

		public virtual ICollection<Game> Games { get; set; }

		public bool PublicUser { get; set; }

		public virtual ICollection<User> Friends { get; set; } 
	}
}
