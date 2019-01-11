using NUnit.Framework;
using barcos;
using System.Collections.Generic;
using barcos.Enums;

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
            hypervisor.InitiatePlayers(playerName_1, playerName_2);


            //expected
            Assert.AreEqual(playerName_1, player_1.Name);
            Assert.AreEqual(playerName_2, player_2.Name);

        }

        [Test]
        public void BoardHas100EmptyFields1()
        {
            //Given
            Board testedBoard = new Board();
            int boardLength = testedBoard.Fields.Length;
            int boardFieldCounter = 0;

<<<<<<< HEAD
            Assert.IsTrue(testedBoard.Fields[56] == FieldsStatus.empty);

            while (boardFieldCounter < boardLength)
            {
                Assert.AreEqual(
                    testedBoard.Fields[boardFieldCounter],
                    FieldsStatus.empty);
                boardFieldCounter++;
=======
            while (boardFieldCounter < boardLength)
            {
                Assert.AreEqual(
                    testedBoard.Fields[boardFieldCounter], 
                    FieldsStatus.empty,
                    "Board at index " + boardFieldCounter + 
                    " has content = " + testedBoard.Fields[boardFieldCounter]);
                boardFieldCounter++;
>>>>>>> 20190110/barcos
            }
        }
    }
}
