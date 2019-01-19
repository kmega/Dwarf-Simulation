using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar.Warcraft
{
    public class Scout
    {
        public void Patrol (WarmapStatus cellstatuschanger)
        {
            cellstatuschanger.CellStatusChanger();
        }


    }
}
