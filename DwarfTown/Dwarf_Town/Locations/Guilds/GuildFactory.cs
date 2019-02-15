using Dwarf_Town.Enums;
using Dwarf_Town.Locations.Guild.OreValue;
using System.Collections.Generic;

namespace Dwarf_Town.Locations.Guild
{
    public static class GuildFactory
    {
        public static Guild CreateStandardGuild()
        {
            Guild guild = new Guild(new Dictionary<MineralType, IOreValue>
                {
                {MineralType.DirtyGold, new DirtGoldValue()},
                 {MineralType.Gold, new GoldValue()},
                 {MineralType.Silver, new SilverValue()},
                 {MineralType.Mithril, new MithrilValue()}
                }
            );
            return guild;
        }
    }
}