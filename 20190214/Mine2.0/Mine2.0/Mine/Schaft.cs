using System.Collections.Generic;

namespace Mine2._0
{
    public class Schaft
    {
        public List<IWork> SchaftWorkers { get; set; }
        public E_SchaftStatus SchaftStatus { get; set; }
        public List<E_Minerals> SchaftStats = new List<E_Minerals>();

        public Schaft()
        {
            SchaftStatus = E_SchaftStatus.Operational;
        }
    }
}
