using BattleshipsWar.Warcraft;
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

                        new Scout().Patrol(new WrongCoordinates());
                        isShootHit = true;
                        break;


                    case CellProperty.Empty:

                        new Scout().Patrol(new EmptyCell(warmap,tempcoordinates));
                        break;


                    case CellProperty.Occupied:

                        new Scout().Patrol(new OccupiedCell(warmap, tempcoordinates,listofships));
                        isShootHit = true;
                        break;


                    case CellProperty.Blocked:

                        new Scout().Patrol(new WrongCoordinates());
                        isShootHit = true;
                        break;

                    case CellProperty.Destroyed:

                        new Scout().Patrol(new WrongCoordinates());
                        isShootHit = true;
                        break;



                    default:
                        new Scout().Patrol(new WrongCoordinates());
                        break;

                }

            }
            else
            {
                new Scout().Patrol(new WrongCoordinates());
            }

            shootresult[1] = isShootHit;
            shootresult[0] = isCoorinatesCorrect;
            return shootresult;
            
        }


    }
}
