using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
    public class PlayerTurn
    {

        public void MakeTurn(List<Ship> listofenemyships, CellProperty[,] enemywarmap, string input)
        {
            bool breakloop = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Podaj koordynaty");
                input = Console.ReadLine();

                int[] coordinates = new InputParser().ChangeCordsToIndexes(input);
                War war = new War();
               breakloop= war.Shoot(coordinates, enemywarmap, listofenemyships);


            } while (breakloop == false);

        }
    }
}
