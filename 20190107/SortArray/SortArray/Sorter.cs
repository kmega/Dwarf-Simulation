using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SortArray
{
    public class Sorter
    {
        List<string> Letters = new List<string>();
        List<string> Num = new List<string>();
        List<string> EvenLett = new List<string>();
        List<string> OddLett = new List<string>();

        public string[] SortArray(string[] arrayToSort)
        {
            SortedNumbers(arrayToSort);
            SortedLetters(this.Letters.ToArray());

            string[] oddLetters = OddLett.ToArray();
            string[] evenLetters = EvenLett.ToArray();
            string[] numbers = Num.ToArray();

            int succCounter_Num = 0;
            int succCounter_oddLett = 0;
            int succCounter_evenLett = 0;

            do
            {

                for (int i = 0; i < numbers.Length; i++)
                {

                    int n_1 = 0;
                    Int32.TryParse(numbers[i], out n_1);

                    for (int j = 0; j < numbers.Length; j++)
                    {
                        int n_2 = 0;
                        Int32.TryParse(numbers[j], out n_2);
                        if (i == j)
                            continue;

                        string higherInArr = CompareBoth(n_1, n_2, i, j);
                        if (higherInArr == "first")
                        {
                            string tmp = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = tmp;
                            succCounter_Num++;

                        }
                    }
                }
            } while (succCounter_Num < numbers.Length);

            do
            {
                for (int i = 0; i < oddLetters.Length; i++)
                {
                    char[] lettersToSort_1 = oddLetters[i].ToCharArray();

                    for (int j = 0; j < oddLetters.Length; j++)
                    {
                        char[] lettersToSort_2 = oddLetters[i].ToCharArray();

                        if (i == j)
                            continue;

                        string higherInArr = CompareBoth(lettersToSort_1[0], lettersToSort_2[0], i, j);
                        if (higherInArr == "first")
                        {
                            string tmp = oddLetters[i];
                            oddLetters[i] = oddLetters[j];
                            oddLetters[j] = tmp;
                            succCounter_oddLett++;

                        }
                    }
                }
            } while (succCounter_oddLett < oddLetters.Length);

            do
            {
                for (int i = 0; i < evenLetters.Length; i++)
                {
                    char[] lettersToSort_1 = evenLetters[i].ToCharArray();
                    double letterNumericVal_1 = char.GetNumericValue(lettersToSort_1[0]);

                    for (int j = 0; j < evenLetters.Length; j++)
                    {
                        char[] lettersToSort_2 = evenLetters[i].ToCharArray();
                        double letterNumericVal_2 = char.GetNumericValue(lettersToSort_2[0]);

                        if (i == j)
                            continue;
                        string higherInArr = CompareBoth(lettersToSort_1[0], lettersToSort_2[0], i, j);

                        if (higherInArr == "first")
                        {
                            string tmp = evenLetters[i];
                            evenLetters[i] = evenLetters[j];
                            evenLetters[j] = tmp;
                            succCounter_evenLett++;

                        }
                    }
                }
            } while (succCounter_evenLett < evenLetters.Length);
            

            string[] merge = oddLetters.Concat(numbers).ToArray();
            string[] mergedAll = merge.Concat(merge).ToArray();

            return mergedAll;

        }

        private string CompareBoth(int n_1, int n_2, int i, int j)
        {
            string higher = "first";
            if (i<j)
            {
                if (n_1 > n_2)
                {
                    higher = "second";
                }
                else higher = "first";
            }

            if (i > j)
            {
                if (n_1 > n_2)
                {
                    higher = "first";
                }
                else higher = "second";
            }

            return higher;

        }

        private void SortedNumbers(string[] arrayToSort)
        {
            int n = 0;
 
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                bool parsed = Int32.TryParse(arrayToSort[i], out n);

                if(parsed == true)
                {
                    this.Num.Add(n.ToString());
                }
                else
                {
                    this.Letters.Add(arrayToSort[i]);
                }

            }

        }

        private void SortedLetters(string[] arrayToSort)
        {
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                char[] lettersToSort = arrayToSort[i].ToCharArray();

                if (lettersToSort[0] % 2 == 0)
                    this.EvenLett.Add(arrayToSort[i]);
                else
                    this.OddLett.Add(arrayToSort[i]);
            }
        }

    }
}
