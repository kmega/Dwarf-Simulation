using DwarfsCity.DwarfContener.DwarfEquipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.DwarfContener
{
    public class Dwarf
    {
        //Field
        Backpack Backpack = new Backpack();
        private Type _attribute;

        public void AddItemsToBackpack(Item item)
        {
            Backpack.Items.Add(item);
        }

        public List<Item> GiveItemsFromBackpack()
        {
            return Backpack.Items;    
        }

        public void SetAttribute(Type attribute)
        {
            _attribute = attribute;
        }

    }
}
