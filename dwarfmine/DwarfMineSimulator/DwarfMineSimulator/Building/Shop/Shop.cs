using System;
using System.Linq;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;
using DwarfMineSimulator.Enums;

namespace DwarfMineSimulator.Building.Shop
{
    internal class Shop
    {
        int Food;
        int Alcohol;
        List<Dwarf> DwarfsInShop;

        public Shop(List<Dwarf> dwarfsInShop)
        {
            Food = 0;
            Alcohol = 0;
            DwarfsInShop = dwarfsInShop;
        }

        public void DoShopping()
        {
            List<Dwarf> FatherDwarfs = DwarfsInShop.Where(dwarf =>
                dwarf.GetDwarfType() == DwarfTypes.Father).ToList();

            List<Dwarf> SingleDwarfs = DwarfsInShop.Where(dwarf =>
                dwarf.GetDwarfType() == DwarfTypes.Single).ToList();

            FatherDwarfs.ForEach(dwarf => dwarf.BoughtGoods(ShopGoods.Food));
            SingleDwarfs.ForEach(dwarf => dwarf.BoughtGoods(ShopGoods.Alcohol));
        }
    }
}
