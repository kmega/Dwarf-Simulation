using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dwarf_Town.Locations.Mine
{
    public class Mine
    {
        public List<Shaft> Shafts;
        private List<MineralType> _oreRegister;
                      




        public Mine()
        {
            Shafts = new List<Shaft>()
            {
                new Shaft(),
                new Shaft()
            };
            _oreRegister = new List<MineralType>();

        }


        public void DwarvesGoWork (List<IWork> dwarvesVisitMine)
        {
            do
            {
                foreach (var shaft in Shafts)
                {
                    if (shaft.EfficientShaft == true)
                    {
                        if (dwarvesVisitMine.Count >= 5)
                        {
                            shaft.SendDwarvesDown(dwarvesVisitMine.GetRange(0, 5));
                            shaft.PerformWork();
                            _oreRegister.AddRange(dwarvesVisitMine.SelectMany(i => i.ShowWhatYouBroughtOut()));
                            dwarvesVisitMine.RemoveRange(0, 5);

                        }
                        else
                        {
                            shaft.SendDwarvesDown(dwarvesVisitMine.GetRange(0, dwarvesVisitMine.Count));
                            shaft.PerformWork();
                            _oreRegister.AddRange(dwarvesVisitMine.SelectMany(i => i.ShowWhatYouBroughtOut()));
                            dwarvesVisitMine.RemoveRange(0, dwarvesVisitMine.Count);
                        }
                    }
                }
            } while (dwarvesVisitMine.Count > 0);



        }
        
    }
}
