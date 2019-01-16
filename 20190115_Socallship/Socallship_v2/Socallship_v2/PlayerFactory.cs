using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship_v2
{
	public class PlayerFactory : IPlayer, IImput
	{
		public string GetInput()
		{
			throw new NotImplementedException();
		}

		public Player GetPlayer(string name)
		{
			return new Player();
		}
		
		
	}
}
