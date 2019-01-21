using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    public class Ship
    {
        public List<int[]> Coords { get; private set; } = new List<int[]>();

        public Ship(KindOfShip kindOfShip, int[] startCoords, Direction direction)
        {
            switch (kindOfShip)
            {
                case KindOfShip.One:
                    {
                        BuildShip(direction, startCoords, 1);
                        break;
                    }
                case KindOfShip.Two:
                    {
                        BuildShip(direction, startCoords, 2);
                        break;
                    }
                case KindOfShip.Three:
                    {
                        BuildShip(direction, startCoords, 3);
                        break;
                    }
                case KindOfShip.Four:
                    {
                        BuildShip(direction, startCoords, 4);
                        break;
                    }
                case KindOfShip.Five:
                    {
                        BuildShip(direction, startCoords, 5);
                        break;
                    }
                case KindOfShip.Six:
                    {
                        BuildShip(direction, startCoords, 6);
                        break;
                    }
                default:
                    break;
            }
        }

        private void BuildShip(Direction direction, int[] startCoords, int kind)
        {
            Coords.Add(new[]{startCoords[0], startCoords[1]});

            switch(direction)
            {
                case Direction.Up:
                    {
                        for (int i = 1; i < kind; i++)
                        {
                            Coords.Add(new[] { startCoords[0] - i, startCoords[1] });
                        }
                        break;
                    }
                case Direction.Down:
                    {
                        for (int i = 1; i < kind; i++)
                        {
                            Coords.Add(new[] { startCoords[0] + i, startCoords[1] });
                        }
                        break;
                    }
                case Direction.Left:
                    {
                        for (int i = 1; i < kind; i++)
                        {
                            Coords.Add(new[] { startCoords[0], startCoords[1]-i});
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        for (int i = 1; i < kind; i++)
                        {
                            Coords.Add(new[] { startCoords[0], startCoords[1]+i});
                        }
                        break;
                    }
            }
        }
    }
}
