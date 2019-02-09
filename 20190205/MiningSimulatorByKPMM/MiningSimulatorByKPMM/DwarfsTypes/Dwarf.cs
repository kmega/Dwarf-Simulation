using MiningSimulatorByKPMM.DwarfsTypes.BuyStrategies;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.PersonalItems;
using System.Collections.Generic;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class Dwarf : IDwarf
    {        
        public E_DwarfType DwarfType { get; private set; }
        public BankAccount BankAccount { get; private set; }
        public Backpack Backpack { get; set; }
        public bool IsAlive { get; set; }
        private IBuyAction BuyAction;

        public Dwarf(E_DwarfType dwarfType)
        {
            DwarfType = dwarfType;
            SetInitialState();
        }
        public Dwarf(E_DwarfType dwarfType, IBuyAction buyAction)
        {
            DwarfType = dwarfType;
            BuyAction = buyAction;
            SetInitialState();
        }
        private void SetInitialState()
        {
            Backpack = new Backpack();
            BankAccount = new BankAccount();
            IsAlive = true;
        }
        public Product Buy()
        {
            if (IsAlive == true)
            {
                return BuyAction.Perform(BankAccount);
            }
            else return new Product(E_ProductsType.None, 0);
        }
    }
}