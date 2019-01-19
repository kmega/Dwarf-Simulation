using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    public class Scanner
    {

        public bool CheckCoordinatesCorrectness(int[] tempcoordinates, CellProperty[,] warmap)
        {
           
            bool answer = false;
         
            if (tempcoordinates[0] <= 9 && tempcoordinates[1] <= 9)
            {
                if (tempcoordinates[0] >= 0 && tempcoordinates[1] >= 0)
                {
                    answer = true;
                }
            }

            return answer;
        }

        public CellProperty CheckCellStatus(CellProperty[,] warmap, int[] tempcoordinates)
        {
            CellProperty answer = warmap[tempcoordinates[0], tempcoordinates[1]];
          
            return answer;
        }


    }
}
