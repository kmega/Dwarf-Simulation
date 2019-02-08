using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.PersonalItems;
using MiningSimulatorByKPMM.Reports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Guild
{
    public class Guild
    {

        public BankAccount Account { get; private set; }
        private ILogger _logger;
        private Dictionary<E_Minerals, ICreateOreValue> _oreOnMarket;
            

        public Guild(Dictionary<E_Minerals, ICreateOreValue> oreMarketInformations)
        {
            Account = new BankAccount();
            _logger = Logger.Instance;
            _oreOnMarket = oreMarketInformations;
        }

       
        private decimal ReturnValue(E_Minerals mineralsType)
        {
            return _oreOnMarket[mineralsType].GenerateSingleValue();

        }

        public void PaymentForDwarf(Backpack backpack, BankAccount account, bool isAlive)
        {
            if (isAlive)
            {
                foreach (var mineral in backpack.ShowBackpackContent())
                {
                    decimal value = ReturnValue(mineral.OutputType);

                    decimal tax = Math.Round((value / 4), 2);
                    Account.ReceivedMoney(tax);
                    Account.SendLastIncomeToYourAccount();


                    decimal payment = value - tax;
                    account.ReceivedMoney(payment);

                    string message = "Dwarf received " + payment + " gp for one " + mineral.OutputType + " and Guild take  " + tax + " gp provision.";
                    _logger.AddLog(message);
                }
                backpack.ShowBackpackContent().Clear();
            }

        }

        public void DwarvesVisitGuild (List<Dwarf> dwarves)
        {
            foreach (var dwarf in dwarves)
            {
                PaymentForDwarf(dwarf.Backpack, dwarf.BankAccount, dwarf.IsAlive);
            }
        }
    }
}

