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

        public Mine()
        {
            shaft1 = new Shaft();
            shaft2 = new Shaft();
        }
        public void StartWorking(List<Dwarf> dwarfsThatShouldBeWorking)
        {
            List<Dwarf> dwarfsThatWasWorked = new List<Dwarf>();
            

            //Prepare Mine on start new day -> setting shafts to not destroyed
            SetShaftsToNotDestroyed(shaft1, shaft2);

            while(dwarfsThatShouldBeWorking.Count > 0)
            {
                //Working start if shaft exist
                if (shaft1.isExist)
                {
                    //Sending to shaft, Digging, Dwarfs going out 
                    WorkingOnFirstShaft(dwarfsThatShouldBeWorking, dwarfsThatWasWorked);
                }

                //Working start if shaft exist
                if (shaft2.isExist)
                {
                    //Sending to shaft, Digging, Dwarfs going out 
                    WorkingOnSecondShaft(dwarfsThatShouldBeWorking, dwarfsThatWasWorked);
                }

            }

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