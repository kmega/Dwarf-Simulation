using MiningSimulatorByKPMM.DwarfsTypes;
using System.Collections.Generic;

namespace MiningSimulatorByKPMM.ApplicationLogic
{
    public class SimulationState
    {
        public List<Dwarf> SocietyMembers { get; set; }
        public int NumberOfDeadDwarves { get; set; }
        public bool ShouldSimulationBreak { get; set; }
    }
}