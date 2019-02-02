using System.Collections.Generic;

namespace MergingTrees
{
    partial class Program
    {
        public class Line
        {
            public string Name { get; set; }
            public int SpaceCout { get; set; }
            public Parent Parent { get; set; }
            public List<Parent> ParentList { get; set; }

            public Line(string name, int spaceCout, string parent)
            {
                Name = name;
                SpaceCout = spaceCout;
                this.Parent = new Parent(parent, spaceCout);
            }
        }
    }

    public class Parent
    {
        public string parent;
        public int spaceCout;

        public Parent(string parent, int spaceCout)
        {
            this.parent = parent;
            this.spaceCout = spaceCout;
        }
    }
}
