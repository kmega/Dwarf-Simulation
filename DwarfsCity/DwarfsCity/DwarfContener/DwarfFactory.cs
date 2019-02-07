using DwarfsCity.DwarfContener.DwarfEquipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.DwarfContener
{
    public class DwarfFactory
    {
        public Dwarf CreateADwarf(Type attribute, decimal money = 0, List<Item> items = null)
        {
            var newDwarf = new Dwarf() { Attribute = attribute };

            newDwarf.Backpack.Items = items;
            newDwarf.Backpack.Money = money;

            return newDwarf;
        }

        public List<Dwarf> CreateMultipleDwarfs(int numberOfDwarfs, Type attribute, decimal money = 0, List<Item> items = null)
        {
            var listOfDwarfs = new List<Dwarf>();

            for (int i = 0; i < numberOfDwarfs; i++)
            {
                listOfDwarfs.Add(CreateADwarf(attribute, money, items));
            }

            return listOfDwarfs;
        }
    }
}
