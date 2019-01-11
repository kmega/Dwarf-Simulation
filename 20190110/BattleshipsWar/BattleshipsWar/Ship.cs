using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    public class Ship
    {
        public List<int> Coords { get; set; }

        public Ship(KindOfShip kindOfShip, int startCoords, Directions direction)
        {
            switch (kindOfShip)
            {
                case KindOfShip.Two:
                    {
                        BuildShip(direction);
                        break;
                    }
                    
                case KindOfShip.Three:
                    {
                        BuildShip(direction);
                        break;
                    }
                case KindOfShip.Four:
                    {
                        BuildShip(direction);
                        break;
                    }
                case KindOfShip.Six:
                    {
                        BuildShip(direction);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
