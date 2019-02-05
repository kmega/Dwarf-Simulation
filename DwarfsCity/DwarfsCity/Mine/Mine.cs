using DwarfsCity.DwarfContener;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.Mine
{
    public class Mine
    {
        Foreaman foreaman;
        List<Shaft> shafts;

        public Mine()
        {
            foreaman = new Foreaman();
            shafts.Add(new Shaft());
            shafts.Add(new Shaft());
        }

        public void StartWorking(List<Dwarf> dwarfs)
        {           
            //Send Dwarfs to shafts  -> assign dwarfs to excact shaft
            foreaman.SendDwarfsToShaft(dwarfs, shafts);    
                      

        }
    }
}