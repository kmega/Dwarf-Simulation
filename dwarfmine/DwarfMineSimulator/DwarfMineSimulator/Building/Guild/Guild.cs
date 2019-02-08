using System;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;
using DwarfMineSimulator.Enums;

namespace DwarfMineSimulator.Building.Guild
{
    internal class Guild
    {
        List<Dwarf> DwarfsInGuild = new List<Dwarf>();
        decimal TaxedMoney;

        public Guild(List<Dwarf> dwarfsInGuild)
        {
            TaxedMoney = 0m;
            DwarfsInGuild = dwarfsInGuild;
        }

        public decimal Payday()
        {
            decimal totalEarnedMoney = 0m;

            foreach (var dwarf in DwarfsInGuild)
            {
                decimal earnMoney = MineralToCashConverter(dwarf.MinedMineralsReport());
                totalEarnedMoney += earnMoney;
                decimal dwarfMoney = earnMoney * 0.75m;
                TaxedMoney += earnMoney * 0.25m;
                dwarf.TakeMoney(dwarfMoney);
            }

            return totalEarnedMoney;
        }

        private decimal MineralToCashConverter(Dictionary<Minerals, int> minedMinerals)
        {
            decimal mithrilValue = 0m;
            decimal goldValue = 0m;
            decimal silverValue = 0m;
            decimal taintedGoldValue = 0m;

            if (minedMinerals.Count > 0)
            {
                mithrilValue = minedMinerals[Minerals.Mithril];
                mithrilValue *= new Random().Next(15, 25);
                goldValue = minedMinerals[Minerals.Gold];
                goldValue *= new Random().Next(10, 20);
                silverValue = minedMinerals[Minerals.Silver];
                silverValue *= new Random().Next(5, 15);
                taintedGoldValue = minedMinerals[Minerals.TaintedGold];
                taintedGoldValue *= 2;
            }

            return mithrilValue + goldValue + silverValue + taintedGoldValue;
        }

        public decimal TotalTaxedMoney()
        {
            return TaxedMoney;
        }
    }
}
