using System;

namespace KitchenChicken
{
    class GetInput
    {
        public string getInput(string information)
        {
            Console.WriteLine("Podaj {0}",information);
            string value = Console.ReadLine();
            return value;
        }
    }
}
