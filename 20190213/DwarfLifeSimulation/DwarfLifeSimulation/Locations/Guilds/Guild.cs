using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Banks;
using DwarfLifeSimulation.Randomizer.MineralValueRandomizer;

namespace DwarfLifeSimulation.Locations.Guilds
{
    public class Guild
    {
        private IMineralValueRandomizer _mineralValueRandomizer;
        private int bankAccountId;
        public Guild(IMineralValueRandomizer mineralValueRandomizer = null)
        {
            _mineralValueRandomizer = (mineralValueRandomizer != null) ?
                mineralValueRandomizer : new MineralValueGenerationStretegy();
            bankAccountId = Bank.Instance.CreateAccount();
        }

        public void ExchangeResource(List<IExchange> workers)
        {
            foreach (var worker in workers)
            {
                //  var backpack = worker.EmptyBackpackContent();
                var backpack = worker.EmptyBackpackContent();
                //  var money = GetMineralValue(backpack);
                var money = GetMineralOverallValue(backpack);
                //  var moneyForDwarf = money * 0.8;
                var moneyForDwarf = money * 0.8m;
                //  worker.GetMoney(moneyForDwarf);
                worker.GetMoney(moneyForDwarf);
                //  var moneyForGuild = money * 0.2;
                var moneyForGuild = money * 0.2m;
                //  Bank.Instance.PutInto
                Bank.Instance.PayIntoAccount(bankAccountId, moneyForGuild);
            }
        }

        public decimal GetMineralOverallValue(Dictionary<MineralType, int> backpack)
        {
            decimal overallValue = 0.0m;
            foreach(var key in backpack.Keys)
            {
                var money = _mineralValueRandomizer.ExchangeMineralToValue(key);
                overallValue += money * backpack[key];
            }
            return overallValue;
        }
    }
}
