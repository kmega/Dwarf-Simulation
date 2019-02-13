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
            List<Dwarf> dwarfsThatWentToWork = new List<Dwarf>();

            //Dwarfs who come to mine are assign to list dwarfs who should be working
            List<Dwarf> dwarfsThatShouldBeWorking = dwarfs;

            //Prepare Mine on start new day -> setting shafts to not destroyed
            SetShaftsToNotDestroyed(shaft1, shaft2);

            //Foreman checking does dwarfs who should be working are exist if that, then dwarfs will send to shaft
            if(foreman.CheckDoesDwarfsExist(dwarfsThatShouldBeWorking))
            {
                //Foreaman send maximum 5 dwarfs to first shaft -> add this dwarfs to list dwarfs who went to work
                dwarfsThatWentToWork.AddRange(foreman.SendDwarfsToShaft(dwarfsThatShouldBeWorking, shaft1));

                //Foreaman send maximum 5 dwarfs to second shaft -> add this dwarfs to list dwarfs who went to work
                dwarfsThatWentToWork.AddRange(foreman.SendDwarfsToShaft(dwarfsThatShouldBeWorking, shaft2));
            }

        }

        private void SetShaftsToNotDestroyed(Shaft shaft1, Shaft shaft2)
        {
            shaft1.isExist = true;
            shaft2.isExist = true;
        }
    }
}