using System;

namespace barcos
{
    class Program
    {
        static void Main(string[] args)
        {
            //phase 1

            Hypervisor hypervisor = new Hypervisor();
            Player playerOne = new Player(hypervisor);
            Player playerTwo = new Player(hypervisor);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("What is Your name,");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Player_1?");
            Console.WriteLine("");
            string player_1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Hello in BattleShip game,");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" {0}!", player_1);
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("What is Your name,");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Player_2?");
            Console.WriteLine("");
            string player_2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.Write("Hello in BattleShip game,");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" {0}!", player_2);
            Console.WriteLine("");

            hypervisor.InitiatePlayers(player_1, player_2);

            hypervisor.UpDateBoard(playerOne);

            Console.ReadKey();
        }
    }
}
