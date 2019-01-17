using System;

namespace BetterBattleships
{
    public class PlayerFactory
    {
        public IPlayer ProducePlayer(string name="defaultName")
        {
            return new Player(name, new BoardFactory().Create());
        }
    }
}