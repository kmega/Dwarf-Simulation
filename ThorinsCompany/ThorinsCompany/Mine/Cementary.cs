using System;
using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Cementary
    {
        public static List<Dwarf> DailyDeadDwarves = new List<Dwarf>();
        public static List<Dwarf> AllDeadDwarves = new List<Dwarf>();
        public static void BurryDeadDwarves(List<Dwarf> dwarvesThatDiedInShaft)
        {
            foreach (var dwarf in dwarvesThatDiedInShaft)
            {
                DailyDeadDwarves.Add(dwarf);
                AllDeadDwarves.Add(dwarf);
            }
        }
    }
}