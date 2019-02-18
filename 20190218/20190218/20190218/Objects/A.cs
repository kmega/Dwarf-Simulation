using _20190218.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190218.Objects
{
	public class A 
	{
		private IB _b;

		public A(IB b)
		{
			_b = b;
		}

		public void JustDoThis()
		{
			_b.DoMeow();
		}
	}
}
