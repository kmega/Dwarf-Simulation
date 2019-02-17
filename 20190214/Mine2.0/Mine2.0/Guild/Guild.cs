using System;
using System.Collections.Generic;

namespace Mine2._0
{
    public class Guild
    {
        public PersonalBankAccount _account { get; private set; }
        public  Dictionary<E_Minerals, decimal> _exchangeRates;
        private IGuildRandomizer _valueRandomizer;

        public Guild(IGuildRandomizer guildRandomizer)
        {
            _valueRandomizer = guildRandomizer;
            _account = new PersonalBankAccount();
        }

        public void ExchangeOutputToMoney(List<IMoneyOperator> dwarfList, Bank _taxes, IOutputWriter _presenter)
        {
            SetNewDailyExchangeRate();

            _account._overallIncome= 0;
            foreach (IMoneyOperator dwarf in dwarfList)
            {
                foreach (var backpackItem in dwarf._backpack)
                {
                    decimal mineralValue = _exchangeRates[backpackItem];
                    _presenter.WriteLine($"{dwarf.ToString()} mined {backpackItem} of value {mineralValue}");
                    decimal commision = Math.Floor((0.25M * mineralValue) * 100) / 100;
                    decimal tax = Math.Floor((0.23M * (mineralValue - commision)) * 100) / 100;
                    _taxes.AddTax(tax);
                    _account._overallIncome += commision;
                    mineralValue -= commision;
                    mineralValue -= tax;
                    dwarf._bankAccount._dailyIncome += mineralValue;
                }
                _presenter.WriteLine($"After commision and tax dwarf eanred {dwarf._bankAccount._dailyIncome}");
                Console.WriteLine();
                dwarf._backpack.Clear();
            }
        }

        private void SetNewDailyExchangeRate()
        {
            _exchangeRates = new Dictionary<E_Minerals, decimal>()
            {
                {E_Minerals.DritGold, _valueRandomizer.SetDirtGoldValue()},
                {E_Minerals.Gold, _valueRandomizer.SetGoldValue()},
                {E_Minerals.Silver, _valueRandomizer.SetSilverValue()},
                {E_Minerals.Mithril, _valueRandomizer.SetMithrilValue()},
            };
        }

    }
}