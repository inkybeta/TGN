using System.ComponentModel.DataAnnotations;

namespace ShitSteam.Infastructure.Models
{
	public class Token
	{
		[Key]
		public string Guid { get; set; }

		public string UserName { get; set; }
	}
}
