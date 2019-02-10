using System;
using DwarfLife.Diaries;
using DwarfLife.Enums;

namespace DwarfLife.Buildings.Shop
{
    public class Shop
    {
        public ItemsInShop Sell(ItemsInShop item)
        {
            DiaryHelper.Log(DiaryTarget.Console,
            string.Format("Shop sell {0}", item));

            return item;
        }

        public ItemsInShop Sell(ItemsInShop[] items)
        {
            //foreach (var item in items)
                //Sell(item);

            throw new NotImplementedException();
        }
    }
}
