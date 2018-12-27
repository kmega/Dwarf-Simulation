using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Result
    {
        public string GetResult(List<Cards> cards)

        {
            Random rnd = new Random();
            int result = 0;

            for (int i = 0; i < 2; i++)
            {
                int r = rnd.Next(cards.Count);

                result += cards[r-1].value;
                cards.RemoveAt(r);

            }
            if (result > 0)
            {
                string reulttxt = "Wygrałeś";
                return reulttxt;
            }
            else if (result == 0)
            {
                string reulttxt = "Remis";
                return reulttxt;
            }
            else
            {
                string reulttxt = "Przegrałeś";
                return reulttxt;
            }
        }
    }
}