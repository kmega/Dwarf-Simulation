using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Banks;
using DwarfLifeSimulation.Loggers;
using DwarfLifeSimulation.Randomizer.MineralValueRandomizer;

namespace DwarfLifeSimulation.Locations.Guilds
{
    public class Guild
    {
        private ILog _logger;
        private IMineralValueRandomizer _mineralValueRandomizer;
        private int bankAccountId;
        private Dictionary<MineralType, decimal[]> _overallResources; // 0 index stands for quantity
                                                                      // 1 index stands for value

        public Guild(ILog logger = null, IMineralValueRandomizer mineralValueRandomizer = null)
        {
            _mineralValueRandomizer = (mineralValueRandomizer != null) ?
                mineralValueRandomizer : new MineralValueGenerationStretegy();
            bankAccountId = Bank.Instance.CreateAccount();
            _overallResources = new Dictionary<MineralType, decimal[]>();
            _overallResources.Add(MineralType.Mithril, new decimal[2]);
            _overallResources.Add(MineralType.Gold, new decimal[2]);
            _overallResources.Add(MineralType.Silver, new decimal[2]);
            _overallResources.Add(MineralType.TaintedGold, new decimal[2]);
            _logger = (logger != null) ? logger : new Logger();
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
            foreach (var key in backpack.Keys)
            {
                var money = _mineralValueRandomizer.ExchangeMineralToValue(key) * backpack[key];
                _overallResources[key][0] += backpack[key];
                _overallResources[key][1] += money;
                if (backpack[key] != 0)
                {
                    _logger.AddLog($"Guild has sold {backpack[key]} {key} for {money}");
                }
                overallValue += money;
            }
            return overallValue;
        }
        public string GetSummary(MineralType mineralType)
        {
            return $"We sold {_overallResources[mineralType][0]} in value of {_overallResources[mineralType][1]}";
        }
    }
}
