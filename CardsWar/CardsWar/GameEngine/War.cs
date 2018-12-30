using System;
using System.Collections.Generic;

namespace CardsWar.GameEngine
{    
    public class War
    {
        public static Player Fight(Player firstPlayer, Player secondPlayer)
        {
            List<Deck.AllCards> poolToBattle = new List<Deck.AllCards>();

            while (firstPlayer.Hand.Count != 0 || secondPlayer.Hand.Count != 0)
            {
                for (int i = 0; i < 28; i++)
                {
                    //1. Do basic first battle, Compare firstPlayer card and secondPlayer card and return true if any player win or false if draw
                    (bool result, List<Deck.AllCards> poolToBattleBasic, int indexCard) = BasicBattle(firstPlayer, secondPlayer, poolToBattle, i, false);

                    //2 Do advanced battle if result false, until result is false
                    if(result == false)
                    {
                        AdvancedBattle(result, firstPlayer, secondPlayer, poolToBattleBasic, indexCard);
                    }
                }
                
            }
            

            return null;           
        }

        private static void AdvancedBattle(bool result, Player firstPlayer, Player secondPlayer, List<Deck.AllCards> poolToBattleBasic, int indexCard)
        {
            bool advancedLoop = true;
            do
            {

                indexCard++;
                (bool resultAdv, List<Deck.AllCards> poolToBattleAdv, int indexCardAdv) = BasicBattle(firstPlayer, secondPlayer, poolToBattleBasic, indexCard, advancedLoop);
                result = resultAdv;


            } while (result == false);
        }

        private static (bool result, List<Deck.AllCards> poolToBattleBasic, int indexCard) BasicBattle(Player firstPlayer, Player secondPlayer, List<Deck.AllCards> poolToBattleBasic, int indexCard, bool advancedLoop)
        {

                                          
            if (firstPlayer.Hand[indexCard] > secondPlayer.Hand[indexCard])
            {
                if (advancedLoop)
                {
                    poolToBattleBasic.Add(firstPlayer.Hand[indexCard]);
                    poolToBattleBasic.Add(secondPlayer.Hand[indexCard]);
                }
                

                else
                {
                    poolToBattleBasic.Clear();
                    poolToBattleBasic.Add(secondPlayer.Hand[indexCard]);
                }
                
                secondPlayer.Hand.RemoveAt(indexCard);                 
                firstPlayer.Hand.InsertRange(0, poolToBattleBasic); //Add cards to first position in list
                firstPlayer.Points++;
                return (true, null, indexCard);
            }
            else if(secondPlayer.Hand[indexCard] > firstPlayer.Hand[indexCard])
            {
                if (advancedLoop)
                {
                    poolToBattleBasic.Add(firstPlayer.Hand[indexCard]);
                    poolToBattleBasic.Add(secondPlayer.Hand[indexCard]);
                }
                

                else
                {
                    poolToBattleBasic.Clear();
                    poolToBattleBasic.Add(firstPlayer.Hand[indexCard]);
                }

                firstPlayer.Hand.RemoveAt(indexCard);
                secondPlayer.Hand.InsertRange(0, poolToBattleBasic); //Add cards to first position in list
                secondPlayer.Points++;
                return (true, null, indexCard);
            }
            else
            {             
                poolToBattleBasic.Add(firstPlayer.Hand[indexCard]);
                poolToBattleBasic.Add(secondPlayer.Hand[indexCard]);
                indexCard++;

                return (false, poolToBattleBasic, indexCard); // It mean that is draw and game need advanced battle
            }
        }
    }
}