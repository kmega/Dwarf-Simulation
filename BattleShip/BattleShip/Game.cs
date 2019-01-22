using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Game
    {

        public void TryHitShip(Player player1, Player player2, 
            string player1TryHitShip, string player2TryHitShip)
        {
            //Player 1 try hit player 2 ships

            player1TryHitShip = player1TryHitShip.ToLower();
            int lenghtBoard = player1TryHitShip[0] % 97;
            int heightBoard = (player1TryHitShip[1] - 48) - 1;

            if (player2.Player_Board.Fields[lenghtBoard,heightBoard] == Field.O)
            {
                player1.Opponent_Board.Fields[lenghtBoard, heightBoard] = Field.F;
            }
            else if (player2.Player_Board.Fields[lenghtBoard, heightBoard] == Field.S)
            {
                player1.Opponent_Board.Fields[lenghtBoard, heightBoard] = Field.H;
            }

            ////Player 2 try hit player 1 ships
            player2TryHitShip = player2TryHitShip.ToLower();
            lenghtBoard = player2TryHitShip[0] % 97;
            heightBoard = (player2TryHitShip[1] - 48) - 1;
            player2.Player_Board.Fields[0, 0] = Field.S;

            if (player1.Player_Board.Fields[lenghtBoard, heightBoard] == Field.O)
            {
                player2.Opponent_Board.Fields[lenghtBoard, heightBoard] = Field.F;
            }
            else if (player1.Player_Board.Fields[lenghtBoard, heightBoard] == Field.S)
            {
                player2.Opponent_Board.Fields[lenghtBoard, heightBoard] = Field.H;
            }
        }

        public void DoYouShootInAnotherField(string coordinateTheShot, Player player1,
            Player player2)
        {
            coordinateTheShot = coordinateTheShot.ToLower();
            int lenghtBoard = coordinateTheShot[0] % 97;
            int heightBoard = (coordinateTheShot[1] - 48) - 1;
            if (player1.Opponent_Board.Fields[lenghtBoard, heightBoard] != Field.O)
            {

            }
        }

    }
}
