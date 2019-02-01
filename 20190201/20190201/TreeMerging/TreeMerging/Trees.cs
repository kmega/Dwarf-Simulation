using System;
using System.Collections.Generic;

namespace TreeMerging
{
    internal class Trees
    {
        private string Tree01 =
            "1. Świat\n" +
            "    1. Primus\n" +
            "        1. Astoria\n" +
            "            1. Szczeliniec\n" +
            "                1. Powiat Pustogorski\n" +
            "                    1. Pustogor\n" +
            "                        1. Gabinet Pięknotki\n" +
            "                    1. Zaczęstwo\n" +
            "                        1. Cyberszkoła\n" +
            "                        1. Osiedle Ptasie\n" +
            "                    1. Trzęsawisko Zjawosztup\n" +
            "                        1. Głodna Ziemia\n";

        private string Tree02 =
            "1. Świat\n" +
            "    1. Primus\n" +
            "        1. Astoria, Asteroidy\n";

        private string Tree03 =
            "1. Świat\n" +
            "    1. Primus\n" +
            "        1. Astoria\n" +
            "            1. Szczeliniec\n" +
            "                1. Powiat Pustogorski\n" +
            "                    1. Zaczęstwo\n" +
            "                        1. Kasyno Marzeń\n" +
            "                        1. Szkoła Magów\n";

        private string Tree04 =
            "1. Świat\n" +
            "    1. Esuriit\n" +
            "        1. Astoria\n" +
            "            1. Szczeliniec\n";

        internal List<string> GetListOfTrees()
        {
            List<string> listOfTrees = new List<string>()
            {
                Tree01, Tree02, Tree03, Tree04
            };

            return listOfTrees;
        }

        internal List<string> MergeTwoTrees(List<string> firstTree, List<string> secondTree)
        {
            List<string> refinedTree = new List<string>();

            for (int i = 0; i < firstTree.Count; i++)
            {
                try
                {
                    if (firstTree[i] == secondTree[i])
                    {
                        refinedTree.Add(firstTree[i]);
                    }
                    else
                    {
                        refinedTree.Add(firstTree[i]);
                        refinedTree.Add(secondTree[i]);
                    }
                }
                catch
                {
                    refinedTree.Add(firstTree[i]);
                }
            }

            bool isPresent;

            for (int i = 0; i < refinedTree.Count; i++)
            {
                isPresent = false;

                for (int j = 0; j < refinedTree.Count; j++)
                {
                    if (refinedTree[i] == refinedTree[j] && isPresent == false)
                    {
                        isPresent = true;
                    }
                    else
                    {
                        if (refinedTree[i] == refinedTree[j])
                        {
                            refinedTree.RemoveAt(j);
                        }
                    }
                }
            }

            return refinedTree;
        }
    }
}