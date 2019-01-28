using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminals
{
	class Pelican : IAnimal
	{
		private Animals _name = Animals.Pelican;
		private WhatEat _eats = WhatEat.Fish;
		private WhatDo _doThing = WhatDo.Fly;

		public void SayHi()
		{
			Console.WriteLine($"Hi I'm {_name.ToString()}, I eat {_eats.ToString()} and I {_doThing.ToString()}");
		}
	}
}
