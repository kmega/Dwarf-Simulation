using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThorinsCompany
{
    public class Mine
    {

        public Shaft[] allShafts;
        public Foreman Master;
        
        public Mine()
        {
            allShafts = new Shaft[2] { new Shaft(), new Shaft() };
            Master = new Foreman();
        }

        public void PerformMining(List<Dwarf> dwarves)
        {
            RepairShafts();
            List<WorkingGroup> workingGroups = Master.DivideDwarvesIntoWorkingGroups(dwarves);
            PerformActionsInShafts(workingGroups);
        }

        private void RepairShafts()
        {
            foreach (Shaft shaft in allShafts)
                shaft.RepairShaft();
        }
        private List<Shaft> GetAvailableShafts()
        {
            List<Shaft> availableShafts = new List<Shaft>();
            foreach (Shaft shaft in allShafts)
                availableShafts.Add(shaft);

            return availableShafts;
        }
        private void PerformActionsInShafts(List<WorkingGroup> workingGroups)
        {
            Stack<WorkingGroup> workingGroupStack = new Stack<WorkingGroup>(workingGroups);
            while(workingGroupStack.Any())
            {
                var availableShafts = GetAvailableShafts();
                if (availableShafts.Count == 0)
                    break;
                for(int i=0; workingGroupStack.Any() && i < availableShafts.Count;i++)
                    availableShafts[i].PerformAction(workingGroupStack.Pop());
            }
        }

    }
        

}

