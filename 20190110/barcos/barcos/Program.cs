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

            Console.WriteLine("What is Your name, Player_1?");
            string player_1 = Console.ReadLine();
            Console.WriteLine("Hello in BattleShip game, {0}!", player_1);

            Console.WriteLine("What is Your name, Player_2?");
            string player_2 = Console.ReadLine();
            Console.WriteLine("Hello in BattleShip game, {0}!", player_2);

            hypervisor.InitiatePlayers(player_1, player_2);

            hypervisor.UpDateBoard(playerOne);

            Console.ReadKey();
        }
    }
}
