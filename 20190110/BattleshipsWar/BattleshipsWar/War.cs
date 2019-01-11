using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    public class War
    {

        public void Shoot(int[] tempcoordinates, CellProperty[,] warmap)
        {
            Scanner sc = new Scanner();
            string result;
            bool isCoorinatesCorrect = false;
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

                         CellISsEmpty();
                        break;


                    case CellProperty.Occupied:

                        CellIsOccupied(warmap, tempcoordinates);
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
        }




        private void CellIsBlocked()
        {
            string result = "Złe koordynaty, spróbuj jeszcze raz";
            Console.WriteLine(result);
        }

        private void CellIsOccupied(CellProperty[,] warmap, int[] tempcoordinates)
        {
            string result;
            warmap[tempcoordinates[0], tempcoordinates[1]] = CellProperty.Hit;
            result = "Trafiłeś";
            Console.WriteLine(result); ;
        }

        private void CellISsEmpty()
        {
            string result = "Nie trafiłeś";
                Console.WriteLine(result);
        }

        private void CellIsHit()
        {
            string result = "Złe koordynaty, spróbuj jeszcze raz";
            Console.WriteLine(result);

        }
    }
}
