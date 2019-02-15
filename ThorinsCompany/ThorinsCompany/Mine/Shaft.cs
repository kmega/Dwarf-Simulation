using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Shaft
    {
        public bool IsAvailable { get; private set; }
        public Shaft()
        {
            IsAvailable = true;
        }
        public void PerformAction(List<WorkingGroup> workingGroups)
        {
            for(int i=0;IsAvailable && i<workingGroups.Count;i++)
            {
                foreach(Dwarf dwarf in workingGroups[i].Workers)
                {
                    dwarf.WorkingStrategy.StartWorking(this);
                    if(IsAvailable == false)
                    {
                        Cementary.ReceiveDeadWorkers(workingGroups[i]);
                        break;
                    }
                }
            }
        }
        public void Explode()
        {
            IsAvailable = false;
        }
        public void RepairShaft() => IsAvailable = true;
    }
}