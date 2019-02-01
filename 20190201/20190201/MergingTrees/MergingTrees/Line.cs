using System.Collections.Generic;

namespace MergingTrees
{
    partial class Program
    {
        public class Line
        {
            public string Name { get; set; }
            public int SpaceCout { get; set; }
            public string Parent { get; set; }
            public List<string> ParentList { get; set; }

            public Line(string name, int spaceCout, string Parent)
            {
                Name = name;
                SpaceCout = spaceCout;
                this.Parent = Parent;
            }
        }
    }
}
