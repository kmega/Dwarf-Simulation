using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    public class War
    {

        public bool CheckCoordinatesCorrectness(int[] tempcoordinates, CellProperty[,] warmap)
        {
           
            bool answer = false;
         
            if (tempcoordinates[0] <= warmap.GetLength(0))
            {

                if (tempcoordinates[1] <= warmap.GetLength(1))
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
