using System;
using System.Collections.Generic;
using System.Linq;

namespace AddTrees
{
    class TreeObject
    {
        private string Name;
        private int Depth;
        private string FullPath;

        public void parseTree(string stringTree, int depth)
        {

            List<string> list = stringTree.Split('\n').ToList();
            list.Reverse();
            list.ForEach(x =>
            {
                x.Select(x.Count(Char.IsWhiteSpace) <= (depth * 4));
            });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string treeFirst = "1. Świat\n    1. Primus\n        1. Astoria\n            1. Szczeliniec\n                1. Powiat Pustogorski\n                    1. Pustogor\n                        1. Gabinet Pięknotki\n                    1. Zaczęstwo\n                        1. Cyberszkoła\n                        1. Osiedle Ptasie\n                    1. Trzęsawisko Zjawosztup\n                        1. Głodna Ziemia";
            string treeSecond = "1. Świat\n    1. Primus\n        1. Astoria, Asteroidy";
            string treeThird = "1. Świat\n    1. Primus\n        1. Astoria\n            1. Szczeliniec\n                1. Powiat Pustogorski\n                    1. Zaczęstwo\n                        1. Kasyno Marzeń\n                        1. Szkoła Magów";
            string treeFourth = "1. Świat\n    1. Esuriit\n        1. Astoria\n            1. Szczeliniec";

            //Console.WriteLine("Hello World!");

            TreeObject tree = new TreeObject();
            tree.parseTree(treeFirst, 4);
        }
    }
}
