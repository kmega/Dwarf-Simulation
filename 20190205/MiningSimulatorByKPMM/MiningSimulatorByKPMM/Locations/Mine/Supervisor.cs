using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Locations.Mine.Factories;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public class MineSupervisor
    {
        private List<MiningSchaft> Schafts { get; set; }
        private TeamSplitter TeamSplitter = new TeamSplitter();
        private List<int> WorkingTeamMembers = new List<int>();

        public MineSupervisor()
        {
            Schafts = SchaftFactory.CreateTwoSchafts();
        }

        public int GetWorkingTeamMembersListAmount()
        {
            return WorkingTeamMembers.Count;
        }

        public void SendMinersToMine(int workersCount)
        {
            //podzielic workerow na dwa szyby
            while (workersCount > 0)
            {
                WorkingTeamMembers.Add(TeamSplitter.SplitWorkersIntoTeam(workersCount));
            }

            //przydzielic szybom grupy workerow
            //SendWorokersToCertainSchafts();

            //kazac  im pracowac -> oni sami maja wykonywac prace gdy znajda sie w szybie, ale kiedy beda wiedziec ze w nim sa?
        }

        public void DismissWorkersFromSchafts()
        {
            //potrzeba state globalny zeby trzymal stany kto aktualnie pracujexw
        }

        private void SendWorokersToCertainSchafts()
        {
        }

    }
}
