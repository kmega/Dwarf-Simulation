using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.PersonalItems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Guild
{
    public class Guild
    {
        public decimal Account { get; private set; }

        private Dictionary<E_Minerals, ICreateOreValue> GoodsOnMarket =
            new Dictionary<E_Minerals, ICreateOreValue>()

            {
                {E_Minerals.Gold, new ValueOfGold()},
                {E_Minerals.DirtGold, new ValueOfDirtGold() },
                {E_Minerals.Mithril, new ValueOfMithril() },
                {E_Minerals.Silver, new ValueOfSilver() }
            }
            ;

        private int ReturnValue(E_Minerals mineralsType)
        {
            return GoodsOnMarket[mineralsType].GenerateSingleValue();

        }

        public void PaymentForDwars  (Backpack backpack, )
        {
            foreach (var dwarf in listofdwarfs)
            {
                foreach (var mineral in dwarf.P)
                {
                    decimal value = (decimal)ReturnValue(mineral);
                    decimal tax = Math.Round((value / 4), 2);
                    decimal payment = value - tax;
                    dwarf.EarnMoney(payment);
                    Account += tax;
                    Console.WriteLine("Krasnolud otrzymał {0} gp za jednostkę {1}, a Gildia zatrzymała {2} gp podatku", payment,mineral,tax);

                }
            }




        }
    }
}

