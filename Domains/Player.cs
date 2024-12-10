using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
	public class Player
	{
		public string Username { get; set; }
		public int Points { get; set; } = 0;
		public List<Card>? Cards { get; set; }
		public int ValueOfCards { get; set; } = 0;
		public string LastAction { get; set; } = "Connected";

		public Player() { }

		public Player(string username, string lastAction)
		{
			this.Username = username;
			this.LastAction = lastAction;
		}
	}
}
