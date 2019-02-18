using _20190218.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190218.Objects
{
	public class B : IB 
	{
		public IC _c;
		public ID _d;
		public IE _e;

		public B(IC c, ID d, IE e)
		{
			_c = c;
			_d = d;
			_e = e;
		}

		public void DoMeow()
		{
			_c.DoSomething();
			_d.DoSomething();
			_e.DoMeow();
		}
	}
}
