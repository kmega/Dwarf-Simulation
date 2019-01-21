using BattleshipsWar.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    public class PlayerTurn
    {

        public bool MakeSingleShoot(List<Ship> listofenemyships, CellProperty[,] enemywarmap)
        {
            bool[] result = { false, false };
         
            do
            {

                Console.Clear();
                ActionGameUI.DrawBoardWar(enemywarmap);
                Console.WriteLine();
                Console.WriteLine("Podaj koordynaty");
                string input = Console.ReadLine();

                int[] coordinates = new InputParser().ChangeCordsToIndexes(input);
                War war = new War();
               result= war.Shoot(coordinates, enemywarmap, listofenemyships);
                



            } while (result[0] == false);

            ActionGameUI.DrawBoardWar(enemywarmap);

            return result[1];

        }


        public bool MakeTurn (List<Ship> listofenemyships, CellProperty[,] enemywarmap)
        {
            bool result = true;
            bool Winner = false;
            do
            {

                result = MakeSingleShoot(listofenemyships, enemywarmap);
                int counter = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (enemywarmap[i,j] == CellProperty.Occupied)
                        {
                            counter++;
                                }
                    }
                }
                if (counter == 0)
                {
                    Winner = true;
                }

            } while (result == true);

            return Winner;
        }





    }



}
