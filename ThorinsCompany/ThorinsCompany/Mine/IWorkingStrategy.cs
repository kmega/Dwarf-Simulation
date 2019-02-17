using System.Collections.Generic;

namespace ThorinsCompany
{
    public interface IWorkingStrategy
    {
        void StartWorking(Dictionary<Material,int> dwarfMaterials,Shaft shaft);
    }
}