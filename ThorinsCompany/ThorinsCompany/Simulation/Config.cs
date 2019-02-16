using System;

namespace ThorinsCompany
{
    public class Config
    {
        public Bank  Bank { get; private set; }
        public Mine Mine { get; private set; }
        public Hospital  Hospital { get; private set; }
        public Shop  Shop { get; private set; }
        public Bar  Bar { get; private set; }
        public Guild Guild { get; private set; }
        public Displayer Displayer { get; private set; }



        public void CreateBank() => Bank = new Bank();
        public void CreateHospital() =>  Hospital = new Hospital();
        public void CreateBar() =>  Bar = new Bar();
        public void CreateGuild() =>  Guild = new Guild();
        public void CreateMine() =>  Mine = new Mine();     
        public void CreateDisplayer() =>  Displayer = new Displayer();
        public void CreateShop() => Shop = new Shop();
        

    }
}