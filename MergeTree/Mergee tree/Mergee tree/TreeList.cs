using System;
using System.Collections.Generic;
using System.Text;

namespace Mergee_tree
{
    public class TreeList
    {
        public string nameLevel { get; set; }
        public int levelNumber { get; set; }


        public override bool Equals(object obj)
        {
            var other = obj as TreeList;

            if (this.nameLevel != other.nameLevel) return false;
            if (this.levelNumber != other.levelNumber) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nameLevel, levelNumber);
        }

        public override string ToString()
        {
            return $"{nameLevel} : {levelNumber.ToString()}";
        }
    }
}
