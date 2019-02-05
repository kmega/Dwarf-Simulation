using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DwarfsCity.DwarfContener
{
    public class Dwarf
    {
        //Field
        public Backpack Backpack = new Backpack();
        public Type Attribute { get; set; }

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
            Attribute = attribute;
        }

        public void Digging()
        {
            for (int i = 0; i < 3; i++)
            {

                //Randomize ratio to chance for a minning mineral
                var ratioChance = Randomizer.GetChanceRatio();

            //Digging minerals by ratio  -> 5% mithril, 15% gold 35% silver, 45% dirty gold
            
                if (Enumerable.Range(1, 5).Contains(ratioChance))
                    Backpack.Items.Add(Item.Mithril);
                else if (Enumerable.Range(5, 20).Contains(ratioChance))
                    Backpack.Items.Add(Item.Gold);
                else if (Enumerable.Range(20, 55).Contains(ratioChance))
                    Backpack.Items.Add(Item.Silver);
                else if (Enumerable.Range(55, 100).Contains(ratioChance))
                    Backpack.Items.Add(Item.DirtyGold);
            }
            
        }

    }
}
