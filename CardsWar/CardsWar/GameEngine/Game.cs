using CardsWar.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsWar.GameEngine
{
    class Game
    {
        private static string stepsGame = "";

        private Deck _cards = new Deck();
        private List<Deck.AllCards> _shuffledCards = new List<Deck.AllCards>();
        private Player _winner = new Player();

        public static void Run(bool permissionStart)
        {
            Player firstPlayer = new Player(Player.PlayersName.You);
            Player secondPlayer = new Player(Player.PlayersName.Opponent);

            if (permissionStart)
            {
                Game game = new Game();
                game.Play(firstPlayer, secondPlayer);
                File.WriteAllText("gameSteps.txt", stepsGame);
            }

            
        }

        private void Play(Player firstPlayer, Player secondPlayer)
        {

            //1. Shuffle cards -> List<cards> shuffled cards;           
            _shuffledCards = _cards.Shuffle();

            //2. Make two hands of cards from deck -> two lists of cards
            //2.1 (List<cards> firstHand, List<cards> secondHand) = GenerateHands(deck);
            (firstPlayer.Hand, secondPlayer.Hand) = _cards.GenerateTwoHands(_shuffledCards);

            //3. Doing wars
            _winner = War.Fight(firstPlayer, secondPlayer); // return winner (opponent or you)

            //Console.WriteLine(stepsGame);
            Console.WriteLine($"{_winner.Name} won the game!\n");
            

            //4. Show summary UI
            SummaryUI summaryUI = new SummaryUI();
            summaryUI.DisplayContent(stepsGame);
            //4.1 SummaryUI.Display(winner);
        }

        public static void WriteStep()
        {
            stepsGame +=  (Environment.NewLine + Environment.NewLine + "-------Draw!-------" + Environment.NewLine);
        }
        public static void WriteStep(Player.PlayersName name)
        {
            stepsGame += (Environment.NewLine  + $"{name} push hidden card" + Environment.NewLine);
        }
        public static void WriteStep(Player.PlayersName name, Deck.AllCards card)
        {
            stepsGame += ($"{name} push: {card}" + Environment.NewLine);
        }
        public static void WriteStep(Player.PlayersName name, List<Deck.AllCards> fightPool1, List<Deck.AllCards> fightPool2)
        {
            List<Deck.AllCards> wonPool = new List<Deck.AllCards>();
            wonPool.AddRange(fightPool1);
            wonPool.AddRange(fightPool2);

            stepsGame += ($"{name} won the battle and gained: ");
            stepsGame += (Environment.NewLine+"*****" + Environment.NewLine);
            foreach (var card in wonPool)
            {
                stepsGame += (card + Environment.NewLine);
            }
            stepsGame += (Environment.NewLine+"*****" + Environment.NewLine);
        }
        public static void WriteStep(Player firstPlayer, Player secondPlayer)
        {
            stepsGame += ($"{firstPlayer.Name} hand count: {firstPlayer.Hand.Count}"+ Environment.NewLine);
            stepsGame += ($"{secondPlayer.Name} hand count: {secondPlayer.Hand.Count}" +Environment.NewLine);
            stepsGame += ("---------------------------"+ Environment.NewLine);
        }
        internal static void WriteShuffle()
        {
            stepsGame += (Environment.NewLine+"###############Time to shuffle!!###############"+ Environment.NewLine);
        }
    }
}
