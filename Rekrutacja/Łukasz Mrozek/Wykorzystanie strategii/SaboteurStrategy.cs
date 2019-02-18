using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    class SaboteurStrategy : IBehaviorOnTheShaft
    {
        public void DoYourJob(Shaft shaft, Backpack backpack)
        {
            shaft.isExist = false;
        }
    }
}
