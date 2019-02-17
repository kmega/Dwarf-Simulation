using System.Collections.Generic;

namespace Mine2._0
{
    public interface IWorkStrategy
    {
        List<E_Minerals> ExecuteWork(Schaft schaft, IRandomizer randomizer);
    }
}
