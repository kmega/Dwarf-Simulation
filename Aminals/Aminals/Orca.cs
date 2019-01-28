using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminals
{
	public class Orca : IAnimal
	{
		private Animals _name = Animals.Orca;
		private WhatEat _eats = WhatEat.Meat;
		private WhatDo _doThing = WhatDo.Swim;

		public void SayHi()
		{
			Console.WriteLine($"Hi I'm {_name.ToString()}, I eat {_eats.ToString()} and I {_doThing.ToString()}");
		}
	}
}
