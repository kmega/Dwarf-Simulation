using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public class Player
    {
        public Player()
        {
            Ships = new List<IShip>();
        }
        public List<IShip> Ships { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
    }
}
