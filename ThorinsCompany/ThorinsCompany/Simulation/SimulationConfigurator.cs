using System;

namespace ThorinsCompany
{
    public class SimulationConfigurator
    {
        private Config _config;
        public SimulationConfigurator()
        {
            _config = new Config();
        }
        public Config getConfig()
        {
            _config.CreateHospital();
            _config.CreateBank();
            _config.CreateShop();
            _config.CreateBar();
            _config.CreateMine();
            _config.CreateGuild();

            return _config;
        }
    }
}