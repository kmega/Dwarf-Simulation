using System;
using System.Linq;
using System.Collections.Generic;
using DwarfLife.Diaries;
using DwarfLife.Dwarfs;
using DwarfLife.Enums;

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

            DiaryHelper.Log(Constans.diaryTarget,
                string.Format("New Shaft named {0} has been created. {1} can dig in the Shaft.",
                Name, _maxDwarfsInShaft));
        }

        public void CheckForSaboteur()
        {
            if (DwarfsInShaft.Any(dwarf => dwarf.DwarfType.Equals(DwarfTypes.Saboteur)))
            {
                IsCollapsed = true;
                DwarfsInShaft.ForEach(dwarf => dwarf.Alive = false);
                DwarfsInShaft.Clear();

                DiaryHelper.Log(Constans.diaryTarget,
                    string.Format("{0} has been collapsed.",
                    Name));
            }
        }

        public bool IsShaftFull()
        {
            return DwarfsInShaft.Count >= _maxDwarfsInShaft;
        }

        public void RebuildAfterCollapsed()
        {
            IsCollapsed = false;
        }
    }
}
