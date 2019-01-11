using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
    public class Player
    {
		public string Name { get; set; }
		public BoardGame board = new BoardGame();
		public List<Ship> ships { get; set; }

		public Player(string name)
		{
			Name = name;
		}

		
	}
}
