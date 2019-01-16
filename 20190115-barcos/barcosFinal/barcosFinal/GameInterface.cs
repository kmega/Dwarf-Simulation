using System;
using barcosFinal.Interfaces;
using barcosFinal.Enums;
using System.Collections.Generic;

namespace barcosFinal
{
    public class GameInterface : IGameInterface
    {
        public GameInterface()
        {
        }

        IPlayer CurrentPlayer = null;
        List<IPlayer> Players = new List<IPlayer>() { };

        public void MessageToPlayer(IPlayer player, string message)
        {
            Console.WriteLine("message");
        }

        public void ReadDataFromPlayer(IPlayer player)
        {

        }

    }
}
