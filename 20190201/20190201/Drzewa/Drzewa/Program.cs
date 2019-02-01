using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drzewa
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> drzewo1 = new List<string>()
			{
				"1. Świat",
				"    1. Primus",
				"        1. Astoria",
				"            1. Szczeliniec",
				"                1. Powiat Pustogorski",
				"                    1. Pustogor",
				"                        1. Gabinet Pięknotki",
				"                    1. Zaczęstwo",
				"                        1. Cyberszkoła",
				"                        1. Osiedle Ptasie",
				"                    1. Trzęsawisko Zjawosztup",
				"                        1. Głodna Ziemia"
			};
			List<Record> RecordList = new List<Record>();

			for(int i=0; i < drzewo1.Count; i++)
			{
				int depth = 0;
				string name = "";
				string path = "";

				depth = drzewo1[i].IndexOf('1');
				name = drzewo1[i].Substring(depth + 3);

				if(i != 0)
				{
					for(int j = RecordList.Count; j > 0; j--)
					{
						if(depth > RecordList[j-1]._depth)
						{
							path += RecordList[j-1]._path + RecordList[j-1]._name + "|";
							break;
						}
					}
				}

				RecordList.Add(new Record(name, path, depth));
			}
			
			Console.ReadKey();
		}
	}
}
