using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.Business
{
    public class Customer
    {

        public Customer(int money, CustomerType type)
        {
            Money = money;
            Type = type;
            HouseGoods = new List<Goods>();
        }
        public Customer(int money, CustomerType type, List<Goods> goods)
        {
            Money = money;
            Type = type;
            HouseGoods = goods;
        }

        public int Money { get; }
        public CustomerType Type { get; }
        public List<Goods> HouseGoods { get; set; }

        
    }
}
