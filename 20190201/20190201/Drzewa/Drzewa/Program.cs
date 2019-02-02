using System;
using System.Collections.Generic;
using System.Linq;

namespace Drzewa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Location> MainTree = new List<Location>();
            TreesMerger treesMerger = new TreesMerger();

            string tree1 = "Świat|" +
                " Primus|" +
                "  Astoria|" +
                "   Szczeliniec|"+
            "    Powiat Pustogórski|" +
            "     Pustogor|" +
            "      Gabinet Pięknotki|" +
            "     Zaczęstwo|" +
            "      Cyberszkoła|" +
            "      Osiedle Ptasie|" +
            "     Trzęsawisko Zjawosztup|" +
            "      Głodna Ziemia";
            string tree2 = "Świat| Primus|  Astoria, Asteroidy";
            string tree3 = "Świat|" +
                 " Primus|" +
                 "  Astoria|" +
            "   Szczeliniec|" +
            "    Powiat Pustogórski|" +
            "     Zaczęstwo|" +
            "      Kasyno Marzeń|" +
            "      Szkoła Magów";
            string tree4 = "Świat|" +
                " Esuriit|" +
                "  Astoria|" +
                "   Szczeliniec";

            MainTree = treesMerger.MergeTree(tree1, MainTree);
            MainTree = treesMerger.MergeTree(tree2, MainTree);
            MainTree = treesMerger.MergeTree(tree3, MainTree);
            MainTree = treesMerger.MergeTree(tree4, MainTree);
          

            Console.WriteLine( String.Join("\n", MainTree));


            Console.ReadKey();
        }
    }
}
