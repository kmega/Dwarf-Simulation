using System;
using System.Collections.Generic;

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
        public void StartWorking(List<Dwarf> dwarfs)
        {
            List<Dwarf> dwarfsThatWasWorked = new List<Dwarf>();

            //Dwarfs who come to mine are assign to list dwarfs who should be working
            List<Dwarf> dwarfsThatShouldBeWorking = dwarfs;

            //Prepare Mine on start new day -> setting shafts to not destroyed
            SetShaftsToNotDestroyed(shaft1, shaft2);

            while(dwarfsThatShouldBeWorking.Count > 0)
            {
                //Foreaman send maximum 5 dwarfs to first shaft -> add this dwarfs to list dwarfs who went to work
                foreman.SendDwarfsToShaft(dwarfsThatShouldBeWorking, shaft1);

                //Dwarfs from first shaft go to digging
                StartDigging(shaft1);

                //Foreman let go dwarfs out from first shaft
                dwarfsThatWasWorked.AddRange(foreman.LetGoDwarfs(shaft1));

                //Foreaman send maximum 5 dwarfs to second shaft -> add this dwarfs to list dwarfs who went to work
                foreman.SendDwarfsToShaft(dwarfsThatShouldBeWorking, shaft2);

                //Dwarfs from second shaft go to digging
                StartDigging(shaft2);

                //Foreman let go dwarfs out from second shaft
                dwarfsThatWasWorked.AddRange(foreman.LetGoDwarfs(shaft2));
            }          

        }

        private void StartDigging(Shaft shaft1)
        {
            foreach (var dwarf in shaft1.dwarfs)
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