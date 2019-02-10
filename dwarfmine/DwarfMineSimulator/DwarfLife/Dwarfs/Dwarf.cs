using System;
using System.Collections.Generic;
using DwarfLife.Enums;
using DwarfLife.Diaries;
using System.Linq;

namespace DwarfLife.Dwarfs
{
    public class Dwarf : IDwarf
    {
        public int Id { get; }
        public DwarfTypes DwarfType { get; }
        public bool Alive { get; set; }
        public Dictionary<Minerals, int> MinedMinerals { get; private set; }

        public Dwarf(int id)
        {
            Id = id;
            DwarfType = DwarfTypes.None;
            Alive = true;
            DiaryHelper.Log(DiaryTarget.Console, String.Format(
                "Dwarf has born. His id = {0}, and his type is: {1}",
                Id, DwarfType));
        }

        public void Dig()
        {
            int hits = new Random().Next(1, 3);

            int chance = new Random().Next(1, 100);
            if (Enumerable.Range(1, 5).Contains(chance))
                MinedMinerals[Minerals.Mithril] += 1;

            if (Enumerable.Range(6, 20).Contains(chance))
                MinedMinerals[Minerals.Gold] += 1;

            if (Enumerable.Range(21, 55).Contains(chance))
                MinedMinerals[Minerals.Silver] += 1;

            if (Enumerable.Range(56, 100).Contains(chance))
                MinedMinerals[Minerals.TaintedGold] += 1;

        }

        public void Eat() { }
        public void Buy(ItemsInShop item) { }
    }
}
