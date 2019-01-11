using System.Collections.Generic;

namespace BattleShips
{
    public class Player
    {
        public Player()
        {
            FieldUsedByPlayer = new List<string>();
            FieldWithDestroyedShips = new List<string>();
            FieldWithShips = new List<string>();
        }
        public string PlayerName { get; set; }
        public List<string> FieldUsedByPlayer { get; set; }
        public List<string> FieldWithDestroyedShips { get; set; }
        public List<string> FieldWithShips { get; set; }
        public bool IsActive { get; set; }
    }
}