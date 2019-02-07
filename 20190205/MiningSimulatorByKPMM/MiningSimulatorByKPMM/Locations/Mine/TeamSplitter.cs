using System;
using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.DwarfsTypes;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public class TeamSplitter
    {
        const int SchaftSize = 5;

        public List<TemporaryWorker> SplitWorkersIntoTeam(List<TemporaryWorker> workers)
        {
            if(workers.Count >= SchaftSize)
            {
                List<TemporaryWorker> schaftOperatingTeam = workers.Take(SchaftSize).ToList();

                foreach (var schaftMember in schaftOperatingTeam)
                    workers.Remove(schaftMember);

                return schaftOperatingTeam;
            }

            List<TemporaryWorker> returnList = new List<TemporaryWorker>(workers);
            workers.Clear();
            return returnList;
        }
    }
}
