using System;
using System.Collections.Generic;

namespace CardsWar.GameEngine
{    
    public class War
    {
        public static Player Fight(Player firstPlayer, Player secondPlayer)
        {
            List<Deck.AllCards> TempPool = new List<Deck.AllCards>();
            Range range = new Range(28);

            while (firstPlayer.Hand.Count != 0 || secondPlayer.Hand.Count != 0)
            {
                //1. Shuffle hand one and hand two
                Deck.Shuffle(firstPlayer.Hand);
                Deck.Shuffle(secondPlayer.Hand);
                firstPlayer.TempPool.Clear();
                secondPlayer.TempPool.Clear();

                if (firstPlayer.Hand.Count > secondPlayer.Hand.Count) range.max = secondPlayer.Hand.Count;
                else if (secondPlayer.Hand.Count > firstPlayer.Hand.Count) range.max = firstPlayer.Hand.Count;
                else range.max = 28;

                //Doing battle until any hand contains any value
                for (int i = 0; i < range.max;)
                {
                    //2. Do battle, Compare firstPlayer cards and secondPlayer cards 
                    range.max -= BasicBattle(firstPlayer, secondPlayer, TempPool, i);
                    TempPool.Clear();
                }

                //3. Assign temps pools to first player hand and second player hand and clear temps
                firstPlayer.DumpTempToHand();
                secondPlayer.DumpTempToHand();               
            }

            if (firstPlayer.Hand.Count == 0) return secondPlayer;
            else if (secondPlayer.Hand.Count == 0) return firstPlayer;
            else
            {
                throw new Exception("Battle end not complete!");
            }
        }

        private static int BasicBattle(Player firstPlayer, Player secondPlayer, List<Deck.AllCards> TempPool, int indexCard)
        {
           
            //If the first player win, add win cards to his temple pool, and remove war cards from hands                       
            if (firstPlayer.Hand[indexCard] > secondPlayer.Hand[indexCard])
            {
                //Add point to first player
                firstPlayer.Points++;

                //Add war cards to temp pool
                TempPool.Add(firstPlayer.Hand[indexCard]);
                TempPool.Add(secondPlayer.Hand[indexCard]);

                //Add temp pool to temp pool first player
                firstPlayer.TempPool.AddRange(TempPool);

                //Remowe war cards from both hands
                firstPlayer.Hand.Remove(firstPlayer.Hand[indexCard]);
                secondPlayer.Hand.Remove(secondPlayer.Hand[indexCard]);

                indexCard = SafeModifyPools(firstPlayer, secondPlayer, indexCard);
                return TempPool.Count/2;
            }
            else if(secondPlayer.Hand[indexCard] > firstPlayer.Hand[indexCard])
            {
                //Add point to first player
                secondPlayer.Points++;

                //Add war cards to temp pool
                TempPool.Add(firstPlayer.Hand[indexCard]);
                TempPool.Add(secondPlayer.Hand[indexCard]);

                //Add temp pool to temp pool second player
                secondPlayer.TempPool.AddRange(TempPool);

                //Remove war cards from both hands
                firstPlayer.Hand.Remove(firstPlayer.Hand[indexCard]);
                secondPlayer.Hand.Remove(secondPlayer.Hand[indexCard]);

                //Safe modify pools
                indexCard = SafeModifyPools(firstPlayer, secondPlayer, indexCard);
                return TempPool.Count/2;
            }
            else if(firstPlayer.Hand[indexCard] == secondPlayer.Hand[indexCard] )
            {
                
                //Add war cards to temp pool
                TempPool.Add(firstPlayer.Hand[indexCard]);
                TempPool.Add(secondPlayer.Hand[indexCard]);


                //Remove war cards from both hands
                firstPlayer.Hand.Remove(firstPlayer.Hand[indexCard]);
                secondPlayer.Hand.Remove(secondPlayer.Hand[indexCard]);

                //Safe modify pools if hand is empty
                indexCard = SafeModifyPools(firstPlayer, secondPlayer, indexCard);
                

                //Add hidden cards to temp pool
                indexCard++;
                //Safe modify pools if it is last card
                indexCard = SafeModifyPools(firstPlayer, secondPlayer, indexCard);
                TempPool.Add(firstPlayer.Hand[indexCard]);
                TempPool.Add(secondPlayer.Hand[indexCard]);

                //Remove hidden cards from both hands
                firstPlayer.Hand.Remove(firstPlayer.Hand[indexCard]);
                secondPlayer.Hand.Remove(secondPlayer.Hand[indexCard]);

                

                //Do Battle again
                indexCard++;
                BasicBattle(firstPlayer, secondPlayer,TempPool, 0);

                return TempPool.Count/2;
            }
            else
            {
                throw new Exception();
            }
        }

        private static int SafeModifyPools(Player firstPlayer, Player secondPlayer, int indexCard)
        {
            //If both players have last card 
            if (firstPlayer.Hand.Count == 0 && secondPlayer.Hand.Count == 0)
            {
                firstPlayer.DumpTempToHand();
                secondPlayer.DumpTempToHand();

                Deck.Shuffle(firstPlayer.Hand);
                Deck.Shuffle(secondPlayer.Hand);

                firstPlayer.DumpTempToHand();
                secondPlayer.DumpTempToHand();

                return -1;
            }
            //If is last card first player
            else if (firstPlayer.Hand.Count == 0)
            {
                firstPlayer.DumpTempToHand();
                secondPlayer.Hand.AddRange(secondPlayer.TempPool);
                secondPlayer.TempPool.Clear();

                Deck.Shuffle(firstPlayer.Hand);
                Deck.Shuffle(secondPlayer.Hand);

                firstPlayer.DumpTempToHand();
                secondPlayer.DumpTempToHand();
                return -1;
            }
            //if is last card second player
            else if (firstPlayer.Hand.Count == 0)
            {
                secondPlayer.DumpTempToHand();
                firstPlayer.Hand.AddRange(firstPlayer.TempPool);
                firstPlayer.TempPool.Clear();

                Deck.Shuffle(firstPlayer.Hand);
                Deck.Shuffle(secondPlayer.Hand);

                firstPlayer.DumpTempToHand();
                secondPlayer.DumpTempToHand();
                return -1;
            }
            else
            {
                return indexCard;
            }
        }
    }
}