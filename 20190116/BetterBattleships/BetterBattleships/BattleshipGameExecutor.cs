using System;

namespace BetterBattleships
{
    public class BattleshipGameExecutor
    {
        public void StartGame(IPlayer player1, IPlayer player2)
        {
            var winner = ProcessGame(player1, player2);
            //throw new NotImplementedException();
        }

        private IPlayer ProcessGame(IPlayer player1, IPlayer player2)
        {
            var processExecutor  = new GameProcessExecutor();

            while(true)
            {
                processExecutor.Shoot(player2);
                if(processExecutor.PlayerHasDeckCells(player2.GetBoard()) != true)
                {
                    return player1;
                }

                processExecutor.Shoot(player1);
                if (processExecutor.PlayerHasDeckCells(player1.GetBoard()) != true)
                {
                    return player1;
                }
            }
        }
    }
}