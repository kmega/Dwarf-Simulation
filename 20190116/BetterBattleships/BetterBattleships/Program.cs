using System;

namespace BetterBattleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var gm = new GameManager();
            IPlayer player1 = new PlayerFactory().ProducePlayer(name: "Franek");
            IPlayer player2 = new PlayerFactory().ProducePlayer(name: "Catfish");
            gm.ManageBoard(player1);
            gm.ManageBoard(player2);

            Console.WriteLine("dsa");

            Console.ReadKey();
        }
    }
}
