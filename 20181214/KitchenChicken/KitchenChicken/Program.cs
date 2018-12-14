using System;
using System.Collections.Generic;

namespace KitchenChicken
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //pobierz klienta z alergia -> 
            string client = "Adam Smith";
            string allergy = "Chicken";
            string order = "Fries";
            //slownik <klient, uczulenie>
            //Dictionary<Client, Allergy> Clients = new Dictionary<Client, Allergy>
            //{
            //    { new Client("Adam Smith"), new Allergy("") }
            //};

            //Dictionary<Dish, Ingriedents> Menu = new Dictionary<Dish, Ingriedents>
            //{
            //    { new Dish("Fries"), new Ingriedents("Potatoes")}
            //};

            //Lista z podstawowymi skladnikami
            List<string> BaseIngriedients = new List<string>
            {
                "Chicken","Tuna"
            };

            if(BaseIngriedients.Contains(allergy))
            {
                Console.WriteLine("{0} posiada alergie na {1}", client, allergy);
                Console.WriteLine("Nie moze zjesc {0}", order);
            }
            else 
            {
                //wyswietlic dania na ktore nie ma allergi
                Console.WriteLine("{0} moze zjesc {1}", client, order);
            }

            //dla nieuczulonego klienta -> najprostsze danie
            //pobierz danie ->

        }
    }
}
