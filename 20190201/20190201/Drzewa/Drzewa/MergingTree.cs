using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drzewa
{
	public class MergingTree
	{
		public List<Record> MergeTwoTrees(List<Record> mainTree, List<Record> tree2)
		{
			foreach(Record record in tree2)
			{
				if(!(mainTree.Exists(x => (x._name == record._name) && (x._path == record._path))))
				{
					mainTree.Add(record);
				} 
			}
			return mainTree;
		}
	}
}
