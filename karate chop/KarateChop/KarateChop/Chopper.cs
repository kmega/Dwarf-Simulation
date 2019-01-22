using System;
using System.Collections.Generic;
using System.Text;

namespace KarateChop
{
    public class Chopper
    {
        private bool FinishChopping;
        public int ChopInHalf(int targetNumber, int[] arrayToChop)
        {
            int[] arrayToChopBackUp = arrayToChop;
            int searchedIndex = -1;

            if (arrayToChop.Length == 1 && arrayToChop[0] != targetNumber)
                return -1;
            if (arrayToChop.Length == 1 && arrayToChop[0] == targetNumber)
                return 0;

                do
            {
                if (arrayToChop.Length == 0)
                {
                    return -1;
                }
                
                
                try
                {
                    int[] correctHalf = CheckHalves(targetNumber, arrayToChop);
                    if (correctHalf.Length == 1 && correctHalf[0] != targetNumber)
                        return -1;

                    arrayToChop = correctHalf;
                }
                catch (Exception)
                {

                    return -1;
                }


            } while (FinishChopping == false);

            for (int i = 0; i < arrayToChopBackUp.Length; i++)
            {
                if (arrayToChopBackUp[i] == arrayToChop[0])
                {
                    searchedIndex = i;
                    break;
                }
            }

            return searchedIndex;
        }

        private int[] CheckHalves(int targetNumber, int[] arrayToChop)
        {
            List<int> choppedArray = new List<int>();

            int arrLength = arrayToChop.Length-1;
            int leveller = 0;
            

            if (arrayToChop[(arrLength + leveller) / 2] == targetNumber || arrayToChop[arrLength] == targetNumber)
            {
                FinishChopping = true;
                choppedArray.Add(targetNumber);
            }
            else if (arrayToChop[(arrLength + leveller) / 2] >= targetNumber)
            {
                for (int i = 0; i < arrLength / 2; i++)
                {
                    choppedArray.Add(arrayToChop[i]);
                }
            }
            else
            {
                for (int i = arrLength / 2; i < arrLength; i++)
                {
                    choppedArray.Add(arrayToChop[i]);
                }
            }

            return choppedArray.ToArray();


        }
    }
}
