using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drzewa
{
	public class Record
	{
		public string _name { get; set; }
		public string _path { get; set; }
		public int _depth { get; set; }

		public Record(string name, string path, int depth)
		{
			_name = name;
			_path = path;
			_depth = depth;
		}
	}
}
