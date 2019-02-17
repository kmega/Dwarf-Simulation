using System;
using System.Collections.Generic;

namespace Mine2._0
{
    public class Dwarf : IDwarf
    {
        public E_DwarfType _dwarfType { get; }
        public bool _isAlive { get; set; }
        public List<E_Minerals> _backpack { get; set; }
        public IWorkStrategy _workStrategy { get; set; }
        public IBuyStrategy _buyStrategy { get; set; }
        public PersonalBankAccount _bankAccount { get; set; }

        public Dwarf(E_DwarfType dwarfType, IWorkStrategy workStrategy, IBuyStrategy buyStrategy)
        {
            _dwarfType = dwarfType;
            _isAlive = true;
            _backpack = new List<E_Minerals>();
            _workStrategy = workStrategy;
            _bankAccount = new PersonalBankAccount();
            _buyStrategy = buyStrategy;
        }

        public void Work(Schaft schaft, IRandomizer randomizer)
        {
            if(_isAlive == true)
                _backpack = _workStrategy.ExecuteWork(schaft, randomizer);
        }

        public void Buy(decimal account, Dictionary<E_MarketPlace_Products, decimal> marketStats, IOutputWriter _presenter)
        {
            _buyStrategy.ExecuteShopping(account, marketStats, _presenter);
        }

        public bool GetIsAliveStatus()
        {
            return _isAlive;
        }

        //public List<E_Minerals> GetBackpack()
        //{
        //    return _backpack;
        //}

        public override string ToString()
        {
            return _dwarfType.ToString();
        }

        public int GetBackpackQunatity()
        {
            return _backpack.Count;
        }

        public decimal GetDailyWageToSpend()
        {
            return Math.Floor((_bankAccount._dailyIncome * 0.5M) * 100) / 100;
        }

        public void SetNewDailyAfterTransaction(decimal rest)
        {
            this._bankAccount._dailyIncome = rest;
        }

        public List<E_Minerals> ShowBackpack()
        {
            return _backpack;
        }
    }
}
