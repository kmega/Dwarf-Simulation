using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chickenKitchenApp
{
    class Food
    {
        List<string> listOfServedFood = new List<string>();

        public void AddFoodToListOfServedFood()
        {
            listOfServedFood.Add("fries");
        }
       
    }

    class ClientsAndTheirAllergies
    {
        Dictionary<string, List<string>> bindedClientsAndAllergies = new Dictionary<string, List<string>>();

        public List<string> alergiesOf_AdamSmith { get; private set; }

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
        }
    }

    class BindingClientsWithTheirAlergies
    {

    }

    class BindingAlergiesWithFood
    {

    }

    class ServeClientsNeedsRefuseAccept
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
