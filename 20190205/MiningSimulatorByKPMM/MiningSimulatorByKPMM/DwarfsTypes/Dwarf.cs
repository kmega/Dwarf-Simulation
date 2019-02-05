using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Interfaces;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class Dwarf
    {
        public E_DwarfType DwarfType { get;private set; }
        public decimal BankAccount { get;private set; }
        public decimal DailySalary { get;private set; }
        public List<E_Minerals> PersonalEquipment { get;private set; }
        public List<IMineAction> WorkingActions { get;private set; }
        public List<IShopAction> ShoppingActions { get;private set; }
        public Dwarf(E_DwarfType e_DwarfType, IMineAction mineAction, IShopAction shopAction)
        {
            SetInitialLists();
            DwarfType = e_DwarfType;
            WorkingActions.Add(mineAction);
            ShoppingActions.Add(shopAction);
        }
        private void SetInitialLists()
        {
            PersonalEquipment = new List<E_Minerals>();
            WorkingActions = new List<IMineAction>();
            ShoppingActions = new List<IShopAction>();
        }
        public void AddMinedMaterial(E_Minerals e_Mineral)
        {
            PersonalEquipment.Add(e_Mineral);
        }
        public void RemoveSingleMaterialFromEquipment(E_Minerals e_Mineral)
        {
            PersonalEquipment.Remove(e_Mineral);
        }
        public void EarnMoney(decimal earnedMoney)
        {
            DailySalary = earnedMoney;
        }
    }
}