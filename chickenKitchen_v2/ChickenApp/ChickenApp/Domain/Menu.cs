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
            List<string> YouthSauce = new List<string>() { "asparagus", "milk", "honey" };
            List<string> SpicySauce = new List<string>() { "paprica", "garlic", "water" };
            List<string> OmegaSauce = new List<string>() { "lemon","water" };
            List<string> DiamondSalad= new List<string>() { "tomatoes", "pickles", "feta" };
            List<string> RubySalad = new List<string>() { "tomatoes", "vinegar" };
            List<string> Fries = new List<string>() { "potatoes" };
            List<string> SmashedPotatoes = new List<string>() { "potatoes" };
            List<string> TunaCake = new List<string>() { "tuna", "chocolate", "youth sauce" };
            List<string> FishInWater = new List<string>() { "tuna", "omega sauce","ruby salad" };

            Alergens.Add("emperor chicken", EmperorChicken);
            Alergens.Add("fat cat chicken", FatCatChicken);
            Alergens.Add("princess chicken", PrincessChicken);
            Alergens.Add("youth sauce", YouthSauce);
            Alergens.Add("spicy sauce", SpicySauce);
            Alergens.Add("omega sauce", OmegaSauce);
            Alergens.Add("diamond salad", DiamondSalad);
            Alergens.Add("ruby salad", RubySalad);
            Alergens.Add("fries", Fries);
            Alergens.Add("smashed potatoes", SmashedPotatoes);
            Alergens.Add("tuna cake", TunaCake);
            Alergens.Add("fish in water", FishInWater);
            return Alergens;
        
    }
        
    }
}
