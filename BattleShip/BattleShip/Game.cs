using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Game
    {

        public void HitShip(Player player1, Player player2, string hit)
        {
            hit = hit.ToLower();
            int lenghtBoard = hit[0] % 97;
            int heightBoard = hit[1] - 48;

            player1.Opponent_Board.Fields[lenghtBoard,heightBoard] = Field.F;
        }
    }
}
