using barcosFinal.Interfaces;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class PlayerTests
    {

        [Test]
        public void PlayerShotTest()
        {
            Mock<IPlayer> player = new Mock<IPlayer>();
            Mock<IPlayer> player2 = new Mock<IPlayer>();

            Mock<IBattleField> battleField = new Mock<IBattleField>();
          //  battleField.SetupSet(x => x.Board).Callback<char[,]>(x => x = new char[,]);

            Mock<IBattleField> battleField2 = new Mock<IBattleField>();


            player.SetupGet(x => x.BattleField).Returns(battleField.Object);
            player2.SetupGet(x => x.BattleField).Returns(battleField2.Object);

            
            
            
            
            player.Object.Shoot(1, 2, player2.Object.GetCurrentBattleField());
        }
    }
}