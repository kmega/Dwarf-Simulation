using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenChicken
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ListsAndDictionaries FoodDataBase = new ListsAndDictionaries();
            DisplayStatus displayStatus = new DisplayStatus();
            List<Client> ClientList = new List<Client>
            {
                new Client("Julie Mirage", "Soy".Split(','),
                "Fish In Water"),
                new Client("Elon Carousel", "Vinegar,olives".Split(','),
                "Fish In Water"),
                new Client("Julie Mirage", "".Split(','),
                "Emperor Chicken"),
                new Client("Bernard Unfortunate", "Potatoes".Split(','),
                "Emperor Chicken"),
                new Client("Adam Smith", "Potatoes".Split(','),"Fries")
            };
            //pobierz klienta z alergia i danie -> 
            //GetInput GI = new GetInput();
            //string client = GI.getInput("imie i nazwisko klienta:");
            //string allergy = GI.getInput("alergie:");
            //string order = GI.getInput("zamowienie:");
            
            foreach (var x in ClientList)
            {
                //Sprawdzenie czy nie ma uczulenia i wydanie dania
                //Lista z podstawowymi skladnikami
                if (x.allergy.Length == 0)
                {
                    //wyswietlic dania na ktore nie ma allergi
                    displayStatus.DisplayOrder(x.name, x.order);
                    //jesli ma uczulenie I danie ktore zamowil posiada skladnik
                    //na ktory jest uczulony -> odmow wydania
                }
                else
                {
                    //test(x.order, x.allergy, x.name);
                    foreach (var allergen in x.allergy)
                    {
                        if (FoodDataBase.Dishes[x.order].Contains(allergen))
                        {
                            displayStatus.DenyOrder(x.name, x.order);
                            break;
                        }
                        else
                        {
                            displayStatus.DisplayOrder(x.name, x.order);
                        }
                    }
                }


            }
            Console.ReadKey();
        }
    }
}
