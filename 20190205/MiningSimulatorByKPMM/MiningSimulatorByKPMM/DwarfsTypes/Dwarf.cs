using System;
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
        public IMineAction WorkingActions { get;private set; }
        public IShopAction ShoppingActions { get;private set; }

        public Dwarf(E_DwarfType e_DwarfType, IMineAction mineAction, IShopAction shopAction)
        {
            SetInitialList();
            SetInitialProperties(e_DwarfType, mineAction, shopAction);            
        }

        private void SetInitialProperties(E_DwarfType e_DwarfType, IMineAction mineAction, IShopAction shopAction)
        {
            DwarfType = e_DwarfType;
            WorkingActions = mineAction;
            ShoppingActions = shopAction;
            BankAccount = 0.0m;
            DailySalary = 0.0m;
        }
        private void SetInitialList()
        {
            PersonalEquipment = new List<E_Minerals>();
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
            DailySalary += earnedMoney;
        }
        public void SpendMoney(decimal spentMoney)
        {
            DailySalary -= spentMoney;
        }
    }
}