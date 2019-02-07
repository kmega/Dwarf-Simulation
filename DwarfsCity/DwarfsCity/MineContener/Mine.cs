using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.MineContener
{
    public class Mine: IReport
    {
        Foreaman foreaman;
        List<Shaft> shafts = new List<Shaft>();

        public Mine()
        {
            foreaman = new Foreaman();
            shafts.Add(new Shaft());
            shafts.Add(new Shaft());
        }

        public void GiveReport(string message)
        {
            Logger.GetInstance().AddLog(message);
        }

        public List<Dwarf> StartWorking(List<Dwarf> dwarfsThatWillWork)
        {
            GiveReport(dwarfsThatWillWork.Count + " dwarfs come to mine and will be digging");

            InitializeMineEveryDay();
            
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
                        dwarfsThatWorkedAndStillAlive.AddRange(foreaman.LetTheDwarfsOutTheShaft(shafts[1])); // return dwarfs whose was working 
                    }                   
                }

                if (shafts[0].Exist == false && shafts[1].Exist == false) return dwarfsThatWillWork;
                    
            }

            if (dwarfsThatWillWork.Count == 0 && dwarfsThatWorkedAndStillAlive.Count == 0)
                throw new Exception("All dwarfs died, simulation is over!");

            GiveReport(dwarfsThatWorkedAndStillAlive.Count + " dwarfs " + " come back happily on the surface!");
            return dwarfsThatWorkedAndStillAlive;
           
        }

        private void InitializeMineEveryDay()
        {
            shafts[0].Exist = true;
            shafts[1].Exist = true;
        }

        private void MiningDeposits(Shaft shaft)
        {
            foreach (var dwarf in shaft.dwarfs)
            {
                GiveReport(dwarf.Attribute + " goes to digging");
                dwarf.Digging();
            }
        }
    }
}