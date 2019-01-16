using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    public class War
    {

        public bool[] Shoot(int[] tempcoordinates, CellProperty[,] warmap, List<Ship> listofships)
        {
            Scanner sc = new Scanner();
            string result;
            bool[] shootresult = new bool[2];
            bool isCoorinatesCorrect = false;
            bool isShootHit = false;
            CellProperty option;


            if (sc.CheckCoordinatesCorrectness(tempcoordinates, warmap))
            {

                option = sc.CheckCellStatus(warmap, tempcoordinates);
                isCoorinatesCorrect = true;

                switch (option)
                {
                    case CellProperty.Hit:

                        CellIsHit();
                        break;


                    case CellProperty.Empty:

                         CellISsEmpty(warmap, tempcoordinates);
                        break;


                    case CellProperty.Occupied:

                        CellIsOccupied(warmap, tempcoordinates,listofships);
                        isShootHit = true;
                        
                        break;


                    case CellProperty.Blocked:

                        CellIsBlocked();
                        break;

                    default:
                       Console.WriteLine( "Złe koordynaty, spróbuj jeszcze raz") ;
                        break;

                }

            }
            else
            {
                result = "Złe koordynaty, spróbuj jeszcze raz";
                Console.WriteLine(result); 
            }

            shootresult[1] = isShootHit;
            shootresult[0] = isCoorinatesCorrect;
            return shootresult;
            
        }




        private void CellIsBlocked()
        {
            string result = "Złe koordynaty, spróbuj jeszcze raz";
            Console.WriteLine(result);
        }

        private void CellIsOccupied(CellProperty[,] warmap, int[] tempcoordinates, List<Ship> listofships)
        {
            string result;
            warmap[tempcoordinates[0], tempcoordinates[1]] = CellProperty.Hit;
            result = "Trafiłeś";
            Console.WriteLine(result); ;
            CheckIsShipDestroyed(warmap, tempcoordinates, listofships);
            
        }

        private void CellISsEmpty(CellProperty[,] warmap, int[] tempcoordinates)
        {
            string result = "Nie trafiłeś";
            warmap[tempcoordinates[0], tempcoordinates[1]] = CellProperty.Blocked;
            Console.WriteLine(result);
        }

        private void CellIsHit()
        {
            string result = "Złe koordynaty, spróbuj jeszcze raz";
            Console.WriteLine(result);

        }

        private void CheckIsShipDestroyed (CellProperty[,] warmap, int[] tempcoordinates, List<Ship> listofships)
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
                        Console.WriteLine("Zniszczyłeś statek {0} elementowy", shipStatus.Count);
                        foreach (var item2 in item.Coords)
                        {
                            for (int row = -1; row <= 1; row++)
                            {
                                for (int column = -1; column <= 1; column++)
                                {
                                    try
                                    {
                                        warmap[item2[0] + row, item2[1] + column] = CellProperty.Blocked;
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }

                }

            }
        }
    }
}
