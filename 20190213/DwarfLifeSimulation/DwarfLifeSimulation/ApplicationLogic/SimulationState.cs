using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Enums;
using System.Collections.Generic;

namespace DwarfLifeSimulation.ApplicationLogic
{
    public class SimulationState
    {
        public int turn { get; set; }
        public List<IDwarf> dwarves { get; set; }
		public Dictionary<ProductType, decimal> _shopState { get; set; }
		public int _numberOfBirths { get; set; }
		public Dictionary<MineralType, decimal[]> _extractedOre { get; set; }
		public int _deadDwarves { get; set; }
		public decimal _shopBankAccount { get; set; }
		public decimal _guildBankAccount { get; set; }
		public decimal _taxBankAccount { get; set; }


		public SimulationState()
        {
            turn = 1;
            dwarves = new List<IDwarf>();
        }
    }
}
