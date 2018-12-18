using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chickenKitchenApp
{
    class FoodAndItsAllergicIngredients
    {
        public Dictionary<string, List<string>> ListOfAllDishesWithItsAlergicIngredients()
        { 

         Dictionary<string, List<string>> foodWithItsAllergicIngredients = new Dictionary<string, List<string>>();

         List<string> fries = new List<string>();

         fries.Add("potatoes");

         foodWithItsAllergicIngredients.Add("fries", fries);

            return foodWithItsAllergicIngredients;

        }
    }

    class ClientsAndTheirAllergies
    {
        public Dictionary<string, List<string>> ListOfAllergiesOfClients()
        {
         Dictionary<string, List<string>> bindedClientsAndAllergies = new Dictionary<string, List<string>>();

         List<string> alergiesOf_AdamSmith = new List<string>();
         List<string> alergiesOf_ElonCarousel = new List<string>();

         alergiesOf_ElonCarousel.Add("olives");
         alergiesOf_ElonCarousel.Add("vinegar");  //how to add in one line?
   
         bindedClientsAndAllergies.Add("Adam Smith", alergiesOf_AdamSmith );
         bindedClientsAndAllergies.Add("Elon Carousel", alergiesOf_ElonCarousel);

            return bindedClientsAndAllergies;
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

            Dictionary<string, List<string>> _orderedDish = orderedDish.ListOfAllDishesWithItsAlergicIngredients();
            Dictionary<string, List<string>> _servedCustomer = servedCustomer.ListOfAllergiesOfClients();

            allergensIn_Dish = _orderedDish[dish_name];
            allergiesOf_TheCustomer = _servedCustomer[customer_name];


            AskingForDishAndNameOfCustomer serveCustomer = new AskingForDishAndNameOfCustomer();

           bool serveOrNot = serveCustomer.CompareAllergiesOfClientsWithAllergensInDish(allergiesOf_TheCustomer, allergensIn_Dish);
           string answerToCustomer = (serveOrNot == true) ? "Here's Your dish!" : "You're allergic to it, I can't serve You this meal";

            Console.WriteLine(answerToCustomer);
       
        }

        public bool CompareAllergiesOfClientsWithAllergensInDish(List<string> allergies, List<string> allergens)
        {
            if (allergies.Count == 0) { return true; }

            foreach (string allergy in allergies)
            {
                
                foreach (string allergen in allergens)
                {
                  
                    if ( allergy == allergen ) { return false; }
                    else { return true; }
                }
            }

            return false;

            //string answerToCustomer = (serveOrNot == true) ? "Here's Your dish!" : "You're allergic to it, I can't serve You this meal";

            // Console.WriteLine(answerToCustomer);
            /*string allergy;
            string allergen;
            for (int i=0;i<allergies.Count;i++)
            {
                allergy = allergies[i];

                for (int j=0; j<allergens.Count;j++)
                {
                    allergen = allergens[j];
                    if (allergy == allergen || allergy == null) { Console.WriteLine("Here's Your dish!"); }
                    else { Console.WriteLine("You're allergic to it, I can't serve You this meal"); }
                }
            }*/

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //1. Creating list of dishes && dictionary with its ingredients

            //2. Creating list of customers and their allergies && dictionary with their allergies

            //3. Asking customer for a dish && compare values && print result
 
            AskingForDishAndNameOfCustomer askingCustomer = new AskingForDishAndNameOfCustomer();
            askingCustomer.AskForDish();
            Console.ReadKey();
        }
    }
}
