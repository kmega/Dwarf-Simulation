using System;
using System.Collections.Generic;
using System.Text;

namespace TreeMerge
{
    public class FindPath
    {
        public List<int> IndexesOfDifference(string[] tree_1,string[] tree_2)
        {
            List<int> indexes = new List<int>();

            indexes.Add(0);
            for (int i = 0; i < tree_1.Length; i++)
            {
                if (tree_1[i] != tree_2[i])
                    indexes.Add(i);
            }

            return indexes;
        }
    }
}
