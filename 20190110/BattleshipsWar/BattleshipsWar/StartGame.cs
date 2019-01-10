using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    class StartGame
    {
        internal void CreateShip()
        {
            List<int> ships = new List<int>
            {
                2, 2, 3, 3, 4, 4, 6
            };



            object[,] Board = new object[10, 10];

            for (int i = 0; i < Board.GetLength(i); i++)
            {
                for (int j = 0; j < Board.GetLength(j); j++)
                {
                    Board[i, j] = CellProperty.Empty;
                }
            }
            

        }
    }
}
