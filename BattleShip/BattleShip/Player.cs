using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Player
    {
        Board Player_Board;
        int ID;
        Board Opponent_Board;
        List<Ship> ships;

        public Player(int Id)
        {
            ID = Id;
            ships = new List<Ship>()
            {
                new Ship(){ }
            }
        }
    }
}
