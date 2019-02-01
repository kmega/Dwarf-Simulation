using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mergee_tree
{
    public class SaveTreeListAndWrite
    {
        ReadTree ReadTree = new ReadTree();
        public List<TreeList> Tree = new List<TreeList>();
        public List<TreeList> Write()
        {
            string line = "";
            string sourceDirectory = "C:/Users/Lenovo/code/primary/MergeTree/Tree";
            var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");
            foreach (string currentFile in txtFiles)
            {
                StreamReader file = new StreamReader(currentFile);
                while ((line = file.ReadLine()) != null)
                {
                    var test = ReadTree.read(line);
                    Tree.Add(new TreeList { nameLevel = test[1],
                        levelNumber = int.Parse(test[0]) });
                }
            }
            //Tree.Sort(new Sortmaster());
            //List<TreeList> noDupes = Tree.Distinct().ToList();
            return Tree;
        }

    }

    public class Sortmaster : IComparer<TreeList>
    {
        public int Compare(TreeList x, TreeList y)
        {
            return x.levelNumber - y.levelNumber;
        }
    }
}