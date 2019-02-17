using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class BomberWorkingStrategy : IWorkingStrategy
    {
        public void StartWorking(Dictionary<Material, int> dwarfMaterials, Shaft shaft)
        {
            shaft.Explode();
        }
    }
}
