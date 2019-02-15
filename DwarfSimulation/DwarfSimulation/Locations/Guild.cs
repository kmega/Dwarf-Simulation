using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Guild
    {
        internal decimal _taxedMoney;

        internal decimal _goldPrice;
        internal decimal _silverPrice;
        internal decimal _mithrilPrice;
        internal decimal _taintedGoldPrice;
                
        public Guild(IMineralsPrices randomizer)
        {
            _goldPrice = randomizer.ReturnMineralPrice(Mineral.Gold);
            _mithrilPrice = randomizer.ReturnMineralPrice(Mineral.Mithril);
            _silverPrice = randomizer.ReturnMineralPrice(Mineral.Silver);
            _taintedGoldPrice = randomizer.ReturnMineralPrice(Mineral.TaintedGold);
        }

        internal void ExchangeDwarvesMineralsAndGiveThemMoney(List<Dwarf> listOfDwarfs)
        {
            foreach (var dwarf in listOfDwarfs)
            {
                decimal money = 0;

                money += dwarf.BackPack[Mineral.Mithril] * _mithrilPrice;
                money += dwarf.BackPack[Mineral.Gold] * _goldPrice;
                money += dwarf.BackPack[Mineral.Silver] * _silverPrice;
                money += dwarf.BackPack[Mineral.TaintedGold] * _taintedGoldPrice;

                _taxedMoney += (money * 0.25M);

                dwarf.Wallet += (money *0.75M);
            }

        }

        internal void ClearBackpacks(List<Dwarf> listOfDwarves)
        {
            foreach (var dwarf in listOfDwarves)
            {
                ClearBackpack(dwarf);
            }
        }

        internal void ClearBackpack(Dwarf dwarf)
        {
            dwarf.BackPack[Mineral.Mithril] = 0;
            dwarf.BackPack[Mineral.Gold] = 0;
            dwarf.BackPack[Mineral.Silver] = 0;
            dwarf.BackPack[Mineral.TaintedGold] = 0;
        }


        internal void Display()
        {
            List<string> guildpDailyStats = new List<string>();
            Outputer outputer = new Outputer();
            guildpDailyStats.Add("");
            guildpDailyStats.Add("### Guild ###");
            guildpDailyStats.Add($"Taxed money: {Decimal.Round(_taxedMoney,2)}.");
            outputer.Display(guildpDailyStats);
        }

        internal void UpdateSimulationRaport(Raport raport)
        {
            raport.TotalMoneyEarned += _taxedMoney;
        }

        internal decimal TotalTaxedMoneyValue()
        {
            return _taxedMoney;
        }
    }
}
