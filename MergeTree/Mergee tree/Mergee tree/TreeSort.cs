using System;
using System.Collections.Generic;
using System.Text;

namespace Mergee_tree
{
    public class TreeSort
    {
        public List<TreeList> sort(List<TreeList> ReadTree)
        {
            int howManyPath = 0;
            int index = 0;
            int counter = 0;
            List<TreeList> sortListTree = new List<TreeList>();
            for (int i = 0; i < ReadTree.Count; i++)
            {
                if (ReadTree[i].nameLevel == "1. �wiat")
                {
                    counter++;
                }
                if (counter < 2)
                {
                    sortListTree.Add(ReadTree[i]);
                }
                if (counter >= 2)
                {
                    for (int j = i; j < ReadTree.Count; j++)
                    {
                        for (int m = 0; m < sortListTree.Count; m++)
                        {
                            if (sortListTree[m].nameLevel == ReadTree[j].nameLevel
                                && sortListTree[m].levelNumber == ReadTree[j].levelNumber)
                            {
                                index = m;
                                howManyPath++;
                                if (howManyPath > 0)
                                {
                                    m = sortListTree.Count;
                                    j = ReadTree.Count;
                                }                               
                            }                            
                        }
                        if (howManyPath == 0)
                        {
                            sortListTree.Insert(index, ReadTree[j]);
                            j = ReadTree.Count;
                        }
                        j = ReadTree.Count;
                    }
                }
               
                //someList.Insert(2, someValue);
               
            }
            return sortListTree;
        }
    }
}
