using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drzewa
{
	public class TreeFactory
	{
		public List<Record> CreateTreeOfRecords(List<string> givenTree)
		{
			List<Record> RecordList = new List<Record>();
			for (int i = 0; i < givenTree.Count; i++)
			{
				int depth = 0;
				string name = "";
				string path = "";

				depth = givenTree[i].IndexOf('1');
				name = givenTree[i].Substring(depth + 3);

				if (i != 0)
				{
					for (int j = RecordList.Count; j > 0; j--)
					{
						if (depth > RecordList[j - 1]._depth)
						{
							path += RecordList[j - 1]._path + RecordList[j - 1]._name + "|";
							break;
						}
					}
				}
				RecordList.Add(new Record(name, path, depth));
			}
			return RecordList;
		}
	}
}
