using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.PersonalItems;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    class DwarfFatherStrategy : IDwarf
    {
        private E_DwarfType DwarfType;
        private BankAccount BankAccount;
        private Backpack Backpack;
        private bool IsAlive;

        public DwarfFatherStrategy()
        {
            DwarfType = E_DwarfType.Dwarf_Father;
            BankAccount = new BankAccount();
            Backpack = new Backpack();
            IsAlive = true;
        }

        public void GetMoney(decimal income)
        {
            throw new NotImplementedException();
        }

        public Backpack ShowBackpack()
        {
            throw new NotImplementedException();
        }

        public void Work()
        {

        }

        public int Buy()
        {
            throw new NotImplementedException();
        }
    }
}
