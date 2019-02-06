using System;
using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.DwarfsTypes;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public class TeamSplitter
    {
        const int SchaftSize = 5;

        public int SplitWorkersIntoTeam(int workersCount)
        {
            if (workersCount > SchaftSize)
            {
                workersCount -= SchaftSize;
                return SchaftSize;
            }
            else return workersCount;
        }
    }
}
