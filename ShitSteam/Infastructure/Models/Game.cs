using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShitSteam.Infastructure.Models
{
	public class Game
	{
		[Key]
		public long Key { get; set; }

		public string Guid { get; set; }

		public string Name { get; set; }

		public byte[] Logo { get; set; }

		public string Path { get; set; }

		public virtual ICollection<Image> Screenshots { get; set; }
	}
}
