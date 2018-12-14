using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wejście lista składników, ilości

            Dictionary<Ingredient, int> ingredientsWarehouse = new Dictionary<Ingredient, int>();
            ingredientsWarehouse.Add(Ingredient.Potatoes, 10);

            //Lista potraw
            List<Dishes> dishesList = new List<Dishes>();
            dishesList.Add(Dishes.Fries);
            dishesList.Add(Dishes.SmashedPotatoes);

            //Wybór i sprawdzenie potrawy

            string choice = Console.ReadLine();

            for (int i = 0; i < dishesList.Count -1; i++)
            {
                if (choice == dishesList[i].ToString())
                {
                    Console.WriteLine("yes");
                }
            }

            //Sprawdzenie składników

            //stworzenie potrawy - odjęcie dostępnych składników 

            Console.ReadKey();


        }

    
    }
}
