using System.Collections.Generic;

namespace BattleshipGame
{
    public class Player
    {
        public List<string> CheckedFields { get; set; }
        public List<string> DestroyedShips { get; set; }
        public bool IsActive { get; set; }
        public List<string> Ships { get; set; }
        public GameBoard GameBoard { get; set; }
    }
}