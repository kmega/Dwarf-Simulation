using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Arena
    {
        

        public void Fight(Player shooter, Player victim,string playerCoordinates)
        {
            PutShipOnTheBoard ships = new PutShipOnTheBoard();


            int[] coordinates = ships.CoordinatesParser(playerCoordinates);
            coordinates[0]--;
            coordinates[1]--;


            if (victim.Player_Board.Fields[coordinates[1], coordinates[0]] == Field.S)
            {
                victim.Player_Board.Fields[coordinates[1], coordinates[0]] = Field.H;
                shooter.Opponent_Board.Fields[coordinates[1], coordinates[0]] = Field.H;
            }
            else if (victim.Player_Board.Fields[coordinates[1], coordinates[0]] == Field.O)
            {
                victim.Player_Board.Fields[coordinates[1], coordinates[0]] = Field.O;
                shooter.Opponent_Board.Fields[coordinates[1], coordinates[0]] = Field.F;
            }



        }

    }
}
