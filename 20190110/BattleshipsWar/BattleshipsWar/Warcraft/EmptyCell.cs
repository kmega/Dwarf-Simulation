using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar.Warcraft
{
    class EmptyCell : WarmapStatus
    {
        CellProperty[,] Warmap;
        int[] Coordinates;

        public EmptyCell(CellProperty[,] warmap, int[] coordinates)
        {
            Warmap = warmap;
            Coordinates = coordinates;

        }

        public void CellStatusChanger()
        {
            string result = "Nie trafiłeś";
            Warmap[Coordinates[0], Coordinates[1]] = CellProperty.Blocked;
            Console.WriteLine(result);
        }

    }
}
