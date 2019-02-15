using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Loggers
{
	public class Commentator : IComment
	{
		public void Display(string message)
		{
			Console.WriteLine(message);
		}
	}
}
