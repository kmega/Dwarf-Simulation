using System;
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
        public void PerformAction(WorkingGroup workingGroup)
        {
            foreach (Dwarf dwarf in workingGroup.Workers)
            {
                dwarf.Work(this);
                if (IsAvailable == false)
                {
                    Cementary.ReceiveDeadWorkers(workingGroup);
                    break;
                }
            }
        }

        public List<Material> PerformDigging()
        {
            return new List<Material>() { Material.Gold, Material.DirtyGold };
        }

        public void Explode()
        {
            IsAvailable = false;
        }
        public void RepairShaft() => IsAvailable = true;
    }
}