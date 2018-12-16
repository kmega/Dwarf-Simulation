using System;
using System.Collections.Generic;

namespace KitchenChicken
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ListsAndDictionaries FoodDataBase = new ListsAndDictionaries();
            DisplayStatus displayStatus = new DisplayStatus();
            List<Client> ClientList = new List<Client>();
            ClientList.Add(new Client("Adam Smith", "Vinegar, olives".Split(new Char[] { ',', ' ' }),
                "Fries"));
            //pobierz klienta z alergia i danie -> 
            //GetInput GI = new GetInput();
            //string client = GI.getInput("imie i nazwisko klienta:");
            //string allergy = GI.getInput("alergie:");
            //string order = GI.getInput("zamowienie:");
            string client = "Adam Smith";
            string[] allergy = "Vinegar, olives".Split(new Char[] {',',' ' });
            string order = "Fries";


            foreach (var x in ClientList)
            {

            }
            //Sprawdzenie czy nie ma uczulenia i wydanie dania
            //Lista z podstawowymi skladnikami
            if (allergy==null)
            {
                //wyswietlic dania na ktore nie ma allergi
                displayStatus.DisplayOrder(client, order);
            }
            //jesli ma uczulenie I danie ktore zamowil posiada skladnik
            //na ktory jest uczulony -> odmow wydania
            else
            {
                bool temp = CheckingAllergens(order, allergy);
                bool ifDishExsistsinMenu = FoodDataBase.Dishes.ContainsKey(order);
                bool ifDishContainAllergen = temp || FoodDataBase.Dishes[order].Contains(order);

                if (ifDishExsistsinMenu && ifDishContainAllergen )
                {
                    displayStatus.DenyOrder(client, allergy);
                    Console.WriteLine("Nie moze zjesc {0}", order);
                }
                else
                {
                    displayStatus.DenyOrder(client, allergy);
                    displayStatus.DisplayOrder(client, order);
                }
            }
            Console.ReadKey();
        }
        public static bool CheckingAllergens(string order, string[] allergy)
        {
            bool temp = false;
            ListsAndDictionaries FoodDataBase = new ListsAndDictionaries();

            for (int i = 0; i < allergy.Length; i++)
            {
                if (FoodDataBase.Dishes[order].Contains(allergy[i]))
                {
                    temp = true;
                }
            }
            return temp;
        }
    }
    class Client
    {
        string name;
        string[] allergy;
        string order;
        public Client(string name, string[] allergy, string order)
        {
            this.name = name;
            this.allergy = allergy;
            this.order = order;
        }
    }
    class temp
    {
        public object istniejeKlient(string client)
        {
            ListsAndDictionaries FoodDataBase = new ListsAndDictionaries();

            if (FoodDataBase.RepeatedClients.ContainsKey(client))
            {
                return FoodDataBase.RepeatedClients[client];
            }
            else return null;
        }
    }
}
