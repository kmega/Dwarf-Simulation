using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Player
    {
       public Board Player_Board { get; set; }
       public int Id { get; set; }
       public Board Opponent_Board { get; set; }
       public List<Ship> ships { get; set; }

        public Player(int Id)
        {
            this.Id = Id;

            ships = new List<Ship>()
            {
                new Ship(1,1),
                new Ship(2,2),
                new Ship(3,3),

            };

            Player_Board = new Board();
            Opponent_Board = new Board();
        }

    }
}
