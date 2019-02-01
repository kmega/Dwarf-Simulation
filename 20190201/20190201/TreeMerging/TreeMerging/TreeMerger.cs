using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TreeMerging
{
    public static class TreeMerger
    {
        public static List<LocationRecord> MergeTwoTrees(List<LocationRecord> tree1, List<LocationRecord> tree2)
        {
            List<LocationRecord> addedTrees = tree1;
            addedTrees.AddRange(tree2);
            addedTrees = addedTrees.Distinct().ToList();
            addedTrees.OrderBy(record => record.Path).ToList();
            return addedTrees;
        }

        public static List<LocationRecord> MergeTrees(List<List<LocationRecord>> trees)
        {
            var baseTree = trees.FirstOrDefault();
            for(int i = 1; i<trees.Count; i++)
            {
                baseTree = MergeTwoTrees(baseTree, trees[i]);
            }
            return baseTree.OrderBy(record => record.Path).ToList();
        }
    }
}
