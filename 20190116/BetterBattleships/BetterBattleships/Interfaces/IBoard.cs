namespace BetterBattleships
{
    public interface IBoard 
    {
        CellStatus SetCellEmptyStatus();
        CellStatus SetCellDeckStatus();
    }
}
