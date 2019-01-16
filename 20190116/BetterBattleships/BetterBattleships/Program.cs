using System;

namespace BetterBattleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var gm = new GameManager();
            IPlayer player1 = new PlayerFactory().ProducePlayer(name: "as");
            gm.ManageBoard(player1);

            Console.ReadKey();
        }
    }
}
