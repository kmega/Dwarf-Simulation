namespace BetterBattleships
{
    public class ConsoleDisplayer
    {
        public void DisplayBoard(IPlayer player)
        {
            for (int i = 0; i < player.GetBoard().GetLength(0); i++)
            {
                for (int j = 0; j < player.GetBoard().GetLength(1); j++)
                {
                    var uglyLongVar = new BoardPlacer().GetCurrentCellStatus(new int[] { i, j }, player);
                    System.Console.Write("[{0}] ", (char)uglyLongVar);
                }
                System.Console.WriteLine();
            }
        }

        public void DisplayWhosBoard(IPlayer player)
        {
            System.Console.WriteLine("Board of player: {0}", player.Name);
            System.Console.WriteLine();
        }
    }
}







