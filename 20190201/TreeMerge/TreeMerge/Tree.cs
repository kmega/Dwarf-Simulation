using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMerge
{
    public class Tree
    {
        public List<Branch> Branches = new List<Branch>();

        public Tree(List<Branch> _branches)
        {
            Branches = _branches;
        }
    }
}
