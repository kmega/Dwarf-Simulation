using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public class Player : IPlayer
    {
        public Player()
        {
            Ships = new List<IShip>();
        }
        public List<IShip> Ships { get; set; }
    }
}
