using System;

namespace BetterBattleships
{
    public class PlayerFactory
    {
        public IPlayer CreateOnePlayer()
        {
            return ProducePlayer();
        }

        public IPlayer ProducePlayer(string name="cat")
        {
            return new Player(name, new Board().Create());
        }

    }
}