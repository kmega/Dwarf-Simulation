namespace BetterBattleships
{
    public class ConsoleDisplayer
    {
        public void DisplayBoard(CellStatus[,] Board)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    var uglyLongVar = new BoardPlacer().GetCurrentCellStatus(new int[] { i, j }, Board);
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







