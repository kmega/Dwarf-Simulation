using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar.Warcraft
{
    class OccupiedCell : WarmapStatus
    {
        private CellProperty[,] Warmap;
        private int[] Coordinates;
        private List<Ship> Listofships;

        public OccupiedCell(CellProperty[,] warmap, int[] tempcoordinates, List<Ship> listofships)
        {
            Warmap = warmap;
            Coordinates = tempcoordinates;
            Listofships = listofships;
        }

        public void CellStatusChanger()
        {
            string result;
            Warmap[Coordinates[0], Coordinates[1]] = CellProperty.Hit;
            result = "Trafiłeś";
            Console.WriteLine(result); ;
            CheckIsShipDestroyed(Warmap, Coordinates, Listofships);
        }
        

        private void CheckIsShipDestroyed(CellProperty[,] warmap, int[] tempcoordinates, List<Ship> listofships)
        {
            foreach (var item in listofships)
            {
                if (item.Coords.Any(p => p.SequenceEqual(tempcoordinates)))
                {

                    List<CellProperty> shipStatus = new List<CellProperty>();
                    Scanner sc = new Scanner();
                    foreach (var item2 in item.Coords)
                    {
                        shipStatus.Add(sc.CheckCellStatus(warmap, item2));
                    }

                    if (!shipStatus.Contains(CellProperty.Occupied))
                    {
                        DestroyShip(listofships, shipStatus, warmap, listofships.IndexOf(item));


                    }

                }

            }
        }

        private void DestroyShip(List<Ship> listofship,
            List<CellProperty> shipStatus, CellProperty[,] warmap, int index)
        {


            Console.WriteLine("Zniszczyłeś statek {0} elementowy", shipStatus.Count);
            foreach (var item in listofship[index].Coords)
            {
                for (int row = -1; row <= 1; row++)
                {
                    for (int column = -1; column <= 1; column++)
                    {
                        try
                        {
                                warmap[item[0] + row, item[1] + column] = CellProperty.Blocked;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

            }

            foreach (var item in listofship[index].Coords)
            {

                warmap[item[0], item[1]] = CellProperty.Destroyed;

            }







        }
    }
}
