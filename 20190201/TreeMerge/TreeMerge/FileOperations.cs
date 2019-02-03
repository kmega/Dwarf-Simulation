using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TreeMerge
{
    public class FileOperations
    {
        List<string> _tree_1;
        List<string> _tree_2;
        List<string> _mergedTree = new List<string>();

        public string[] ReadFile(string path)
        {
            string[] file = File.ReadAllLines(path);
            return file;
        }

        public static bool FirstBigger(string[] file_1, string[] file_2)
        {
            if (file_1.Count() > file_2.Count())
                return true;
            else
                return false;

        }

        public string[] MergeTrees(string[] tree_1, string[] tree_2)
        {

            _tree_1 = tree_1.ToList();
            _tree_2 = tree_2.ToList();

            int tree_1_Length = (tree_1.Length > tree_2.Length) ? tree_1.Length : tree_2.Length;
            int tree_2_Length = (tree_1.Length > tree_2.Length) ? tree_2.Length : tree_1.Length;

            for (int i = 0; i < tree_1_Length; i++)
            {

                bool executeBreak = CheckForDiversity(tree_1[i].TrimStart(), tree_2[i].TrimStart(),i);
                if (executeBreak)
                    break;

                
            }

            return _mergedTree.ToArray();
        }

        private bool CheckForDiversity(string tree_1, string tree_2, int i)
        {
            List<int> depth_1 = GetDepth(_tree_1);
            List<int> depth_2 = GetDepth(_tree_2);

            if (tree_1 != tree_2)
            {
                try
                {
                    if (depth_1[i] != depth_1[i + 1] && depth_1[i + 1] != depth_1[i + 2])
                    {
                        _mergedTree = _tree_1;

                        for (int j = i; j < _tree_2.Count; j++)
                        {
                            _mergedTree.Add(_tree_2[j]);
                        }

                        return true;
                    }
                    else
                    {
                        _mergedTree.Add(tree_1);
                        _mergedTree.Add(tree_2);

                        return false;
                    }
                }
                catch (Exception)
                {

                    _mergedTree.Add(tree_1);
                    

                    return false;
                }
               
            }
            else
            {
                _mergedTree.Add(tree_1);
                return false;
            }

            
        }

        public List<int> GetDepth(List<string> tree_1)
        {
            List<int> depth = new List<int>();

            foreach (string line in tree_1)
            {
                int whiteSpaces = GetWhiteSpacesBeforeAnalisedWord(line);
                depth.Add(whiteSpaces);
            }

            return depth;
        }

        private int GetWhiteSpacesBeforeAnalisedWord(string line)
        {
            char[] oneLine = line.ToCharArray();
            int whiteSpacesCounter = 0;

            foreach (char space in oneLine)
            {
                if (space == '1')
                    return whiteSpacesCounter;

                whiteSpacesCounter++;
            }

            return -1;
        }
    }
}
