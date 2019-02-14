using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Mines.ShiftGroups;
using System.Collections.Generic;
using System.Linq;

namespace DwarfLifeSimulation.Locations.Mines
{
    public class Mine
    {
        private List<Shaft> _shafts;

        public Mine(List<Shaft> shafts = null)
        {
            _shafts = (shafts!=null) ? shafts :  new List<Shaft>()
            {
                new Shaft(),
                new Shaft(),
            };            
        }

        public void Work(List<IWork> workers)
        {
            List<ShiftGroup> shiftGroups = DivideIntoGroups(workers);
            foreach (var group in shiftGroups)
            {
                var emptyShaft = FindEmptyShaft(_shafts);
                group.EnterShaft(emptyShaft);
            }
            foreach(var group in shiftGroups)
            {
                workers.AddRange(group.Members);
            }
        }

        public Shaft FindEmptyShaft(List<Shaft> shafts)
        {
            return shafts.Where(s => s.IsOccupied == false && s.ShaftStatus == ShaftStatus.Working).FirstOrDefault();
        }

        public List<ShiftGroup> DivideIntoGroups(List<IWork> workers)
        {
            List<ShiftGroup> shiftGroups = new List<ShiftGroup>();
            do
            {
                var shift = new ShiftGroup();
                for (int i = 0; i < 5; i++)
                {
                    var tempWorker = workers.Where(w => w._hasWorked == false).FirstOrDefault();
                    if(tempWorker == null)
                    {
                        break;
                    }
                    else
                    {
                        shift.Members.Add(tempWorker);
                        workers.Remove(tempWorker);
                    }
                }
                shiftGroups.Add(shift);
            } while (workers.Any(w => w._hasWorked == false));
            return shiftGroups;
        }
    }
}
