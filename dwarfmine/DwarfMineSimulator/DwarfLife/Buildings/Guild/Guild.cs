using System;
using System.Collections.Generic;
using DwarfLife.Enums;
using DwarfLife.Diaries;

namespace DwarfLife.Buildings.Guild
{
    public class Guild
    {
        public decimal CollectedTaxes { get; private set; }

        public Guild()
        {
            CollectedTaxes = 0m;
        }

        private decimal TakeTax(decimal mineralsValue)
        {
            decimal salary = mineralsValue * 0.75m;
            CollectedTaxes += mineralsValue * 0.25m;
            return salary;
        }

        public decimal BuyMinerals(Dictionary<Minerals, int> minedMinerals)
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

            decimal salary = TakeTax(mithrilValue + goldValue + silverValue + taintedGoldValue);

            return salary;
        }
    }
}
