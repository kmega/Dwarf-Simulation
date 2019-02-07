﻿using System;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;
using DwarfMineSimulator.Enums;

namespace DwarfMineSimulator.Building.Mine
{
    internal class ShaftA : IShaft
    {
        string name = "ShaftA";
        List<Dwarf> DwarfsInShaft;
        List<Dwarf> ShaftQueue;
        bool Collapsed;
        int MaxDwarfsInShaft;

        public ShaftA()
        {
            DwarfsInShaft = new List<Dwarf>();
            Collapsed = false;
            SetMaxNumberOfDwarfsInShaft(5);
        }

        public void SetMaxNumberOfDwarfsInShaft(int maxNumber = 5)
        {
            MaxDwarfsInShaft = maxNumber;
        }

        public bool IsFullOfDwarfes()
        {
            return DwarfsInShaft.Count > MaxDwarfsInShaft ? true : false;
        }

        public void DwarfGoIntoShaft(Dwarf worker)
        {
            if (worker.IsAlive())
            {
                DwarfsInShaft.Add(worker);
                if (worker.GetDwarfType().Equals(DwarfTypes.Suicider))
                {
                    DwarfsInShaft.ForEach(x =>
                    {
                        x.SummonDeath();
                    });
                }
            }
        }

        public string ShaftName()
        {
            return name;
        }

        public bool IsCollapsed()
        {
            return Collapsed;
        }
    }
}
