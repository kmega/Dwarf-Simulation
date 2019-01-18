using System;

namespace BetterBattleships
{
    public class BattleshipGameExecutor
    {
        public IPlayer ProcessGameAndReturnWinner(IPlayer player1, IPlayer player2, bool shootBool = true)
        {
            var GameProcessExecutor = new GameProcessExecutor();
            var parser = new InputParser();

            while (true)
            {
                var repeatShoot = false;
                do
                {
                    if(shootBool)
                    {
                        repeatShoot = GameProcessExecutor.Shoot(player2.GetBoard(), parser.GetCoordinatesToShootShip(player2.Name));
                    }
                    if (GameProcessExecutor.PlayerHasDeckCells(player2.GetBoard()) != true)
                    {
                        return player1;
                    }
                } while (repeatShoot);

                repeatShoot = false;

                do
                {
                    if (shootBool)
                    {
                        repeatShoot = GameProcessExecutor.Shoot(player1.GetBoard(), parser.GetCoordinatesToShootShip(player1.Name));
                    }
                    if (GameProcessExecutor.PlayerHasDeckCells(player1.GetBoard()) != true)
                    {
                        return player2;
                    }
                } while (repeatShoot);
            }
        }
    }
}