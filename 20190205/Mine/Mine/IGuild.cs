using System;
using System.Collections.Generic;
using System.Text;

namespace Mine
{
    interface IGuild
    {
        int ChangeOreToCoins(List<Ore> ores);
    }
}
