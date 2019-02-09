using System;
using System.Collections.Generic;
using DwarfLife.Diaries;
using DwarfLife.Dwarfs;

namespace DwarfLife.Buildings.Mine
{
    public class Shaft
    {
        bool _collapsed;
        readonly int _maxDwarfsInShaft;
        public string Name { get; private set; }
        public bool IsCollapsed 
        { 
            get { return _collapsed; } 
            private set { _collapsed = value; } 
        }
        public List<IDwarf> DwarfsInShaft { get; set; }

        public Shaft(string name, int maxDwarfsInShaft = 5)
        {
            Name = name;
            _collapsed = false;
            _maxDwarfsInShaft = maxDwarfsInShaft;
            DwarfsInShaft = new List<IDwarf>();
        }

        public bool IsShaftFull()
        {
            return DwarfsInShaft.Count >= _maxDwarfsInShaft;
        }
    }
}
