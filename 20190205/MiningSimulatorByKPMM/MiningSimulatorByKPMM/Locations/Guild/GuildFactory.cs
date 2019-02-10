using MiningSimulatorByKPMM.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Guild
{
    public static class GuildFactory
    {

        public static Guild CreateStandardGuild()
        {
            Guild guild = new Guild(new Dictionary<E_Minerals, ICreateOreValue>()
            { { E_Minerals.Gold, new ValueOfGold() },
                {E_Minerals.DirtGold, new ValueOfDirtGold() },
                {E_Minerals.Mithril, new ValueOfMithril() },
                {E_Minerals.Silver, new ValueOfSilver()}
            });

            return guild;
        }


    }
}
