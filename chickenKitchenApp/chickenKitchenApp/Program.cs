using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chickenKitchenApp
{
    class FoodAndItsAllergicIngredients
    {
        public Dictionary<string, List<string>> foodWithItsAllergicIngredients = new Dictionary<string, List<string>>();

        public List<string> fries { get; private set; }

        public void ListOfAllDishesWithItsAlergicIngredients()
        {
            List<string> fries = new List<string>();

            fries.Add("potatoes");
        }

        public void AddingIngredientsToSpecificDishes()
        {
            foodWithItsAllergicIngredients.Add("fries", fries);
        }
       
    }

    class ClientsAndTheirAllergies
    {
        public Dictionary<string, List<string>> bindedClientsAndAllergies = new Dictionary<string, List<string>>();

        public List<string> alergiesOf_AdamSmith { get; private set; }
        public List<string> alergiesOf_ElonCarousel { get; private set; }

        public void ListOfAllergiesOfClients()
        {
            List<string> alergiesOf_AdamSmith = new List<string>();
            List<string> alergiesOf_ElonCarousel = new List<string>();

            alergiesOf_ElonCarousel.Add("olives");
            alergiesOf_ElonCarousel.Add("vinegar");  //how to add in one line?
        }


        public void AddAlergiesToSpecificClients()
        {
            bindedClientsAndAllergies.Add("Adam Smith", alergiesOf_AdamSmith );
            bindedClientsAndAllergies.Add("Elon Carousel", alergiesOf_ElonCarousel);

        }
    }


    class AskingForDishAndNameOfCustomer
    {
        public void AskForDish()
        {
            Console.WriteLine("Hello! Welcome to our CHICKEN-KITCHEN restaurant. What is Your name?");
            string nameOfCustomer = Console.ReadLine();
            Console.WriteLine("It's so nice to meet You, {0}! What would You like to order?", nameOfCustomer);
            string nameOfOrderedDish = Console.ReadLine();
            CompareClientWithItsOrderAndAllergies(nameOfCustomer, nameOfOrderedDish);

        }

        public void CompareClientWithItsOrderAndAllergies(string customer_name, string dish_name)
        {
            List<string> allergiesOf_TheCustomer = new List<string>();
            List<string> allergensIn_Dish = new List<string>();

            FoodAndItsAllergicIngredients orderedDish = new FoodAndItsAllergicIngredients();

            ClientsAndTheirAllergies servedCustomer = new ClientsAndTheirAllergies();

            List<string> customerAsKey = servedCustomer.bindedClientsAndAllergies.Keys.ToList();

            foreach (string k in customerAsKey)
            {
                allergiesOf_TheCustomer = (k == customer_name) ? servedCustomer.bindedClientsAndAllergies[k] : null;
            }

            if (allergiesOf_TheCustomer != null)
            {
                foreach (string a in orderedDish.foodWithItsAllergicIngredients[dish_name])
                {
                    allergensIn_Dish = (a == dish_name) ? orderedDish.foodWithItsAllergicIngredients[a] : null;
                }
            }

           bool serveOrNot = CompareAllergiesOfClientsWithAllergensInDish(allergiesOf_TheCustomer, allergensIn_Dish);
           string answerToCustomer = (serveOrNot == true) ? "Here's Your dish!" : "You're allergic to, I can't serve You this meal";

            Console.WriteLine(answerToCustomer);

        }

        public bool CompareAllergiesOfClientsWithAllergensInDish(List<string> allergies, List<string> allergens)
        {
            foreach (string allergy in allergies)
            {
                foreach(string allergen in allergens)
                {
                    if ( allergy == allergen ) { return true; }
                    else { return false;  }
                }
            }

            return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //1. Creating list of dishes && dictionary with its ingredients

            FoodAndItsAllergicIngredients food = new FoodAndItsAllergicIngredients();
            food.ListOfAllDishesWithItsAlergicIngredients();
            food.AddingIngredientsToSpecificDishes();

            //2. Creating list of customers and their allergies && dictionary with their allergies

            ClientsAndTheirAllergies customers = new ClientsAndTheirAllergies();
            customers.ListOfAllergiesOfClients();
            customers.AddAlergiesToSpecificClients();

            //3. Asking customer for a dish && compare values && print result
            
            AskingForDishAndNameOfCustomer askingCustomer = new AskingForDishAndNameOfCustomer();
            askingCustomer.AskForDish();
            Console.ReadKey();
        }
    }
}
