using System;

namespace TheWorldOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Użytkownik -> HandStrength
            // Użytkownik -> DifficultyLevel
             var (handStrength, difficultyLevel) = ReadFromUser();

            // HandStrength, DifficultyLevel -> ZbudujPulę -> Pool
            Card[] pool = new CardPoolBuilder().BuildPool(handStrength, difficultyLevel);

            // Pool -> Losowanie -> TwoCards
            Card[] twoCards = SelectTwoCards(pool);

            // TwoCards -> Porównanie -> GameResult
            GameResult result = CompareCards(twoCards);

            // GameResult -> Użytkownik
            DisplayResult(result);
        }

        private static (HandStrength, DifficultyLevel) ReadFromUser()
        {
            return (HandStrength.Normal, DifficultyLevel.Risky);
        }

        private static void DisplayResult(GameResult result)
        {
            throw new NotImplementedException();
        }

        private static GameResult CompareCards(Card[] twoCards)
        {
            throw new NotImplementedException();
        }

        private static Card[] SelectTwoCards(Card[] pool)
        {
            throw new NotImplementedException();
        }
        
    }
}
