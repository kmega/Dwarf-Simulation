using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMerge
{
    public class TreeFactory : ITreeCreator
    {       
        public Tree Create(string[] treeText)
        {
            List<Branch> Branches = new List<Branch>();

            for (int i = 0; i < treeText.Length; i++)
            {
                Branches.Add(BranchBuilder.Build(treeText[i], i));
            }

            BranchBuilder.GivePath(Branches);


            return new Tree(Branches);
        }
    }
}
