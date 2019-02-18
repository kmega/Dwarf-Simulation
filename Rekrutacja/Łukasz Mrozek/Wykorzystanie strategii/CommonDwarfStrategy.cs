using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class CommonDwarfStrategy : IBehaviorOnTheShaft
    {
        public void DoYourJob(Shaft shaft, Backpack backpack)
        {
            int howManyDwarfWillDigging = City.randomizer.GetRange();
            for (int i = 0; i < howManyDwarfWillDigging; i++)
            {
                backpack.Materials.Add(City.randomizer.GetMaterial());
            }
        }
    }
}
