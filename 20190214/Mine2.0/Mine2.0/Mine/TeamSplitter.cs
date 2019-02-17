using System.Collections.Generic;
using System.Linq;

namespace Mine2._0
{
    public class TeamSplitter
    {
        const int SchaftSize = 5;

        public List<IWork> SplitWorkersIntoTeam(List<IWork> workers)
        {
            if (workers.Count >= SchaftSize)
            {
                List<IWork> schaftOperatingTeam = workers.Take(SchaftSize).ToList();

                foreach (var schaftMember in schaftOperatingTeam)
                    workers.Remove(schaftMember);

                return schaftOperatingTeam;
            }

            List<IWork> schaftOperatingTefam = new List<IWork>(workers);
            workers.Clear();
            return schaftOperatingTefam;
        }
    }
}
