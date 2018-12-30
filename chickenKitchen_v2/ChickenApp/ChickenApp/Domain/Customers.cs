using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenApp.Domain
{
    class Customers
    {
        public Dictionary<string,List<string>> CustomersAndAllergies()
        {
            Dictionary<string, List<string>> NamesAndAllergies = new Dictionary<string, List<string>>();

            List<string> AdamSmith = new List<string>() { "" };
            List<string> JulieMirage = new List<string>() { "soy" };
            List<string> ElonCarousel = new List<string>() { "vinegar", "olives" };
            List<string> BarbaraSmith = new List<string>() { "chocolate" };
            List<string> ChristianDonnovan = new List<string>() { "paprika" };
            List<string> BernardUnfortunate = new List<string>() { "potatoes" };

            NamesAndAllergies.Add("Adam Smith", AdamSmith);
            NamesAndAllergies.Add("Julie Mirage", JulieMirage);
            NamesAndAllergies.Add("Elon Carousel", ElonCarousel);
            NamesAndAllergies.Add("Barbara Smith", BarbaraSmith);
            NamesAndAllergies.Add("Christian Donnovan", ChristianDonnovan);
            NamesAndAllergies.Add("Bernard Unfortunate", BernardUnfortunate);

            return NamesAndAllergies;
        }
          
    }

    class Menu
    {
        public Dictionary<string, List<string>> FoodAndAllergens()
        {
            Dictionary<string, List<string>> Alergens = new Dictionary<string, List<string>>();

            List<string> EmperorChicken = new List<string>() { "fat cat chicken", "spicy sauce", "tuna cake" };
            List<string> FatCatChicken = new List<string>() { "princess chicken", "youth sauce", "fries", "diamond salad" };
            List<string> PrincessChicken = new List<string>() { "chicken", "youth sauce" };
            List<string> Fries = new List<string>() { "potatoes" };

            Alergens.Add("Emperor Chicken", EmperorChicken);
            Alergens.Add("Fat Cat Chicken", FatCatChicken);
            Alergens.Add("Princess Chicken", PrincessChicken);
            Alergens.Add("Fries", Fries);

            return Alergens;
        
    }
        
    }

    class Waiter
    {
        public void CallWaiter()
        {
            Console.WriteLine("Hello, what is Your name?");
            string name = Console.ReadLine();
            Console.WriteLine("What would You like to order, {0}", name);
            string dish = Console.ReadLine();

            bool isAllergicTo = isCusomerAlergicToOrderedDish(name, dish);

            string answer = (isAllergicTo == false) ? "Here's Your meal" : "You're allergic to it";

            Console.WriteLine(answer);
        }

        private bool isCusomerAlergicToOrderedDish(string name, string orderedDish)
        {
            Menu dishes = new Menu();
            Customers customer = new Customers();

            Dictionary<string, List<string>> allergensInFood = dishes.FoodAndAllergens();
            Dictionary<string, List<string>> allergiesOfCustomers = customer.CustomersAndAllergies();
            bool isAlergic = false;

            foreach ( string dishAlergens in allergensInFood[orderedDish])
            {
                foreach (string customersAllergie in allergiesOfCustomers[name])
                {
                    if (dishAlergens == customersAllergie) { isAlergic = true; }
                }
            }

            return isAlergic;
        }
    }
}
