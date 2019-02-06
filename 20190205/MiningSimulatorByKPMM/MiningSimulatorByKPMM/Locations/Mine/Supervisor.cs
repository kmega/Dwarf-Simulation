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
        private TeamSplitter teamSplitter { get; }
        private List<Dwarf> FirstWorkingTeam, SecondWorkingTeam;

        public MineSupervisor()
        {
            Schafts = SchaftFactory.CreateTwoSchafts();
        }

        public void SendMinersToMine(List<Dwarf> workers)
        {
            //podzielic workerow na dwa szyby
            (FirstWorkingTeam, SecondWorkingTeam) = teamSplitter.SplitWorkersIntoTwoTeams(workers);

            //przydzielic szybom grupy workerow
            SendWorokersToCertainSchafts();

            //kazac  im pracowac -> oni sami maja wykonywac prace gdy znajda sie w szybie, ale kiedy beda wiedziec ze w nim sa?
        }

        public void DismissWorkersFromSchafts()
        {
            //potrzeba state globalny zeby trzymal stany kto aktualnie pracujexw
        }

        private void SendWorokersToCertainSchafts()
        {
            Schafts[0].AssingWorkers(FirstWorkingTeam);
            Schafts[1].AssingWorkers(SecondWorkingTeam);
        }

    }
}
