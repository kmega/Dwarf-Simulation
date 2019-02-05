using DwarfsCity.DwarfContener;
using System.Collections.Generic;
namespace DwarfsCity
{
    public class Shop
    {
        public void PerformShopping(List<Dwarf> dwarfs)
        {
            foreach(Dwarf dwarf in dwarfs)
            {
                if(dwarf.Attribute == Type.Father || dwarf.Attribute == Type.Single)
                {
                    decimal price = dwarf.Backpack.Moneys / 2;
                    dwarf.Backpack.Moneys /= 2;
                    string product = dwarf.Attribute == Type.Father ? "Alcohol" : "Food";
                    // Log.Shop(@"Dwarf bought {product}");
                }
            }
        }
    }
}