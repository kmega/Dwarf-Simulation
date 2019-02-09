using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public partial class MineSupervisor
    {
        public class StaffDisposer
        {
            public void SendWorokersToCertainSchafts(List<MiningSchaft> Schafts, List<TemporaryWorker> _allWorkers)
            {
                foreach (MiningSchaft schaft in Schafts)
                {
                    if (schaft.GetSchaftStatus() != E_MiningSchaftStatus.Broken)
                    {
                        var CurrentlyWorkingTeam = new TeamSplitter().SplitWorkersIntoTeam(_allWorkers.Where(x =>
                                                                                                        x.backpack.ShowBackpackContent().Count == 0 &&
                                                                                                        x.isAlive == true).ToList());
                        RemoveWorkingMinersFromAllworkers(CurrentlyWorkingTeam, _allWorkers);
                        schaft.SetSchaftWorkers(CurrentlyWorkingTeam);
                    }
                }
            }

            public void RemoveWorkingMinersFromAllworkers(List<TemporaryWorker> CurrentlyWorkingTeam, List<TemporaryWorker> _allWorkers)
            {
                for (int i = 0; i < CurrentlyWorkingTeam.Count; i++)
                {
                    _allWorkers.Remove(CurrentlyWorkingTeam[i]);
                }
            }
        }
    }
}