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

    public partial class MiningSchaft
    {
        List<TemporaryWorker> workers;
        E_MiningSchaftStatus SchaftStatus = E_MiningSchaftStatus.Operational;

        public E_MiningSchaftStatus GetSchaftStatus() => SchaftStatus;

        public void FixSchaft()
        {
            SchaftStatus = E_MiningSchaftStatus.Operational;
        }

        public List<TemporaryWorker> GetWorkers() => workers;

        public void DestroyShaft()
        {
            SchaftStatus = E_MiningSchaftStatus.Broken;
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

        public void ExecuteWorkStrategy(IOreRandomizer oreRandomizer, IOreUnitAmountRandomizer oreUnitAmountRandomizer)
        {
            Dictionary<E_DwarfType, ISchaftStrategy> WorkStrategy = new Dictionary<E_DwarfType, ISchaftStrategy>()
            {
                {E_DwarfType.Dwarf_Suicide, new SchaftDestructorStrategy()},
                {E_DwarfType.Dwarf_Father, new SchaftExtractorStrategy()},
                {E_DwarfType.Dwarf_Single, new SchaftExtractorStrategy()},
                {E_DwarfType.Dwarf_Sluggard, new SchaftExtractorStrategy()},
            };

            foreach (var worker in workers)
            {
                WorkStrategy[worker.type].DoWork(worker, oreRandomizer, oreUnitAmountRandomizer);

                if(workers.Exists(x => x.isAlive == false))
                {
                    DestroyShaft();
                    workers.ForEach(x => x.isAlive = false);
                    workers.ForEach(x => x.backpack.ShowBackpackContent().Clear());
                    break;
                }
            }
        }
    }
}
