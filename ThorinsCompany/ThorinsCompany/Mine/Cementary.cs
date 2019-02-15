using System;
using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Cementary
    {
        public static List<Dwarf> DeadDwarves = new List<Dwarf>();
        public static void ReceiveDeadWorkers(WorkingGroup deadGroup)
        {
            foreach(Dwarf dwarf in deadGroup.Workers)
            {
                // dwarf.IsAlive = false / removeDwarf
            }
        }


    }
}