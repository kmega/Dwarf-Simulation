using System;
using System.Collections.Generic;
using DwarfLife.Diaries;
using DwarfLife.Dwarfs;

namespace DwarfLife.Buildings.Mine
{
    public class Shaft
    {
        readonly int _maxDwarfsInShaft;
        public string Name { get; private set; }
        public bool IsCollapsed { get; private set; }
        public List<IDwarf> DwarfsInShaft { get; set; }

        public Shaft(string name, int maxDwarfsInShaft = 5)
        {
            Name = name;
            IsCollapsed = false;
            _maxDwarfsInShaft = maxDwarfsInShaft;
            DwarfsInShaft = new List<IDwarf>();
        }

        public void Collapse()
        {
            IsCollapsed = true;
            DwarfsInShaft.ForEach(dwarf => dwarf.Alive = false);
        }

        public bool IsShaftFull()
        {
            return DwarfsInShaft.Count >= _maxDwarfsInShaft;
        }
    }
}
