using System.Collections.Generic;

namespace KitchenChicken
{
    public class Allergy
    {
        List<string> ClientsAllergy = new List<string>();
        public Allergy(string ClientsAllergy)
        {
            this.ClientsAllergy.Add(ClientsAllergy);
        }
    }


}
