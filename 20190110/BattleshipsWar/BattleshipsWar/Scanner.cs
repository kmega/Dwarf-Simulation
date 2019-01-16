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
         
            if (tempcoordinates[0] <= 10 && tempcoordinates[1] <= 10)
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
