using System;
using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.ActionsForWorkersInSchaft;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;
using MiningSimulatorByKPMM.PersonalItems;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace MiningSimulatorByKPMM.Locations.Mine.SubMineLocations
{
    public class MiningSchaft
    {
        E_MiningSchaftStatus SchaftStatus = E_MiningSchaftStatus.Operational;
        List<TemporaryWorker> workers;

        public E_MiningSchaftStatus GetSchaftStatus() => SchaftStatus;

        public void FixSchaft()
        {
            SchaftStatus = E_MiningSchaftStatus.Operational;
        }

        public void SetSchaftWorkers(List<TemporaryWorker> workers)
        {
            this.workers = workers;
        }

        public List<TemporaryWorker> RemoveWorkersFromSchaft()
        {
            List<TemporaryWorker> happyWorkers = new List<TemporaryWorker>( workers );
            workers.Clear();
            return happyWorkers;

        }

        public void ExecuteWork(IOreRandomizer oreRandomizer, IOreUnitAmountRandomizer oreUnitAmountRandomizer)
        {
            if (workers.Exists(x => x.type == E_DwarfType.Dwarf_Sluggard))
            {
                workers.ForEach(x => x.isAlive = false);
                SchaftStatus = E_MiningSchaftStatus.Broken;
                return;
            }

            foreach (var worker in workers)
            {
                int amountOfOres = oreUnitAmountRandomizer.GetAmountOfOreUnintsToRandom();

                for (int i = 0; i < amountOfOres; i++)
                {
                    worker.backpack.AddSingleOre(oreRandomizer.GetRandomMineral());
                }
            }
        }
    }
}
