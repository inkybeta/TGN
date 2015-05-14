using System.Collections.Generic;

namespace ShitSteam.Infastructure.Models
{
	public class Game
	{
		public string Name { get; set; }

		public byte[] Logo { get; set; }

		public string Path { get; set; }

		public virtual ICollection<Image> Screenshots { get; set; }
	}
}
