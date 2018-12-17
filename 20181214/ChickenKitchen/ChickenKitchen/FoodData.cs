using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class FoodData
    {
        public static readonly List<string> baseIngredients = new List<string>() { "Chicken", "Tuna", "Potatoes", "Asparagus", "Milk", "Honey", "Paprika", "Garlic", "Water", "Lemon", "Tomatoes", "Pickles", "Feta", "Vinegar", "Rice", "Chocolate" };
        public static Dictionary<string,List<string>> getFoodDictionary(string path)
        {
            Dictionary<string, List<string>> foodDictionary = new Dictionary<string, List<string>>();
            using (StreamReader streamReader = new StreamReader(path))
            {
                string line = "";
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] splittedLine = line.Split(',');
                    string foodName = splittedLine[0].Trim();
                    List<string> ingredients = new List<string>();
                    for (int i = 1; i < splittedLine.Length; i++)
                        ingredients.Add(splittedLine[i].Trim());
                    foodDictionary.Add(foodName, ingredients);
                }
            }
            return foodDictionary;
        }
    }
}
