using System;

namespace BetterBattleships
{
    public class BattleshipGameExecutor
    {
        public void StartGame(IPlayer player1, IPlayer player2)
        {
            var winner = ProcessGame(player1, player2);
        }

        private IPlayer ProcessGame(IPlayer player1, IPlayer player2)
        {
            var GameProcessExecutor = new GameProcessExecutor();
            var parser = new InputParser();

            while(true)
            {
                var temp = false;
                do
                {
                    temp = GameProcessExecutor.Shoot(player2.GetBoard(), parser.GetCoordinatesToShootShip(player2.Name));
                    if (GameProcessExecutor.PlayerHasDeckCells(player2.GetBoard()) != true)
                    {
                        return player1;
                    }
                } while (temp);

                temp = false;

                do
                {
                    GameProcessExecutor.Shoot(player1.GetBoard(), parser.GetCoordinatesToShootShip(player1.Name));
                    if (GameProcessExecutor.PlayerHasDeckCells(player1.GetBoard()) != true)
                    {
                        return player1;
                    }
                } while (temp);
            }
        }
    }
}