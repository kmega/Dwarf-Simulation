﻿using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Mines.ShiftGroups;
using System.Collections.Generic;
using System.Linq;

namespace DwarfLifeSimulation.Locations.Mines
{
    public class Mine
    {
        private List<Shaft> _shafts;

        public Mine()
        {
            _shafts = new List<Shaft>()
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
            IList<IWork> tempWorkers = new List<IWork>();
            foreach (var group in shiftGroups)
            {
                foreach(var member in group.Members)
                {
                    tempWorkers.Add(member);
                }
            }
            workers = tempWorkers.ToList();
        }

        private Shaft FindEmptyShaft(List<Shaft> shafts)
        {
            return shafts.Where(s => s.IsOccupied == false && s.ShaftStatus == ShaftStatus.Working).FirstOrDefault();
        }

        private List<ShiftGroup> DivideIntoGroups(ICollection<IWork> workers)
        {
            List<ShiftGroup> shiftGroups = new List<ShiftGroup>();
            do
            {
                var shift = new ShiftGroup();
                for (int i = 0; i < 5; i++)
                {
                    var tempWorker = workers.Where(w => w._hasWorked == false).FirstOrDefault();
                    shift.Members.Add(tempWorker);
                    workers.Remove(tempWorker);
                }
                shiftGroups.Add(shift);
            } while (workers.Any(w => w._hasWorked == false));
            return shiftGroups;
        }
    }
}
