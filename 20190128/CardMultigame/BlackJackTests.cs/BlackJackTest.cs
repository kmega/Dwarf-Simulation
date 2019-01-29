using Core.Containers.GameRules;
using Core.Containers.GameRules.CreationCommands;
using Core.Entities.Decks;
using Core.Entities.Games.Oczko;
using Core.Entities.GameStates;
using Core.Usecases.GameActions;
using Core.Usecases.GameConditions;
using Core.Usecases.InfluenceState;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
      
       
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void BlackJackGameCanBeStart()
        {
            //given
            GameManagerInternalsBuilder builder = new GameManagerInternalsBuilder();

            //when
            new SelectGame().ChangeGameRuleset(builder, "BlackJack");
            PlayedGameRules rules = builder.ConstructRuleset();


            //then

            Assert.IsTrue(rules.GameActions()[0] is BlackJackDraw);
            Assert.IsTrue(rules.GameActions()[1] is BlackJackPass);
            Assert.IsTrue(rules.GameStopConditions()[0] is BlackJackDidScore21OrHigher);
            Assert.IsTrue(rules.GameStopConditions()[1] is BlackJackDidPass);
            Assert.IsTrue(rules.VictoryConditions()[0] is BlackJackDidScore21);
            Assert.IsTrue(rules.VictoryConditions()[1] is BlackJackDidNextMoveGiveMoreThan21);
        }


            [Test]
            public void BlackJackGameScore21()
        {
            //given
            GameManagerInternalsBuilder builder = new GameManagerInternalsBuilder();
            new SelectGame().ChangeGameRuleset(builder, "BlackJack");
            PlayedGameRules rules = builder.ConstructRuleset();
            new SetDeck().ChangeGameRuleset(builder, "QH,QH,QH,JH,9H");
            GameState gameState = builder.ConstructGameState();
            IGameAction action = new BlackJackDraw();
            IGameCondition condition = new BlackJackDidScore21();

            //when
            for (int i = 0; i < 4; i++) {
                action.ChangeGameState(gameState, rules, null);
                condition.CheckAndUpdate(gameState);
                Assert.IsTrue(QueryGameState.IsGameWon(gameState) == false);
            }

            action.ChangeGameState(gameState, rules, null);
            condition.CheckAndUpdate(gameState);
            Assert.IsTrue(QueryGameState.IsGameWon(gameState) == true);



        }

        [Test]
        public void BlackJackLoseIfMoreThan21()
        {
            //given
            GameManagerInternalsBuilder builder = new GameManagerInternalsBuilder();
            new SelectGame().ChangeGameRuleset(builder, "BlackJack");
            PlayedGameRules rules = builder.ConstructRuleset();
            new SetDeck().ChangeGameRuleset(builder, "QH,QH,QH,JH,9H,9H");
            GameState gameState = builder.ConstructGameState();
            IGameAction action = new BlackJackDraw();
            IGameCondition condition = new BlackJackDidScore21OrHigher();

            //when
            for (int i = 0; i < 5; i++)
            {
                action.ChangeGameState(gameState, rules, null);
                condition.CheckAndUpdate(gameState);
                Assert.IsTrue(QueryGameState.IsGameLost(gameState) == false);
            }

            action.ChangeGameState(gameState, rules, null);
            condition.CheckAndUpdate(gameState);
            Assert.IsTrue(QueryGameState.IsGameLost(gameState) == true);



        }







    }
    }
