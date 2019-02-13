using System;

namespace ThorinsCompany
{
    public class Config
    {
        public IBank  Bank { get; private set; }
        public IMine Mine { get; private set; }
        public IHospital  Hospital { get; private set; }
        public IShop  Shop { get; private set; }
        public IBar  Bar { get; private set; }
        public IGuild  Guild { get; private set; }


        public void CreateBank() =>  Bank = new Bank();
        public void CreateHospital() =>  Hospital = new Hospital();
        public void CreateBar() =>  Bar = new Bar();
        public void CreateShop() =>  Shop = new Shop();
        public void CreateGuild() =>  Guild = new Guild();
        public void CreateMine() =>  Mine = new Mine();     
    }
}