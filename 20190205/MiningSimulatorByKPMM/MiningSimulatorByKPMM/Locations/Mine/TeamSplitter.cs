using System;
using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.DwarfsTypes;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public class TeamSplitter
    {
        public (List<Dwarf>, List<Dwarf>) SplitWorkersIntoTwoTeams(List<Dwarf> EntryWorkers)
        {
            List<Dwarf> FirstWorkingTeam = new List<Dwarf>();
            List<Dwarf> SecondWorkingTeam = new List<Dwarf>();

            int AmountOfAvilabeWorkers = EntryWorkers.Count;

            if (AmountOfAvilabeWorkers >= 10)
            {
                FirstWorkingTeam.Take(5);
                SecondWorkingTeam.Take(5);
            }
            else throw new NotImplementedException("Empty list of workers, cannot split");

            return (FirstWorkingTeam, SecondWorkingTeam);
        }
    }
}
