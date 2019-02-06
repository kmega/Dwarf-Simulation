using DwarfsCity.DwarfContener;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.MineContener
{
    public class Mine
    {
        Foreaman foreaman;
        List<Shaft> shafts = new List<Shaft>();

        public Mine()
        {
            foreaman = new Foreaman();
            shafts.Add(new Shaft());
            shafts.Add(new Shaft());
        }



        public List<Dwarf> StartWorking(List<Dwarf> dwarfsThatWillWork)
        {
            List<Dwarf> dwarfsThatWorkedAndStillAlive = new List<Dwarf>();
            
            //Send Dwarfs to shafts  -> assign dwarfs to excact shaft

            while(dwarfsThatWillWork.Count > 0)
            {
                if (shafts[0].Exist == true && dwarfsThatWillWork.Count > 0)
                {
                    foreaman.SendDwarfsToShaft(dwarfsThatWillWork, shafts[0]);    //sending to first shaft

                    if(shafts[0].Exist == true)
                    {
                        MiningDeposits(shafts[0]);
                        dwarfsThatWorkedAndStillAlive.AddRange(foreaman.LetTheDwarfsOutTheShaft(shafts[0])); // return dwarfs whose was working
                    }                     
                }

                               

                if (shafts[1].Exist == true && dwarfsThatWillWork.Count > 0)
                {
                    foreaman.SendDwarfsToShaft(dwarfsThatWillWork, shafts[1]);    //sending to second shaft    

                    if (shafts[1].Exist == true)
                    {
                        MiningDeposits(shafts[1]);
                        dwarfsThatWorkedAndStillAlive.AddRange(foreaman.LetTheDwarfsOutTheShaft(shafts[0])); // return dwarfs whose was working 
                    }                   
                }

                if (shafts[0].Exist == false && shafts[1].Exist == false) return dwarfsThatWillWork;
                    
            }

            return dwarfsThatWorkedAndStillAlive;
           
        }

        private void MiningDeposits(Shaft shaft)
        {
            foreach (var dwarf in shaft.dwarfs)
            {
                dwarf.Digging();
            }
        }
    }
}