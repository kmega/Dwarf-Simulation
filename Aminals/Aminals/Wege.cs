using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminals
{
	public class Wege : IAnimal
	{
		private Animals _name = Animals.Homo;
		private WhatEat _eats = WhatEat.Wegetable;
		private WhatDo _doThing = WhatDo.Walk;

		public void SayHi()
		{
			Console.WriteLine($"Hi I'm {_name.ToString()}, I eat {_eats.ToString()} and I {_doThing.ToString()}");
		}
	}
}
