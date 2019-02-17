using System.Collections.Generic;

namespace Mine2._0
{
    public interface IWork
    {
        void Work(Schaft schaft, IRandomizer randomizer);
        bool GetIsAliveStatus();
        int GetBackpackQunatity();
        List<E_Minerals> ShowBackpack();
    }
}
