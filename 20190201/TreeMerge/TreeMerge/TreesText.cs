using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMerge
{
    class TreesText
    {
        public string[] Tree1 = new string[]
            {
                "1.Świat",
"    1.Primus",
"        1.Astoria",
"            1.Szczeliniec",
"                1.Powiat Pustogorski",
"                    1.Pustogor",
"                        1.Gabinet Pięknotki",
"                    1.Zaczęstwo",
"                        1.Cyberszkoła",
"                        1.Osiedle Ptasie",
"                    1.Trzęsawisko Zjawosztup",
"                        1.Głodna Ziemia"
            };

        public string[] Tree2 = new string[]
        {
            "1.Świat",
"    1.Primus",
"        1.Astoria, Asteroidy"
        };

        public string[] Tree3 = new string[]
        {
            "1.Świat",
"    1.Primus",
"        1.Astoria",
"            1.Szczeliniec",
"               1.Powiat Pustogorski",
"                    1.Zaczęstwo",
"                        1.Kasyno Marzeń",
"                        1.Szkoła Magów"
        };

        public string[] Tree4 = new string[]
        {
            "1.Świat",
"    1.Esuriit",
"        1.Astoria",
"            1.Szczeliniec"
        };


    }
}
