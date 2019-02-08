using System;
using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.Enums;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public partial class MineSupervisor
    {
        public class MineStatsUpdater
        {
            public (List<TemporaryWorker>, Dictionary<E_Minerals, int>) UpdateDailyStats(List<TemporaryWorker> _allWorkers, Dictionary<E_Minerals, int> GetMineSupervisorStats)
            {
                foreach (var mineral in Enum.GetValues(typeof(E_Minerals)))
                {
                    foreach (var worker in _allWorkers)
                    {
                        int sum = 0;
                        var AmountOfMineralsOfNotDeadWorkers = worker.backpack.ShowBackpackContent().Count(x => x.OutputType == (E_Minerals)mineral);
                        if (AmountOfMineralsOfNotDeadWorkers != 0)
                        {
                            sum += AmountOfMineralsOfNotDeadWorkers;
                            GetMineSupervisorStats[(E_Minerals)mineral] += sum;
                        }
                    }
                }

                return (_allWorkers, GetMineSupervisorStats);
            }
        }
    }
}