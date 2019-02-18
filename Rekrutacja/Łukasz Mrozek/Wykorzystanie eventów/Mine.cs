using System;
using System.Collections.Generic;
using System.Linq;

namespace DwarfsTown
{
    public class Mine
    {      
        Shaft shaft1;
        Shaft shaft2;
        Foreaman foreman = new Foreaman();
        int numbersOfDiggedMaterials = 0;

        public Mine()
        {
            shaft1 = new Shaft();
            shaft2 = new Shaft();
        }
        public void StartWorking(List<Dwarf> dwarfsThatShouldBeWorking)
        {           
            //Register event
            foreman.ExplodedShaft += Gravedigger.OnExplodedShaft;

            List<Dwarf> dwarfsThatWasWorked = new List<Dwarf>();

            //Logg
            City.newsPaper.Add("Mine: " + dwarfsThatShouldBeWorking.Count + " dwarfs come to mine.");
            //Prepare Mine on start new day -> setting shafts to not destroyed
            SetShaftsToNotDestroyed(shaft1, shaft2);

            while(dwarfsThatShouldBeWorking.Count > 0)
            {
                //Working if shaft exist
                if (shaft1.isExist)
                {
                    //Sending to shaft, Digging, Dwarfs going out 
                    WorkingOnFirstShaft(dwarfsThatShouldBeWorking, dwarfsThatWasWorked);
                }

                //Working if shaft exist
                if (shaft2.isExist)
                {
                    //Sending to shaft, Digging, Dwarfs going out 
                    WorkingOnSecondShaft(dwarfsThatShouldBeWorking, dwarfsThatWasWorked);
                }

                //If both shaft are destroyed close the mine
                if(shaft1.isExist == false && shaft2.isExist == false)
                {
                    numbersOfDiggedMaterials = foreman.SumAllDiggedMaterials(dwarfsThatWasWorked);
                    //Logg
                    City.newsPaper.Add("Mine: All shafts are destroyed, dwarfs must to leave the mine.");
                    City.newsPaper.Add("Mine: " + " All dwarfs digged: " + numbersOfDiggedMaterials + " raw materials.");

                    CloseTheMine(dwarfsThatShouldBeWorking, dwarfsThatWasWorked);
                    return;
                }
                
            }

            //End the simulation when all dwarfs died
            if (dwarfsThatWasWorked.Count == 0)
            {
                City.newsPaper.Add("Mine: All dwarfs died.");               
                Simulation.EndOfSimulation();
            }

            

            numbersOfDiggedMaterials = foreman.SumAllDiggedMaterials(dwarfsThatWasWorked);

            //Logg
            City.newsPaper.Add("Mine: " + " All dwarfs digged: " + numbersOfDiggedMaterials + " raw materials.");

            //End minning, clear list dwarfs that was working and assign this dwarfs to begining list dwarfs that will be working and still alive
            CloseTheMine(dwarfsThatShouldBeWorking, dwarfsThatWasWorked);
        }

        private void WorkingOnSecondShaft(List<Dwarf> dwarfsThatShouldBeWorking, List<Dwarf> dwarfsThatWasWorked)
        {
            //Foreaman send maximum 5 dwarfs to second shaft
            foreman.SendDwarfsToTheShaft(dwarfsThatShouldBeWorking, shaft2);

            //Dwarfs from second shaft go to your own tasks
            DwarfsDoJob(shaft2);

            //Foreman try let go dwarfs out if the shaft is not destroyed
            EndWorkOnTheShaft(shaft2, dwarfsThatWasWorked);
        }

        private void WorkingOnFirstShaft(List<Dwarf> dwarfsThatShouldBeWorking, List<Dwarf> dwarfsThatWasWorked)
        {
            //Foreman send maximum 5 dwarfs to first shaft
            foreman.SendDwarfsToTheShaft(dwarfsThatShouldBeWorking, shaft1);

            //Dwarfs from first shaft go to your own tasks
            DwarfsDoJob(shaft1);

            //Foreman try let go dwarfs out if the shaft is not destroyed
            EndWorkOnTheShaft(shaft1, dwarfsThatWasWorked);
       
        }

        private void EndWorkOnTheShaft(Shaft shaft, List<Dwarf> dwarfsThatWasWorked)
        {
            if (shaft.isExist == false)
            {
                City.newsPaper.Add("Mine: Shaft exploded!");
                foreman.CallToGravedigger(shaft.dwarfs);
            }
            else
            {
                City.newsPaper.Add("Mine: dwarfs digged some raw materials.");
                //Foreman let go dwarfs out from first shaft
                dwarfsThatWasWorked.AddRange(foreman.LetGoDwarfs(shaft));
            }         
        }

        private void CloseTheMine(List<Dwarf> dwarfsThatShouldBeWorking, List<Dwarf> dwarfsThatWasWorked)
        {
            dwarfsThatShouldBeWorking.AddRange(dwarfsThatWasWorked);
            dwarfsThatWasWorked.Clear();
        }

        private void DwarfsDoJob(Shaft shaft)
        {
            City.newsPaper.Add("Mine: " + shaft.dwarfs.Count + " dwarfs go to the shaft.");
            foreach (var dwarf in shaft.dwarfs)
            {
                dwarf.Working(shaft);
            }         
        }

        private void SetShaftsToNotDestroyed(Shaft shaft1, Shaft shaft2)
        {
            shaft1.isExist = true;
            shaft2.isExist = true;
        }
    }
}