using System;
using System.Collections.Generic;

namespace KitchenChicken
{
    class DisplayStatus
    {
        public void DisplayOrder(string client, string order)
        {
            Console.WriteLine("{0} moze zjesc {1}", client, order);
            Console.WriteLine("********");
        }

        public void DenyOrder(string client, string order, string[] allergens)
        {
            Console.WriteLine("{0} NIE moze zjesc {1}", client, order);
            DisplayAllergens(allergens);
            Console.WriteLine("********");
        }

        private void DisplayAllergens(string[] allergens)
        {
            Console.WriteLine("posiada alergie na: ");
            foreach (var item in allergens)
            {
                Console.Write("{0}, ", item);
            }
            Console.WriteLine();
        }

    }
}
