using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    public class Ship
    {
        public List<int[]> Coords { get; private set; }

        public Ship(KindOfShip kindOfShip, int[] startCoords, Direction direction)
        {
            switch (kindOfShip)
            {
                case KindOfShip.Two:
                    {
                        BuildShipKindTwo(direction, startCoords);
                        break;
                    }
                    
                case KindOfShip.Three:
                    {
                        BuildShipKindThree(direction, startCoords);
                        break;
                    }
                case KindOfShip.Four:
                    {
                        BuildShipKindFour(direction, startCoords);
                        break;
                    }
                case KindOfShip.Six:
                    {
                        BuildShipKindSix(direction, startCoords);
                        break;
                    }
                default:
                    break;
            }
        }

        private void BuildShipKindSix(Direction direction, int[] startCoords)
        {
            Coords.Add(new[]{startCoords[0], startCoords[1]});

            switch(direction)
            {
                case Direction.Up:
                    {
                        for (int i = 1; i < 6; i++)
                        {
                            Coords.Add(new[] { startCoords[0] - i, startCoords[1] });
                        }
                        break;
                    }
            }
        }

        private void BuildShipKindFour(Direction direction, int[] startCoords)
        {
            throw new NotImplementedException();
        }

        private void BuildShipKindThree(Direction direction, int[] startCoords)
        {
            throw new NotImplementedException();
        }

        private void BuildShipKindTwo(Direction direction, int[] startCoords)
        {
            throw new NotImplementedException();
        }
    }
}
