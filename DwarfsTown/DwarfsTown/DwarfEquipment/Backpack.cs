using System;
using System.Collections.Generic;
using System.Text;

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
