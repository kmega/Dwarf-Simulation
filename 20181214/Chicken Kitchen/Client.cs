using System.Collections.Generic;

namespace Chicken_Kitchen
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Allergy> Allergies { get; set; }

        public Client(string firstName, string lastName, List<Allergy> allergies)
        {
            FirstName = firstName;
            LastName = lastName;
            Allergies = allergies;
        }
    }
}