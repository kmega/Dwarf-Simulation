using NUnit.Framework;
using barcos;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Hypervisor_CreateHypervisor_ReturnNamesOfBothPlayers()
        {
            //given
            Player player_1 = new Player();
            Player player_2 = new Player();
            string playerName_1 = "Pioter";
            string playerName_2 = "Janusz";
            List<Player> players = new List<Player>() { player_1, player_2 };

            //act
            Hypervisor hypervisor = new Hypervisor(players);


            //expected
            Assert.AreEqual(playerName_1, player_1.Name);
            Assert.AreEqual(playerName_2, player_2.Name);

        }
    }
}