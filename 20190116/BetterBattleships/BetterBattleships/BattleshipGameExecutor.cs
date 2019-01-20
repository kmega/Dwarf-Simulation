using System;

namespace BetterBattleships
{
    public class BattleshipGameExecutor
    {
        public IPlayer ProcessGameAndReturnWinner(IPlayer player1, IPlayer player2, bool shootBool = true)
        {
            var GameProcessExecutor = new GameProcessExecutor();
            var parser = new InputParser();
            CellStatus[,] TemporaryBoardWithMarkedShootsForPlayer1 = new BoardFactory().Create();
            CellStatus[,] TemporaryBoardWithMarkedShootsForPlayer2 = new BoardFactory().Create();

            new ConsoleDisplayer().DisplayBoard(new BoardFactory().Create());

            while (true)
            {
                var repeatShoot = false;
                do
                {
                    if(shootBool)
                    {
                        new ConsoleDisplayer().DisplayBoardLegend();
                        new ConsoleDisplayer().DisplayBoard(TemporaryBoardWithMarkedShootsForPlayer1);
                        repeatShoot = GameProcessExecutor.Shoot(player2.GetBoard(), parser.GetCoordinatesToShootShip(player2.Name, 
                                                                        player1.Name), TemporaryBoardWithMarkedShootsForPlayer1);
                    }
                    if (GameProcessExecutor.PlayerHasDeckCells(player2.GetBoard()) != true)
                    {
                        return player1;
                    }
                } while (repeatShoot);

                Console.WriteLine("Nie trafiles, kolejny gracz oddaje strzal");
                new ConsoleDisplayer().ClearConsoleAndAwaitForAnyKey();

                repeatShoot = false;

                do
                {
                    if (shootBool)
                    {
                        new ConsoleDisplayer().DisplayBoardLegend();
                        new ConsoleDisplayer().DisplayBoard(TemporaryBoardWithMarkedShootsForPlayer2);
                        repeatShoot = GameProcessExecutor.Shoot(player1.GetBoard(), parser.GetCoordinatesToShootShip(player1.Name, 
                                                                        player2.Name), TemporaryBoardWithMarkedShootsForPlayer2);
                    }
                    if (GameProcessExecutor.PlayerHasDeckCells(player1.GetBoard()) != true)
                    {
                        return player2;
                    }
                } while (repeatShoot);

                Console.WriteLine("Nie trafiles, kolejny gracz oddaje strzal");
                new ConsoleDisplayer().ClearConsoleAndAwaitForAnyKey();
            }
        }
    }
}