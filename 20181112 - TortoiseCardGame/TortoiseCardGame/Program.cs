using System;

namespace TortoiseCardGame
{
    public enum DifficultyLevel
    {
        Easy, Normal, Risky, Heroic
    }

    class Program
    {
        static string TakeAnwserFromUser(string information)
        {
            System.Console.WriteLine("Podaj" + information + "Słaba -1, Normalna -2 , Silna - 3:");
            string choice = Console.ReadLine();
            return choice;
        }
        static int ChooseHandStrength()
        {
            string choice = TakeAnwserFromUser("Siłę ręki");

            switch (choice)
            {
                case "1":
                    return 3;
                case "2":
                    return 6;
                case "3":
                    return 9;
                default:
                    throw new Exception("Błędny argument");
            }
        }

        static Deck CreateDeckBasedOnDifficultyLevel(int handStrength)
        {
            string choice = TakeAnwserFromUser("poziom trudność");
            int hearts = handStrength;
            int clubs = 0;
            int diamonds = 3;

            switch (choice)
            {
                case "1":
                    hearts += 2;
                    clubs += 4;
                    break;
                case "2":
                    clubs += 6;
                    break;
                case "3":
                    hearts -= 2;
                    clubs += 8;
                    break;
                default:
                    throw new System.Exception("Błędny argument");
            }
            Deck deck = new Deck();
            
            deck.Clubs = clubs;
            deck.Diamonds = diamonds;
            return deck;
        }
        static WarState DisplayResults(CardType[] cardTypes)
        {
            if (cardTypes[0] == CardType.hearts 
                && cardTypes[1] == CardType.hearts)
            {
                return WarState.Winner;
            }
            return WarState.Tie;
        }
        static void Main(string[] args)
        {
            // 1. Wybierz Siłę Ręki
            int handStrength = ChooseHandStrength();
            // 2. Wybierz Poziom trudność
            Deck deck = CreateDeckBasedOnDifficultyLevel(handStrength);
            // 3. Wylosuj dwie karty 
            CardType[] cardTypes =  deck.DrawTwoCards();
            // 4. Wyświetl wynik -- rezultat
            DisplayResults(cardTypes);

            System.Console.ReadKey();
        }
    }
}
