using System;
using System.Collections.Generic;
using System.Linq;

namespace drzewa
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] FirstTree = "1. Świat\n    1. Primus\n        1. Astoria\n            1. Szczeliniec\n                1. Powiat Pustogorski\n                    1. Pustogor\n                        1. Gabinet Pięknotki\n                    1. Zaczęstwo\n                        1. Cyberszkoła\n                        1. Osiedle Ptasie\n                    1. Trzęsawisko Zjawosztup\n                        1. Głodna Ziemia".Split("\n");
            string[] SecondTree = "1. Świat\n    1. Primus\n        1. Astoria, Asteroidy".Split("\n");
            string[] ThirdTree = "1. Świat\n    1. Primus\n        1. Astoria\n            1. Szczeliniec\n                1. Powiat Pustogorski\n                    1. Zaczęstwo\n                        1. Kasyno Marzeń\n                        1. Szkoła Magów".Split("\n");
            string[] FourthTree = "1. Świat\n    1. Esuriit\n        1. Astoria\n            1. Szczeliniec".Split("\n");

            List<Leaf> leaves = new List<Leaf>();
            leaves = Merge(FirstTree, leaves);
            leaves = Merge(SecondTree, leaves);
            leaves = Merge(ThirdTree, leaves);
            leaves = Merge(FourthTree, leaves);

            leaves.ForEach(x => x.Path.Replace(x.Name.TrimStart(), string.Empty));

            List<Leaf> listWithRemovedDuplicates = leaves.GroupBy(x => x.Name).Select(x => x.First()).ToList();

            foreach (Leaf item in listWithRemovedDuplicates)
                Console.WriteLine(item.Name);

            Console.ReadKey();
        }

        private static List<Leaf> Merge(string[] Tree, List<Leaf> leaves)
        {
            for (int i = 0; i < Tree.Length; i++)
            {
                Leaf child = new Leaf();
                child.Depth = Tree[i].IndexOf('1');
                child.Name = Tree[i];

                if (leaves.Count == 0 || i == 0)
                    child.Path += " " + Tree[i].Trim();
                else
                {
                    int j = leaves.Count - 1;
                    int temporaryLeadDepth;

                    do
                    {
                        if (leaves[j].Depth < child.Depth)
                        {
                            child.Path = leaves[j].Path + Tree[i].Trim();
                            break;
                        }

                        temporaryLeadDepth = leaves[j].Depth;
                        j--;

                        if (j < 0)
                            break;
                    } while (temporaryLeadDepth >= child.Depth);
                }
                leaves.Add(child);
            }

            return leaves.OrderBy(x => x.Path).ToList();

        }
    }

    public class Leaf
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Depth { get; set; }

        public override string ToString()
        {
            return Name.TrimStart();
        }
    }
}
