using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.PersonalItems;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class Dwarf
    {
        public E_DwarfType DwarfType { get; private set; }
        public BankAccount BankAccount { get; private set; }
        public Backpack Backpack { get; set; }
        public bool IsAlive { get; set; }

        public Dwarf(E_DwarfType dwarfType)
        {
            DwarfType = dwarfType;
            SetInitialState();
        }

        private void SetInitialState()
        {
            Backpack = new Backpack();
            BankAccount = new BankAccount();
            IsAlive = true;
        }
    }
}