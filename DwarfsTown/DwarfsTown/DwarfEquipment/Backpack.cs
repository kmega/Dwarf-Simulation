using System.Collections.Generic;

namespace DwarfsTown
{
    public class Backpack
    {
        public List<Materials> Materials { get; set; }
        public Backpack()
        {
            Materials = new List<Materials>();
        }
    }
}