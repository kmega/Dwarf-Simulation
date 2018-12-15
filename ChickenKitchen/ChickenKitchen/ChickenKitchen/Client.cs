using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Client
    {
        public List<Enums.AllergicBase> allergens;

        public Enum Order { get; set; }

        /// <summary>
        /// Client dosn't have any allergy
        /// </summary>
        public Client()
        {
            this.allergens = null;
        }

        /// <summary>
        /// Create client with him possible allergens
        /// </summary>
        /// <param name="allergens"></param>
        public Client(List<Enums.AllergicBase> allergens)
        {
            this.allergens = allergens;
        }

    }
    
}
