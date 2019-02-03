using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeMerge
{
    public class ClearTree
    {
        //List<string> _newTree;
        //string[] _tree_1;
        //string[] _tree_2;

        //public string[] SortTree(string[] tree_1, string[] tree_2)
        //{
        //    _newTree = new List<string>();
        //    _tree_1 = tree_1;
        //    _tree_2 = tree_2;

        //    for (int i = 0; i < 2* FileOperations.TakeBiggerFile(tree_1, tree_2).Count(); i++)
        //    {
        //       i += CompareTrees(i);
        //        if (i > _newTree.Count)
        //            break;
        //    }

        //    return _newTree.ToArray();
        //}

        //private int CompareTrees(int i)
        //{
        //    List<string> tmp = new List<string>();
           

        //    try
        //    {
        //        if (_tree_1[i] == _tree_2[i] && _tree_1[i + 1] != _tree_2[i + 1])
        //        {
                   

        //            for (int z = i; z < _tree_2.Length; z++)
        //            {
        //                tmp.Add(_tree_2[z]);
        //            }

        //                tmp.Add(_tree_1[i+tmp.Count]);
                    
        //        }
        //        else
        //            _newTree.Add(_tree_1[i]);
        //    }
        //    catch (Exception)
        //    {
        //        string[] tree = FileOperations.TakeBiggerFile(_tree_1, _tree_2);

        //            for (int z = i; z < tree.Length; z++)
        //            {
        //                tmp.Add(tree[z]);
        //            }

        //    }
                    
                
                
            

        //    for (int z = 0; z < tmp.Count; z++)
        //    {
        //        _newTree.Add(tmp[z]);
        //    }

        //    if (tmp.Count > 0)
        //        return tmp.Count - 1;
        //    else
        //        return 0;
        //}

        //public string[] CreateTreeFromPath(string[] tree_1, string[] tree_2)
        //{
        //    FindPath pathFinder = new FindPath();
        //    _newTree = new List<string>();

        //    List<int> indexes = pathFinder.IndexesOfDifference(tree_1, tree_2);

        //    for (int i = 0; i < indexes.Count; i++)
        //    {
        //        int modifier = (i == indexes.Count - 1) ? 0 : 1;

        //        for (int j = indexes[i]; j < indexes[i + modifier]; j++)
        //        {

        //        }
        //    }
        //}
    }
}
