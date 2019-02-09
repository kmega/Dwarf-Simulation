using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;
using System.Collections.Generic;

namespace MiningSimulatorByKPMM.ApplicationLogic
{
    public class SimulationState
    {
        public List<IDwarf> Dwarves { get; set; }
        public int NumberOfDeadDwarves { get; set; }
        public bool ShouldSimulationBreak { get; set; }
        public int NumberOfBirths { get; set; }
        public Dictionary<E_Minerals, int> ExtractedOre { get; set; }
        public decimal GuildBankAccount { get; set; }
        public decimal TaxBankAccount { get; set; }
        public Dictionary<E_ProductsType, decimal> MarketState { get; set; }

        public SimulationState()
        {
            Dwarves = new List<IDwarf>();
        }
    }
}