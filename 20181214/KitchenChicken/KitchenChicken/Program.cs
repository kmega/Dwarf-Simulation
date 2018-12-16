using System;
using System.Collections.Generic;
//slownik <klient, uczulenie>
//Dictionary<Client, Allergy> Clients = new Dictionary<Client, Allergy>
//{
//    { new Client("Adam Smith"), new Allergy("") }
//};

//Dictionary<Dish, Ingriedents> Menu = new Dictionary<Dish, Ingriedents>
//{
//    { new Dish("Fries"), new Ingriedents("Potatoes")}
//};
namespace KitchenChicken
{
    class MainClass
    {
        public static void Main(string[] args)
        {
        //pobierz klienta z alergia i danie -> 
            //GetInput GI = new GetInput();
            //string client = GI.getInput("imie i nazwisko klienta:");
            //string allergy = GI.getInput("alergie:");
            //string order = GI.getInput("zamowienie:");
            string client = "Adam Smith";
            string allergy = "Potatoes";
            string order = "Fries";
            

        //Sprawdzenie czy nie ma uczulenia i wydanie dania
            //Lista z podstawowymi skladnikami
            List<string> BaseIngriedients = new List<string>
            {
                "Chicken","Tuna","Potatoes","Asparagus","Milk","Honey","Paprika","Garlic"
            };

            Dictionary<string, List<string>> FoodDataBase = new Dictionary<string, List<string>>();
            FoodDataBase.Add("Fries", new List<string> { "Potatoes" });

            if(allergy=="")
            {
                //wyswietlic dania na ktore nie ma allergi
                Console.WriteLine("{0} moze zjesc {1}", client, order);
                
            }
            //jesli ma uczulenie I danie ktore zamowil posiada skladnik
            //na ktory jest uczulony -> odmow wydania
            else
            {
                //if (BaseIngriedients.Contains(allergy) && )
                bool temp = FoodDataBase.ContainsKey(order);
                bool temp2 = FoodDataBase[order].Contains(allergy);
                if(temp == true && temp2 == true)
                {
                    Console.WriteLine("{0} posiada alergie na {1}", client, allergy);
                    Console.WriteLine("Nie moze zjesc {0}", order);
                }
                
            }

            Console.ReadKey();
        }
    }
}
