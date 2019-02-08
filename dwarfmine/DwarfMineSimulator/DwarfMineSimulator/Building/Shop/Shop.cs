using System;
using System.Linq;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;
using DwarfMineSimulator.Enums;

namespace DwarfMineSimulator.Building.Shop
{
    internal class Shop
    {
        List<Dwarf> DwarfsInShop;

        public Shop(List<Dwarf> dwarfsInShop)
        {
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
