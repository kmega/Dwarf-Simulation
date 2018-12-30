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
}
