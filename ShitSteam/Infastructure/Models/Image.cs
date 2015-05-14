using System.ComponentModel.DataAnnotations;

namespace ShitSteam.Infastructure.Models
{
	public class Image
	{
		[Key]
		public ulong Id { get; set; }

		public string Guid { get; set; }

		public byte[] Binary { get; set; }
	}
}
