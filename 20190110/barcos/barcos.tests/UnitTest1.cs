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
            Hypervisor hypervisor = new Hypervisor();
            Player player_1 = new Player(hypervisor: hypervisor);
            Player player_2 = new Player(hypervisor: hypervisor);
            string playerName_1 = "Pioter";
            string playerName_2 = "Janusz";
            List<Player> players = new List<Player>() { player_1, player_2 };

            //act
            hypervisor.InitiatePlayers();


            //expected
            Assert.AreEqual(playerName_1, player_1.Name);
            Assert.AreEqual(playerName_2, player_2.Name);

        }
    }
}