using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class StandardWorkingStrategy : IWorkingStrategy
    {
        public void StartWorking(Dictionary<Material, int> dwarfMaterials, Shaft shaft)
        {
            List<Material> diggedMaterials = shaft.PerformDigging();
            foreach (Material material in diggedMaterials)
            {
                if (dwarfMaterials.ContainsKey(material))
                    dwarfMaterials[material] += 1;
                else
                    dwarfMaterials[material] = 1;
            }
        }
    }
}
