using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drzewa
{
	public class TreeVizualizer
	{
		public void ShowTreeOfRecordsOnConsole(List<Record> treeToShow)
		{
			foreach (Record record in treeToShow)
			{
				for (int i = 0; i < record._depth; i++)
				{
					Console.Write(" ");
				}
				Console.WriteLine("1. " + record._name);
			}
		}
	}
}
