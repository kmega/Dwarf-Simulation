﻿using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.MineContener
{
    public class Shaft:IReport
    {
        public List<Dwarf> dwarfs { get; set; } = new List<Dwarf>();
        public bool Exist { get; private set; } = true;

        public List<string> Reports { get; set; } = new List<string>();

        public delegate void ShaftExplodedEvendHandler(object o, ShaftExplodedEventArgs e);
        public event ShaftExplodedEvendHandler ShaftExploded;

        public virtual void OnShaftExploded()
        {
            if (ShaftExploded != null && Exist == false)
            {
                ShaftExploded(this, new ShaftExplodedEventArgs() { KilledDwarfs = dwarfs });
            }
        }

        public void ChangeShaftExistStatusToDestroyed()
        {
            Exist = false;
            GiveReport("Shaft exploded!");
            OnShaftExploded();
        }

        public void GiveReport(string message)
        {
            Reports.Add(message);
        }
    }
}
