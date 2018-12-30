using System.Collections.Generic;

namespace ChickenApp.Domain
{
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
}
