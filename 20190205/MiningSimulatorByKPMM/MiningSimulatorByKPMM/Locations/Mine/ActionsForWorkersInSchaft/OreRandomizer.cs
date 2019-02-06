using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;

namespace MiningSimulatorByKPMM.Locations.Mine.ActionsForWorkersInSchaft
{
    public class OreRandomizer : IOreRandomizer
    {
        E_Minerals mineralType;

        public Ore GetRandomMineral()
        {
            //Array mineralValues = Enum.GetValues(typeof(E_Minerals));
            var randomValue = new Random().Next(1, 100);

            if (randomValue <= 5)
                mineralType = E_Minerals.Mithril;
            else if (randomValue > 5 && randomValue <= 20)
                mineralType = E_Minerals.Gold;
            else if (randomValue > 20 && randomValue <= 55)
                mineralType = E_Minerals.Silver;
            else mineralType = E_Minerals.DirtGold;

            //E_Minerals mineral = (E_Minerals)mineralValues.GetValue(random.Next(mineralValues.Length));

            return new Ore(mineralType);
        }
    }
}
