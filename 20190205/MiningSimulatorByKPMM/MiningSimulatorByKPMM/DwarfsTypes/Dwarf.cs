using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Interfaces;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class Dwarf
    {
        E_DwarfType DwarfType { get; set; }
        decimal BankAccount { get; set; }
        decimal DailySalary { get; set; }
        List<E_Minerals> PersonalEquipment { get; set; }
        List<IMineAction> WorkingActions { get; set; }
        List<IShopAction> ShoppingActions { get; set; }
        public Dwarf()
        {
            PersonalEquipment = new List<E_Minerals>();
            WorkingActions = new List<IMineAction>();
            ShoppingActions = new List<IShopAction>();
        }
    }
}