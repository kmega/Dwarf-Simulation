using System;
using System.Collections.Generic;
using System.Linq;
namespace chicken_kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Foods
            //Dictionary<string, List<string>>  FoodList = new Dictionary<string, List<string>>();
            Dictionary<string, int> baseIngredients = new Dictionary<string, int>()
            {
                {"Chicken", 10}, {"Tuna", 10}, {"Potatoes", 10}, {"Asparagus", 10}, {"Milk", 10},
                {"Honey", 10}, {"Paprika", 10}, {"Garlic", 10}, {"Water", 10}, {"Lemon", 10},
                {"Tomatoes", 10}, {"Pickles", 10}, {"Feta", 10}, {"Vinegar", 10}, {"Rice", 10}, {"Chocolate", 10}
            };

            // Customes
            string[] Customers = {"Julie Mirage", "Elon Carousel", "Adam Smith", "Bernard Unfortunate"}; 
            string[] Foods = {"Emperor Chicken", "Fries", "Fish In Water"};


            //FoodList.Add("Fries", Ingredients);
            //Ingredients.Add("Potatoes", 10);

            //Customers.Add("Adam Smith");
            //Customers.Add("Adam", "Smith");

            Console.WriteLine("Select Customer:");
            Console.WriteLine("1: Julie Mirage,  2: Elon Carousel, 3: Adam Smith, 4: Bernard Unfortunate");
            int chooseCustomer = int.Parse(Console.ReadLine());

            switch (chooseCustomer)
            {
                case 1:
                {
                    
                    Console.WriteLine("Select Food");
                    Console.WriteLine("1: Emperor Chicken, 2: Fries, 3: Fish In Water");
                    int chooseFood = int.Parse(Console.ReadLine());

                    
                    switch (chooseFood)
                    {
                        case 1:
                        {
                            Console.WriteLine("{0} was eat {1}", Customers[chooseCustomer-1], Foods[chooseFood-1]);
                                                        
                            break;
                        }
                        case 2:
                        {
                            Console.WriteLine("{0} was eat {1}", Customers[chooseCustomer-1], Foods[chooseFood-1]);
                            int value = baseIngredients["Potatoes"];
                            Console.WriteLine("Potatoes base ingredients: {0} ", value-1);
                            break;
                        }
                        case 3:
                        {
                            Console.WriteLine("{0} was eat {1}", Customers[chooseCustomer-1], Foods[chooseFood-1]);
                            break;
                        }
                    }          
                                        
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Select Food");
                    Console.WriteLine("1: Emperor Chicken, 2: Fries, 3: Fish In Water");
                    int chooseFood = int.Parse(Console.ReadLine());

                    
                    switch (chooseFood)
                    {
                        case 1:
                        {
                            Console.WriteLine("{0} was eat {1}", Customers[chooseCustomer-1], Foods[chooseFood-1]);
                                                        
                            break;
                        }
                        case 2:
                        {
                            Console.WriteLine("{0} was eat {1}", Customers[chooseCustomer-1], Foods[chooseFood-1]);
                            int value = baseIngredients["Potatoes"];
                            Console.WriteLine("Potatoes base ingredients {0}: ", value-1);
                            break;
                        }
                        case 3:
                        {
                            Console.WriteLine("{0} uses Chocolate {1} is allergic to it", Foods[chooseFood-1], Customers[chooseCustomer-1]);
                            break;
                        }
                    }
                    
                    break;

                }
                case 3:
                {
                    Console.WriteLine("Select Food");
                    Console.WriteLine("1: Emperor Chicken, 2: Fries, 3: Fish In Water");
                    int chooseFood = int.Parse(Console.ReadLine());

                    
                    switch (chooseFood)
                    {
                        case 1:
                        {
                            Console.WriteLine("{0} was eat {1}", Customers[chooseCustomer-1], Foods[chooseFood-1]);
                                                        
                            break;
                        }
                        case 2:
                        {
                            Console.WriteLine("{0} was eat {1}", Customers[chooseCustomer-1], Foods[chooseFood-1]);
                            int value = baseIngredients["Potatoes"];
                            Console.WriteLine("Potatoes base ingredients {0}: ", value-1);
                            break;
                        }
                        case 3:
                        {
                            Console.WriteLine("{0} was eat {1}", Customers[chooseCustomer-1], Foods[chooseFood-1]);
                            break;
                        }
                    }
                    break;
                }
                
            }

        }
    }
}
