using DwarfsCity.DwarfContener;
using DwarfsCity.MineContener;
using DwarfsCity.Reports;
using System;
using System.Collections.Generic;

namespace DwarfsCity
{
    public class Cementary:IReport
    {
        public static List<Dwarf> graves { get; private set; } = new List<Dwarf>();

        private void AddKilledDwarfsToGraves(List<Dwarf> killedDwarfs)
        {
            foreach (var dwarf in killedDwarfs)
            {
                graves.Add(dwarf);
            }
        }

        public void OnShaftExploded(object o, ShaftExplodedEventArgs dwarfs)
        {
            AddKilledDwarfsToGraves(dwarfs.KilledDwarfs);

            GiveReport("The mine is explode! The death Dwarfs: ");
            foreach (var killedDwarf in dwarfs.KilledDwarfs)
            {                
                GiveReport("killedDwarf.Attribute");               
            }
            
        }

        public void GiveReport(string message)
        {
            Logger.GetInstance().AddLog(message);
        }
    }
}