using System.Collections.Generic;

namespace Mine2._0
{
    public class SimulationState
    {
        public int _currentDay { get; set; }
        public List<IDwarf> _allDwarves { get; set; }//
        public List<E_Minerals> _allExtractedMinerals { get; set; }//
        public int _numberOfDeadDwarves { get; set; }//
        public int _servedFoodRations { get; set; }
        public bool _shouldSimulationBreak { get; set; }
        public int _numberOfBirths { get; set; }
        public decimal _guildBankAccount { get; set; }
        public decimal _taxBankAccount { get; set; }
        public decimal _marketAccount { get; set; }
        public Dictionary<E_MarketPlace_Products, decimal> _boughtProducts; 

        public SimulationState()
        {
            _allDwarves = new List<IDwarf>();
            _allExtractedMinerals = new List<E_Minerals>();
            _guildBankAccount = 0;
            _servedFoodRations = 0;
            _taxBankAccount = 0;
            _boughtProducts = new Dictionary<E_MarketPlace_Products, decimal>();
            _marketAccount = 0;
        }
    }
}
