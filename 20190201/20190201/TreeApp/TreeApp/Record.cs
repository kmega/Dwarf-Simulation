using System;
using System.Collections.Generic;
using System.Text;

namespace TreeApp
{
    class Record
    {
        public string name { get; set; }
        public int depth { get; set; }
        public string path { get; set; }

        public Record(string name, int depth, string path)
        {
            this.name = name;
            this.path = path;
            this.depth = depth;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < this.depth; i++)
            {
                result += "--";
            }
            result += ">";
            return result + name;
        }
        public override bool Equals(object obj)
        {
            Record other = obj as Record;
            if (this.path != other.path) return false;

            return true;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(path);
        }

    }
}
