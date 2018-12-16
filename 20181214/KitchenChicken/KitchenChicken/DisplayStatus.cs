using System;


namespace KitchenChicken
{
    class DisplayStatus
    {
        public void DisplayOrder(string client, string order)
        {
            Console.WriteLine("{0} moze zjesc {1}", client, order);
            Console.WriteLine("********");
        }

        public void DenyOrder(string client, string order)
        {
            Console.WriteLine("{0} posiada alergie", client);
            Console.WriteLine("{0} NIE moze zjesc {1}", client, order);
            Console.WriteLine("********");
        }
    }
}
