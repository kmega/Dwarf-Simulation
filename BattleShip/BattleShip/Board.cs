using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
   public class Board
    {
        public Field[,] Fields;

        public Board()
        {
            Fields = new Field[10, 10];

            for (int i = 0; i < Fields.GetLength(0); i++)
            {

                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    Fields[i, j] = Field.O;
                }
            } 
        }
    }
}
