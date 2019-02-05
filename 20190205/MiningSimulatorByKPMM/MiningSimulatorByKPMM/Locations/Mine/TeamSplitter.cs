using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.DwarfsTypes;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public class TeamSplitter
    {
        public (List<Dwarf>, List<Dwarf>) SplitWorkersIntoTwoTeams(List<Dwarf> workers)
        {
            List<Dwarf> FirstWorkingTeam = new List<Dwarf>();

            int AmountOfAvilabeWorkers = workers.Count - 1;

            for (int i = AmountOfAvilabeWorkers; i >=0; i--)
            {
                if(i>4)
                {
                    FirstWorkingTeam.Add(workers[i]);
                    workers.RemoveAt(i);
                }
            }

            return (FirstWorkingTeam, workers);
        }
    }
}
