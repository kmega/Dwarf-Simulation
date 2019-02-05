using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Guild
{
    public class Guild
    {
        public decimal Account { get; private set; }

        private Dictionary<E_MineralsType, IRandomGenerator> GoodsOnMarket =
            new Dictionary<E_MineralsType, IRandomGenerator>()

            {
                {E_MineralsType.Gold, new ValueOfGold()},
                {E_MineralsType.DirtGold, new ValueOfDirtGold() },
                {E_MineralsType.Mithril, new ValueOfMithril() },
                {E_MineralsType.Silver, new ValueOfSilver() }
            }
            ;

        private int ReturnValue(E_MineralsType mineralsType)
        {
            return GoodsOnMarket[mineralsType].GenerateSignleRandomNumber();

        }

        public void PaymentForDwars  (List<Dwarf> listofdwarfs)
        {
            foreach (var dwarf in listofdwarfs)
            {
                foreach (var mineral in dwarf.PersonalEquipment)
                {
                    decimal value = (decimal)ReturnValue(mineral);
                    Account += Math.Round((value / 4),2);
                    dwarf.DailySalary += Math.Round(((value / 4) * 3), 2); 

                }
            }




        }
    }
}

