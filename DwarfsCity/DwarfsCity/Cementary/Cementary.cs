using DwarfsCity.DwarfContener;
using DwarfsCity.MineContener;
using System;
using System.Collections.Generic;

namespace DwarfsCity
{
    public class Cementary
    {
        private static List<Dwarf> graves { get; set; } = new List<Dwarf>();
        public void BurryDeadDwarfs(List<Dwarf> deadDwarfs)
        {
            deadDwarfs.Clear();

            //give report it the shape of log/logger 
        }

        private static void AddKilledDwarfsToGraves(List<Dwarf> killedDwarfs)
        {
            foreach (var dwarf in killedDwarfs)
            {
                graves.Add(dwarf);
            }
        }

        public static void OnShaftExploded(object o, ShaftExplodedEventArgs dwarfs)
        {
            AddKilledDwarfsToGraves(dwarfs.KilledDwarfs);

            Console.WriteLine("kopalnia wybuchla, zginely krasnale:");
            foreach (var killedDwarf in dwarfs.KilledDwarfs)
            {
                Console.WriteLine(killedDwarf.Attribute);
            }
        }
    }
}