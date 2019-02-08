using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public partial class MineSupervisor
    {
        public class WorkProcessor
        {
            private List<MiningSchaft> Schafts;
            private List<TemporaryWorker> _allWorkers;

            public void ProcessWork(List<MiningSchaft> Schafts, List<TemporaryWorker> _allWorkers, IOreRandomizer _oreRandomizer, IOreUnitAmountRandomizer _oreUnitAmountRandomizer)
            {
                do
                {
                    new StaffDisposer().SendWorokersToCertainSchafts(Schafts, _allWorkers);

                    foreach (var schaft in Schafts)
                    {
                        if (schaft.GetSchaftStatus() != E_MiningSchaftStatus.Broken)
                        {
                            schaft.ExecuteWorkStrategy(_oreRandomizer, _oreUnitAmountRandomizer);
                            _allWorkers.AddRange(schaft.RemoveWorkersFromSchaft());
                        }
                    }

                    this.Schafts = Schafts;
                    this._allWorkers = _allWorkers;

                } while (IfCanStillWork());
            }

            public bool IfCanStillWork()
            {
                bool condition = false;

                foreach (var worker in _allWorkers)
                {
                    if (worker.backpack.ShowBackpackContent().Count == 0 && worker.isAlive == true)
                        condition = true;
                    //else condition = false;
                }

                if (Schafts.All(x => x.GetSchaftStatus() == E_MiningSchaftStatus.Broken))
                    condition = false;

                return condition;
            }
        }
    }
}