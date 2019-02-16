using System;
using System.Collections.Generic;
using ThorinsCompany.Raports;

namespace ThorinsCompany
{
    public class Cementary
    {
        public static int _deadDwarves = 0;
        public static void ReceiveDeadWorkers(WorkingGroup deadGroup)
        {
            _deadDwarves += deadGroup.Workers.Length;
            // Logger.GetInstance().AddLog("Group has died in fatal accident");

            foreach (var dwarf in deadGroup.Workers)
            {
                dwarf.Dead();
            }
            
        }

        public static void Funeral(List<Dwarf> allDwarves)
        {
            for (int i = 0; i < allDwarves.Count; i++)
            {
                if (allDwarves[i].GetLifeStatus() == false)
                {
                    allDwarves.Remove(allDwarves[i]);
                    i = -1;
                }
            }
        }


    }
}