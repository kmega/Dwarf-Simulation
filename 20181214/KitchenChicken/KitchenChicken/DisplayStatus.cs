using System;


namespace KitchenChicken
{
    class DisplayStatus
    {
        public void DisplayOrder(string client, string order)
        {
            Console.WriteLine("{0} moze zjesc {1}", client, order);
        }

        public void DenyOrder(string client, string[] allergy)
        {
            Console.WriteLine("{0} posiada alergie na {1}", client, allergy[0].ToString());
        }
    }
}
