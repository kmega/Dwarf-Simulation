using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Drzewa
{
	public class FileReader
	{
		public List<string> ReadFromFile(string path)
		{
			List<string> listOfAllFile = new List<string>();
			return listOfAllFile = File.ReadAllLines(path).ToList();
		}
	}
}
