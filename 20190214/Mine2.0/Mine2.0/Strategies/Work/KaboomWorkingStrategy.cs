using System.Collections.Generic;

namespace Mine2._0
{
    public class KaboomWorkingStrategy : IWorkStrategy
    {
        public List<E_Minerals> ExecuteWork(Schaft schaft, IRandomizer randomizer)
        {
            schaft.SchaftStatus = E_SchaftStatus.Broken;
            schaft.SchaftStats.Clear();

            foreach (Dwarf worker in schaft.SchaftWorkers)
            {
                worker._backpack.Clear();
                worker._isAlive = false;
            }

            return new List<E_Minerals>();
        }
    }


}
