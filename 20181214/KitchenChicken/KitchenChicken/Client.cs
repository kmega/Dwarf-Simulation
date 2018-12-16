namespace KitchenChicken
{
    class Client
    {
        public string name;
        public string[] allergy;
        public string order;
        public Client(string name, string[] allergy, string order)
        {
            this.name = name;
            this.allergy = allergy;
            this.order = order;
        }
    }
   
}
