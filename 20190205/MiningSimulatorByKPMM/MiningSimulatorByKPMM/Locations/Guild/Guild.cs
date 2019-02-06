using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.PersonalItems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Guild
{
    public class Guild
    {
        public BankAccount Account { get; private set; }

        private Dictionary<E_Minerals, ICreateOreValue> OreOnMarket =
            new Dictionary<E_Minerals, ICreateOreValue>()

            {
                {E_Minerals.Gold, new ValueOfGold()},
                {E_Minerals.DirtGold, new ValueOfDirtGold() },
                {E_Minerals.Mithril, new ValueOfMithril() },
                {E_Minerals.Silver, new ValueOfSilver() }
            };

        public Guild()
        {
            Account = new BankAccount();
        }


        private int ReturnValue(E_Minerals mineralsType)
        {
            return OreOnMarket[mineralsType].GenerateSingleValue();

        }

        public void PaymentForDwarf(Backpack backpack, BankAccount account)
        {
            foreach (var mineral in backpack.ShowBackpackContent())
            {
                decimal value = (decimal)ReturnValue(mineral.OutputType);

                decimal tax = Math.Round((value / 4), 2);
                Account.ReceivedMoney(tax);
                Account.CalculateOverallAccount();


                decimal payment = value - tax;
                account.ReceivedMoney(payment);

                Console.WriteLine("Krasnolud otrzymał {0} gp za jednostkę {1}, a Gildia zatrzymała {2} gp podatku", payment, mineral.OutputType, tax);

            }
            backpack.ShowBackpackContent().Clear();

        }

        public void DwarvesVisitGuild (List<Dwarf> dwarves)
        {
            foreach (var dwarf in dwarves)
            {
                PaymentForDwarf(dwarf.Backpack, dwarf.BankAccount);
            }
        }
    }
}

