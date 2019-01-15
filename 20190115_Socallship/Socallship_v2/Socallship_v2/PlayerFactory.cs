using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship_v2
{
	public class PlayerFactory : IPlayer
	{
		public Player GetPlayer(string name)
		{
			return new Player();
		}
	}
}
