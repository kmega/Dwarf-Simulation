using System;

namespace BetterBattleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var gm = new GameManager();
            IPlayer player1 = new PlayerFactory().ProducePlayer(name: "P1");
            IPlayer player2 = new PlayerFactory().ProducePlayer(name: "P2");
            gm.ManageBoard(player1);
            gm.ManageBoard(player2);
            gm.ManageGame(player1, player2);

            Console.ReadKey();
        }
    }
}
