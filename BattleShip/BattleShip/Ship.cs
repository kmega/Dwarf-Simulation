using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Ship
    {
        public int Id { get; set; }
        public int Lenght { get; set; }

        public Ship(int id, int lenght)
        {
            this.Id = id;
            this.Lenght = lenght;
        }

    }
}
