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
        List<TemporaryWorker> workers;
        E_MiningSchaftStatus SchaftStatus = E_MiningSchaftStatus.Operational;

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

        public void ExecuteWorkStrategy(IOreRandomizer oreRandomizer, IOreUnitAmountRandomizer oreUnitAmountRandomizer)
        {
            Dictionary<bool, ISchaftOperator> WorkStrategy = new Dictionary<bool, ISchaftOperator>()
            {
                {true, new SchaftDestructor()},
                {false, new SchaftExtractor()}
            };

            bool strategy = workers.Exists(x => x.type == E_DwarfType.Dwarf_Sluggard);
            SchaftStatus =  WorkStrategy[strategy].DoWork(workers, SchaftStatus, oreRandomizer, oreUnitAmountRandomizer);
        }

        internal class SchaftDestructor : ISchaftOperator
        {
            E_MiningSchaftStatus ISchaftOperator.DoWork(List<TemporaryWorker> workers, E_MiningSchaftStatus SchaftStatus, IOreRandomizer oreRandomizer, IOreUnitAmountRandomizer oreUnitAmountRandomizer)
            {
                workers.ForEach(x => x.isAlive = false);
                return E_MiningSchaftStatus.Broken;
            }
        }

        internal class SchaftExtractor : ISchaftOperator
        {
            E_MiningSchaftStatus ISchaftOperator.DoWork(List<TemporaryWorker> workers, E_MiningSchaftStatus SchaftStatus, IOreRandomizer oreRandomizer, IOreUnitAmountRandomizer oreUnitAmountRandomizer)
            {
                foreach (var worker in workers)
                {
                    int amountOfOres = oreUnitAmountRandomizer.GetAmountOfOreUnintsToRandom();

                    for (int i = 0; i < amountOfOres; i++)
                    {
                        worker.backpack.AddSingleOre(oreRandomizer.GetRandomMineral());
                    }
                }
                return E_MiningSchaftStatus.Operational;
            }
        }

    }
}
