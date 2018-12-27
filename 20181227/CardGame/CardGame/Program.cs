using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {

         
            Dictionary<CardsTypes, int> bet = new Dictionary<CardsTypes, int>()
            {
                {CardsTypes.Kier, 0 },
                {CardsTypes.Trefl,0 },
                {CardsTypes.Karo, 0 }
            };
            Console.WriteLine("Witaj w grze w karty. Podaj siłę ręki: \n1 - Słaba \n2 - Średnia \n3 - Silna");
            string choice = Console.ReadLine();
            new HandStrenght().GetHandStrenght(bet,choice);
            Console.WriteLine(" Podaj poziom trudności zakładu: \n1 - Łatwy \n2 - Średni \n3 - Trudny");
            choice = Console.ReadLine();
            Console.WriteLine();
            new DifficultLevel().GetDifficultLevel(bet,choice);
            List<Cards> pool = new Croupier().CreatePool(bet);
            Console.WriteLine();
            string result = new Result().GetResult(pool);
            Console.WriteLine();
            Console.WriteLine(result);

            

            Console.ReadKey();
        }
    }

    
}
