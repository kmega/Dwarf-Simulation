using System.Collections.Generic;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public partial class MineSupervisor
    {
        public class SchaftMender
        {
            public void FixSchafts(List<MiningSchaft> Schafts)
            {
                Schafts.ForEach(x => x.FixSchaft());
            }
        }
    }
}