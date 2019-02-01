using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMerge
{
    public class Branch
    {
        public int Depth { get; set; }
        public int Record { get; set; }
        public string Name { get; set; }
        public List<string> Path { get; set; } = new List<string>();


        public Branch(int depth, int record, string name)
        {
            Depth = depth;
            Record = record;
            Name = name;           
        }

        
        
    }
}
