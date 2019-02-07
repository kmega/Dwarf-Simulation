﻿using System;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;
using DwarfMineSimulator.Enums;
using System.Linq;

namespace DwarfMineSimulator.Building.Mine
{
    internal class Shaft : IShaft
    {
        string Name;
        List<Dwarf> DwarfsInShaft;
        List<Dwarf> ShaftQueue;
        bool Collapsed;
        int MaxDwarfsInShaft;

        public Shaft(string name, int maxDwarfsInShaft = 5)
        {
            Name = name;
            ShaftQueue = new List<Dwarf>();
            DwarfsInShaft = new List<Dwarf>();
            Collapsed = false;
            SetMaxNumberOfDwarfsInShaft(maxDwarfsInShaft);
        }

        public void SetMaxNumberOfDwarfsInShaft(int maxNumber)
        {
            MaxDwarfsInShaft = maxNumber;
        }

        public bool IsFullOfDwarfes()
        {
            return DwarfsInShaft.Count >= MaxDwarfsInShaft ? true : false;
        }

        public void DwarfGoIntoShaftQueue(Dwarf worker)
        {
            ShaftQueue.Add(worker);
        }

        public void BeginShift()
        {
            while (ShaftQueue.Any(x => x.IsWorkDone() == false))
            {
                DwarfsInShaft = ShaftQueue.Take(5).ToList();
                DwarfsInShaft.ForEach(x =>
                {
                    Console.WriteLine("Dwart {0} has {1} hit with a pickaxe left", x.GetId(), x.MaxHitsInShaft());
                    Console.WriteLine("Dwart {0} will dig in the {1}", x.GetId(), Name);
                });

                ShaftQueue.Skip(5).ToList().ForEach(worker =>
                {
                    Console.WriteLine("Dwart {0} will dig in the {1}, but now there is no space, so dwarf is waiting...", worker.GetId(), Name);
                });

                DwarfsInShaft.ForEach(Mine);
                ShaftQueue.RemoveAll(x => x.IsWorkDone() == true);
            }
        }

        private void Mine(Dwarf dwarf)
        {
            if (dwarf.MaxHitsInShaft() > 0)
            {
                dwarf.MineMinerals();
            }

            if (dwarf.MaxHitsInShaft() == 0)
            {
                dwarf.EndOfShift();
            }
        }

        public string ShaftName()
        {
            return Name;
        }

        public bool IsCollapsed()
        {
            return Collapsed;
        }
    }
}
