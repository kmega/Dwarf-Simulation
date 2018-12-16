using System.Collections.Generic;
namespace KitchenChicken
{
    class ListsAndDictionaries
    {
        public List<string> BaseIngriedients = new List<string>
            {
                "Chicken","Tuna","Potatoes","Asparagus","Milk","Honey","Paprika","Garlic","Water","Lemon",
                "Tomatoes", "Pickles", "Feta", "Vinegar", "Rice", "Chocolate"
            };

        public Dictionary<string, List<string>> Dishes = new Dictionary<string, List<string>>
            {
                {"Emperor Chicken", new List<string>{"Fat Cat Chicken", "Spicy Sauce", "Tuna Cake"}},
                {"Fat Cat Chicken", new List<string>{"Princess Chicken", "Youth Sauce","Fries","Diamond Salad"}},
                {"Princess Chicken", new List<string>{"Chicken", "Youth Sauce" }},
                {"Youth Sauce", new List<string>{"Asparagus","Milk","Honey" } },
                {"Spicy Sauce", new List<string>{ "Paprika", "Garlic", "Water" } },
                {"Omega Sauce", new List<string>{ "Lemon", "Water" } },
                {"Diamond Salad", new List<string>{ "Tomatoes", "Pickles", "Feta" } },
                {"Ruby Salad", new List<string>{ "Tomatoes", "Vinegar" } },
                { "Fries", new List<string> { "Potatoes" } },
                { "Smashed Potatoes", new List<string> { "Potatoes" } },
                { "Tuna Cake", new List<string> { "Tuna","Chocolate", "Youth Sauce" } },
                { "Fish In Water", new List<string> { "Tuna", "Omega Sauce", "Ruby Salad" } }
            };

        //slownik <klient, uczulenie>
        public Dictionary<string, List<string>> RepeatedClients = new Dictionary<string, List<string>>
            {
                {"Julie Mirage", new List<string>{ "Soy" } },
                {"Elon Carousel", new List<string>{ "Vinegar", "olives" } },
                {"Adam Smith", new List<string>{ "" } },
                {"Barbara Smith", new List<string>{ "Chocolate" } },
                {"Christian Donnovan", new List<string>{ "Paprika" } },
                {"Bernard Unfortunate", new List<string>{ "Potatoes" } }
            };

    }
}
