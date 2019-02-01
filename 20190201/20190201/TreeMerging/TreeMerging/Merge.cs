using System;
using System.Collections.Generic;

namespace TreeMerging
{
    internal class Merge
    {

        internal void TreeMerge()
        {
            Trees trees = new Trees();
            List<string> listOfTrees = trees.GetListOfTrees();

            int longestTreeRecordsCount = listOfTrees[0].Split('\n').Length;

            for (int i = 1; i < listOfTrees.Count; i++)
            {
                if (longestTreeRecordsCount < listOfTrees[i].Split('\n').Length)
                {
                    longestTreeRecordsCount = listOfTrees[i].Split('\n').Length;
                }
            }

            string[] firstRecords, secondRecords;
            List<string> mergedTree = new List<string>();
            List<string> secondTree = new List<string>();

            for (int i = 1; i < listOfTrees.Count; i++)
            {
                firstRecords = listOfTrees[0].Split('\n');
                secondRecords = listOfTrees[i].Split('\n');

                for (int j = 0; j < firstRecords.Length; j++)
                {
                    mergedTree.Add(firstRecords[j]);
                }
                for (int k = 0; k < secondRecords.Length; k++)
                {
                    secondTree.Add(secondRecords[k]);
                }

                mergedTree = trees.MergeTwoTrees(mergedTree, secondTree);
            }

            for (int i = 0; i < mergedTree.Count; i++)
            {
                Console.WriteLine(mergedTree[i]);
            }

            Console.ReadKey();
        }
    }
}