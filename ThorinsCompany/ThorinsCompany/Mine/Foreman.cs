using System;
using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Foreman
    {
        public const int shaftCapacity = 5;
        public List<WorkingGroup> DivideDwarvesIntoWorkingGroups(List<Dwarf> dwarves)
        {
            List<WorkingGroup> workingGroups = new List<WorkingGroup>();
            if(dwarves.Count > 0)
            {
                int numberOfWorkingGroups = dwarves.Count / shaftCapacity;
                if (dwarves.Count % shaftCapacity != 0) numberOfWorkingGroups++;
                for (int i = 0, dwarfIndex = 0; i < numberOfWorkingGroups;i++)
                {
                    List<Dwarf> group = new List<Dwarf>();
                    while (group.Count < shaftCapacity && dwarfIndex < dwarves.Count)
                    {
                        group.Add(dwarves[dwarfIndex]);
                        dwarfIndex++;
                    }
                    workingGroups.Add(new WorkingGroup(group.ToArray()));
                }
            }
            return workingGroups;
        }
    
        private int GetNumberOfAvaibleShafts(Shaft[] allShafts)
        {
            int availableShafts = 0;
            foreach (var shaft in allShafts)
            {
                availableShafts += (shaft.IsAvailable) ? 1 : 0;
            }
            return availableShafts;
        }
    }
}