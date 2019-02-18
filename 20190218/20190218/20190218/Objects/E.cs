using _20190218.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190218.Objects
{
	public class E : IE
	{
		public IF _f;
		public IG _g;

		public E(IF f, IG g)
		{
			_f = f;
			_g = g;
		}

		public void DoMeow()
		{
			_f.DoSomething();
			_g.DoSomething();
		}
	}
}
