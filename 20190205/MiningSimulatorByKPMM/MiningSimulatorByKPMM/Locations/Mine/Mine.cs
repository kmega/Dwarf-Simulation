using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Locations.Mine.Factories;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public class Mine
    {
        private List<MiningSchaft> Schafts { get; set; }

        public Mine()
        {
            Schafts = SchaftFactory.CreateTwoSchafts();
        }

        public void SendMinersToMineSupervisor(List<Dwarf> workers)
        {
            //podzielic workerow na dwa szyby


            //przydzielic szybom grupy workerow

            //kazac  im pracowac
        }

    }
}
