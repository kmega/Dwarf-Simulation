using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;
using System.Collections.Generic;

namespace MiningSimulatorByKPMM.ApplicationLogic
{
    public class SimulationState
    {
        public List<Dwarf> Dwarves { get; set; }
        public int NumberOfDeadDwarves { get; set; }
        public bool ShouldSimulationBreak { get; set; }
        public int NumberOfBirths { get; set; }
        public Dictionary<E_Minerals, int> extractedOre { get; set; }
        public decimal guildBankAccount { get; set; }
        public decimal taxBankAccount { get; set; }
        public Dictionary<E_ProductsType, decimal> marketState { get; set; }

        public SimulationState()
        {
            Dwarves = new List<Dwarf>();
        }
    }
}