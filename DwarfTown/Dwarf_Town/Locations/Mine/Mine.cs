using Dwarf_Town.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.Locations.Mine
{
    public class Mine
    {
        private List<Shaft> _shafts;

        public Mine()
        {
            _shafts = new List<Shaft>()
            {
                new Shaft(),
                new Shaft()
            };

        }


        public void DwarvesGoWork (List<IWork> dwarvesVisitMine)
        {
            //1.First 5 dwarves go to first avaible shaft
            //    2. Work
            //    3.They return and go to restroom
            //    4.Netx dwarves go
            //    5. Dwarves back to list 


            List<IWork> restRoom = new List<IWork>();
           

            foreach (var shaft in _shafts)
            {

                if (shaft.EfficientShaft == true)
                {
                    if (dwarvesVisitMine.Count >= 5)
                    {
                        shaft.SendDwarvesDown(dwarvesVisitMine.GetRange(0, 5));
                        dwarvesVisitMine.RemoveRange(0, 5);
                        shaft.PerformWork();
                        restRoom.AddRange(shaft.GiveBackDwarves());

                    }
                    else
                    {
                        shaft.SendDwarvesDown(dwarvesVisitMine.GetRange(0, dwarvesVisitMine.Count));
                        dwarvesVisitMine.RemoveRange(0, dwarvesVisitMine.Count);
                        shaft.PerformWork();
                        restRoom.AddRange(shaft.GiveBackDwarves());
                    }

                }

            }


           
        }


        
        
    }
}
