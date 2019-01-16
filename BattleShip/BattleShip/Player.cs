using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Player
    {
        public Board Player_Board { get; set; }
        public int Id { get; set; }
        public Board Opponent_Board { get; set; }
        public List<Ship> ships { get; set; }

        public Player(int Id)
        {
            this.Id = Id;

            ships = new List<Ship>()
            {
                new Ship(1,1),
                new Ship(2,2),
                new Ship(3,3),


            };

            Player_Board = new Board();
            Opponent_Board = new Board();
        }

        public void ShowShips(Player player)
        {
            foreach (var ship in player.ships)
            {

                Console.WriteLine("Ship id " + ship.Id.ToString() + " Lenght Ship " + ship.Lenght);
            }
        }
        public void ShowBoard(Board board)
        {
                      
            Console.Write("    A B C D E F G H I J ");

            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0, k = 1; i < board.Fields.GetLength(0); i++)
            {
              
                Console.Write(String.Format("{0,-4}", k++)); ;

                for (int j = 0; j < board.Fields.GetLength(1); j++)
                {
                    if (board.Fields[i,j] == Field.S)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (board.Fields[i, j] == Field.H)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (board.Fields[i, j] == Field.F)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write(board.Fields[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }


    }
}
