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
            City.newsPaper.Add("Mine - " + dwarfsThatShouldBeWorking.Count + " dwarfs come to mine");
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
                    CloseTheMine(dwarfsThatShouldBeWorking, dwarfsThatWasWorked);
                    return;
                }
                
            }

            numbersOfDiggedMaterials = foreman.SumAllDiggedMaterials(dwarfsThatWasWorked);

            //Logg
            City.newsPaper.Add("Mine - " + " All dwarfs digged: " + numbersOfDiggedMaterials + " raw materials");

            //End minning, clear list dwarfs that was working and assign this dwarfs to begining list dwarfs that will be working and still alive
            CloseTheMine(dwarfsThatShouldBeWorking, dwarfsThatWasWorked);
        }

        private void WorkingOnSecondShaft(List<Dwarf> dwarfsThatShouldBeWorking, List<Dwarf> dwarfsThatWasWorked)
        {
            //Foreaman send maximum 5 dwarfs to second shaft
            foreman.SendDwarfsToShaft(dwarfsThatShouldBeWorking, shaft2);

            //If on the shaft are saboteur, shaft is destroyed and invoke event break method
            if (shaft2.dwarfs.Any(x => x.Type == TypeEnum.Saboteur))
            {
                shaft2.isExist = false;
                foreman.CallToGravedigger(shaft2.dwarfs);

                return;
            }

            //Dwarfs from second shaft go to digging
            StartDigging(shaft2);

            //Foreman let go dwarfs out from second shaft
            dwarfsThatWasWorked.AddRange(foreman.LetGoDwarfs(shaft2));
        }

        private void WorkingOnFirstShaft(List<Dwarf> dwarfsThatShouldBeWorking, List<Dwarf> dwarfsThatWasWorked)
        {
            //Foreman send maximum 5 dwarfs to first shaft
            foreman.SendDwarfsToShaft(dwarfsThatShouldBeWorking, shaft1);

            //If on the shaft are saboteur, shaft is destroyed and break method
            if (shaft1.dwarfs.Any(x => x.Type == TypeEnum.Saboteur))
            {
                shaft1.isExist = false;
                foreman.CallToGravedigger(shaft1.dwarfs);

                return;
            }
                
            

            //Dwarfs from first shaft go to digging
            StartDigging(shaft1);

            //Foreman let go dwarfs out from first shaft
            dwarfsThatWasWorked.AddRange(foreman.LetGoDwarfs(shaft1));
        }

        private void CloseTheMine(List<Dwarf> dwarfsThatShouldBeWorking, List<Dwarf> dwarfsThatWasWorked)
        {
            dwarfsThatShouldBeWorking.AddRange(dwarfsThatWasWorked);
            dwarfsThatWasWorked.Clear();
        }

        private void StartDigging(Shaft shaft)
        {
            foreach (var dwarf in shaft.dwarfs)
            {
                dwarf.Digging();
            }
        }

        private void SetShaftsToNotDestroyed(Shaft shaft1, Shaft shaft2)
        {
            shaft1.isExist = true;
            shaft2.isExist = true;
        }
    }
}