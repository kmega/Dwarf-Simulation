using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Interfaces;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class Dwarf
    {
        public E_DwarfType DwarfType { get; set; }
        public decimal BankAccount { get; set; }
        public decimal DailySalary { get; set; }
        public List<E_Minerals> PersonalEquipment { get; set; }
        public IMineAction WorkingAction { get; set; }
        public List<IShopAction> ShoppingActions { get; set; }

        public Dwarf()
        {
            PersonalEquipment = new List<E_Minerals>();
            ShoppingActions = new List<IShopAction>();
        }
    }
}