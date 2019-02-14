using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;

namespace MiningSimulatorByKPMM.Locations.Mine.ActionsForWorkersInSchaft
{
    public class OreRandomizer : IOreRandomizer
    {
        private E_Minerals MineralType { get; set; }

        public E_Minerals GetOreType()
        {
            return MineralType;
        }

        public Ore GetRandomMineral()
        {
            //Array mineralValues = Enum.GetValues(typeof(E_Minerals));
            var randomValue = new Random().Next(1, 100);

            if (randomValue <= 5)
                MineralType = E_Minerals.Mithril;
            else if (randomValue > 5 && randomValue <= 20)
                MineralType = E_Minerals.Gold;
            else if (randomValue > 20 && randomValue <= 55)
                MineralType = E_Minerals.Silver;
            else MineralType = E_Minerals.DirtGold;

            //E_Minerals mineral = (E_Minerals)mineralValues.GetValue(random.Next(mineralValues.Length));

            return new Ore(MineralType);
        }
    }
}
