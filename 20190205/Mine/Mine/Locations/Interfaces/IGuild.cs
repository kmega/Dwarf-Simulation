using System.Collections.Generic;

namespace Mine.Locations.Interfaces
{
    interface IGuild
    {
        int ChangeOreToCoins(List<Ore> ores);
    }
}
