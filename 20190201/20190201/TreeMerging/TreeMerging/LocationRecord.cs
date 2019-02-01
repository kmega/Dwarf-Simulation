using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TreeMerging
{
    public class LocationRecord
    {
        public LocationRecord(int depth, string path, string content)
        {
            Depth = depth;
            Path = path;
            Content = content;
        }
        public int Depth { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(Depth, Path, Content);
        }

        public override bool Equals(object obj)
        {
            var other = obj as LocationRecord;
            if (Depth == other.Depth && Path == other.Path && Content == other.Content)
            {
                return true;
            }
            else return false;
        }

        public override string ToString()
        {
            return $"{Depth} {Path} {Content}";
        }
        
    }
}
