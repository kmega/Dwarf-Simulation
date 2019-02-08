﻿using DwarfsCity.DwarfContener;
using DwarfsCity.MineContener;
using DwarfsCity.Reports;
using System;
using System.Collections.Generic;

namespace DwarfsCity
{
    public class Cementary
    {
        public static List<Dwarf> graves { get; private set; } = new List<Dwarf>();

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

            Logger.GetInstance().AddLog("The mine is explode! The death Dwarfs: ");
            foreach (var killedDwarf in dwarfs.KilledDwarfs)
            {
                Logger.GetInstance().AddLog(killedDwarf.Attribute.ToString());

            }

        }
    }
}