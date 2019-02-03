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
			//List<string> tree11 = new List<string>()
			//{
			//	"1. Świat",
			//	"    1. Primus",
			//	"        1. Astoria",
			//	"            1. Szczeliniec",
			//	"                1. Powiat Pustogorski",
			//	"                    1. Pustogor",
			//	"                        1. Gabinet Pięknotki",
			//	"                    1. Zaczęstwo",
			//	"                        1. Cyberszkoła",
			//	"                        1. Osiedle Ptasie",
			//	"                    1. Trzęsawisko Zjawosztup",
			//	"                        1. Głodna Ziemia"
			//};

			//List<string> tree2 = new List<string>()
			//{
			//	"1. Świat",
			//	"    1. Primus",
			//	"        1. Astoria, Asteroidy"
			//};

			//List<string> tree3 = new List<string>()
			//{
			//	"1. Świat",
			//	"    1. Primus",
			//	"        1. Astoria",
			//	"            1. Szczeliniec",
			//	"                1. Powiat Pustogorski",
			//	"                    1. Zaczęstwo",
			//	"                        1. Kasyno Marzeń",
			//	"                        1. Szkoła Magów"
			//};

			//List<string> tree4 = new List<string>()
			//{
			//	"1. Świat",
			//	"    1. Esuriit",
			//	"        1. Astoria",
			//	"            1. Szczeliniec"
			//};


			FileReader fr = new FileReader();
			TreeVizualizer tv = new TreeVizualizer();
			MergingTree merge = new MergingTree();
			TreeFactory tf = new TreeFactory();

			List<string> tree1 = fr.ReadFromFile("tree1.txt");
			List<string> tree2 = fr.ReadFromFile("tree2.txt");
			List<string> tree3 = fr.ReadFromFile("tree3.txt");
			List<string> tree4 = fr.ReadFromFile("tree4.txt");

			var maintree = tf.CreateTreeOfRecords(tree1);
			var recordTree2 = tf.CreateTreeOfRecords(tree2);
			var recordTree3 = tf.CreateTreeOfRecords(tree3);
			var recordTree4 = tf.CreateTreeOfRecords(tree4);

			maintree = merge.MergeTwoTrees(maintree, recordTree2);
			maintree = merge.MergeTwoTrees(maintree, recordTree3);
			maintree = merge.MergeTwoTrees(maintree, recordTree4);

			tv.ShowTreeOfRecordsOnConsole(maintree);

			Console.ReadKey();
		}
	}
}
