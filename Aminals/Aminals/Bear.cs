using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminals
{
	public class Bear : IAnimal
	{
		private Animals _name = Animals.Bear;
		private WhatEat _eats = WhatEat.Everything;
		private WhatDo _doThing = WhatDo.Walk;

		public void SayHi()
		{
			Console.WriteLine($"Hi I'm {_name.ToString()}, I eat {_eats.ToString()} and I {_doThing.ToString()}" );
		}
	}
}
