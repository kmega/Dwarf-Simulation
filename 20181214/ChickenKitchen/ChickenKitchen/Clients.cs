namespace ChickenKitchen
{
    partial class Program
    {
        class Clients
        {
            string name { get; set; }
            Werehouse order { get; set; }
            string[] OrderedDish = { "Fries", "SmashedPotatoes" };

            public Clients(string name1, Werehouse order1)
            {
                name = name1;
                order = order1;
            }
        }
    }
}
