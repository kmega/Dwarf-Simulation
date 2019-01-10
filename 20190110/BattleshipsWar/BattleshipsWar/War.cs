using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    public class War
    {

        public bool CheckCoordinates (string input, int[,] warmap)
        {
            int[] tempcoordinates = new int[2];
            bool answer = false;
           InputParser ip = new InputParser();
           tempcoordinates = ip.ChangeCordsToArrayIndex(input);

            if (tempcoordinates[0] <= warmap.GetLength(0) && tempcoordinates[0] >= 0)
            {

                if (tempcoordinates[1] <= warmap.GetLength(1) && tempcoordinates[1] >= 0)
                {
                    answer = true;
                }
            }

            return answer;
        }

    }
}
