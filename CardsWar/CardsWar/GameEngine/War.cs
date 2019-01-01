using System;
using System.Collections.Generic;

namespace CardsWar.GameEngine
{    
    public class War
    {
        enum FightResults
        {
            FirstPlayerWin = 1,
            SecondPlayerWin,
            Draw
        }

        public static Player Fight(Player firstPlayer, Player secondPlayer)
        {
            Deck.Shuffle(firstPlayer.Hand);
            Deck.Shuffle(secondPlayer.Hand);
            int timeToShuffle = 28;

            while (firstPlayer.Hand.Count != 0 || secondPlayer.Hand.Count != 0)
            {
                timeToShuffle--;

                //push card from first player hand to his fightPool  handCard -> fight Pool
                Player.TransferCard(firstPlayer.Hand, firstPlayer.FightPool);
                //Write step: First player.name card: cardName
                Game.WriteStep(firstPlayer.Name, GiveLastElement(firstPlayer.FightPool));

                //push card from second player hand to his fightPool
                Player.TransferCard(secondPlayer.Hand, secondPlayer.FightPool);
                //Write step: Second player.name card: cardName
                Game.WriteStep(secondPlayer.Name, GiveLastElement(secondPlayer.FightPool));

                //Compare last card from fightPools and return (win first player or win second player or draw)
                FightResults fightResult = CompareCards(GiveLastElement(firstPlayer.FightPool), GiveLastElement(secondPlayer.FightPool));
                //switch by return result fight -> 1.first player win, 2.second player win, 3.draw
                //
                switch (fightResult)
                {
                    case FightResults.FirstPlayerWin:
                        {
                            //Write step: First player.name won the battle and gained: poolFight
                            Game.WriteStep(firstPlayer.Name, firstPlayer.FightPool, secondPlayer.FightPool);

                            //Add cards from fight pools to first player hand in bottom
                            Player.TransferFightPoolsToHand(firstPlayer.Hand, firstPlayer.FightPool, secondPlayer.FightPool);

                            //Write step: First player.name hand count: Second player.name hand count: 
                            Game.WriteStep(firstPlayer, secondPlayer);
                            break;
                        }
                    
                    case FightResults.SecondPlayerWin:
                        {
                            //Write step: Second player.name won the battle and gained: poolFight
                            Game.WriteStep(secondPlayer.Name, firstPlayer.FightPool, secondPlayer.FightPool);

                            //Add cards from fight pools to second player hand in bottom
                            Player.TransferFightPoolsToHand(secondPlayer.Hand, firstPlayer.FightPool, secondPlayer.FightPool);

                            //Write step: First player.name hand count: Second player.name hand count: 
                            Game.WriteStep(firstPlayer, secondPlayer);
                            break;
                        }
                    //Add cards from hand to fight pool like a hidden cards and do battle again
                    case FightResults.Draw:
                        {
                            //Write step: Draw!! 
                            Game.WriteStep();

                            //push card from first player hand to his fightPool  handCard -> fight Pool
                            Player.TransferCard(firstPlayer.Hand, firstPlayer.FightPool);
                            //Write step: First player.name push hidden card
                            Game.WriteStep(firstPlayer.Name);

                            //push card from second player hand to his fightPool
                            Player.TransferCard(secondPlayer.Hand, secondPlayer.FightPool);
                            //Write step: Second player.name push hidden card
                            Game.WriteStep(secondPlayer.Name);

                            // continue;
                            break;
                        }
                }

                if (timeToShuffle < 0 && (firstPlayer.Hand.Count != 0 && secondPlayer.Hand.Count != 0))
                {
                    Game.WriteShuffle();
                    Deck.Shuffle(firstPlayer.Hand);
                    Deck.Shuffle(secondPlayer.Hand);

                    if (firstPlayer.Hand.Count > secondPlayer.Hand.Count) timeToShuffle = secondPlayer.Hand.Count;
                    else if (secondPlayer.Hand.Count > firstPlayer.Hand.Count) timeToShuffle = firstPlayer.Hand.Count;
                    else timeToShuffle = 28;

                }
                //Console.ReadKey();
                if (firstPlayer.Hand.Count == 0) return secondPlayer;  //second player win if first player hand is empty
                else if (secondPlayer.Hand.Count == 0) return firstPlayer; // first player win if second player hand is empty
                else
                {
                    continue;
                }
            }

            if (firstPlayer.Hand.Count == 0) return secondPlayer;  //second player win if first player hand is empty
            else if (secondPlayer.Hand.Count == 0) return firstPlayer; // first player win if second player hand is empty
            else
            {
                throw new Exception("Battle end not complete!");
            }

        }

        private static Deck.AllCards GiveLastElement(List<Deck.AllCards> fightPool)
        {
            return fightPool[fightPool.Count - 1];
        }

        private static FightResults CompareCards(Deck.AllCards card1, Deck.AllCards card2)
        {
            if (card1 > card2) return FightResults.FirstPlayerWin;
            else if (card2 > card1) return FightResults.SecondPlayerWin;
            else return FightResults.Draw;
        }
    }
}