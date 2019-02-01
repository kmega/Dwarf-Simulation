using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TreeMergingTests
{
    internal class FakeTreeData
    {
        internal List<string> GetSimpleTree()
        {
            return new List<string>(){
                "1. Świat",
                "    1.Primus",
                "        1.Astoria, Asteroidy"
        };

        }
        internal List<string> GetComplexTree()
        {
            return new List<string>(){
                "1. Świat",
                "    1. Primus",
                "        1. Astoria",
                "            1. Szczeliniec",
                "                1. Powiat Pustogorski",
                "                    1. Pustogor",
                "                        1. Gabinet Pięknotki",
                "                    1. Zaczęstwo",
                "                        1. Cyberszkoła",
                "                        1. Osiedle Ptasie",
                "                    1. Trzęsawisko Zjawosztup",
                "                        1. Głodna Ziemia"
        };
          
        }
        internal List<string> GetThirdTree()
        {
            return new List<string>()
            {
                "1. Świat",
                "    1. Esuriit",
                "        1. Astoria",
                "            1. Szczeliniec"
            };
        }
        internal List<string> GetFourthTree()
        {
            return new List<string>()
            {
                "1. Świat",
                "    1. Primus",
                "        1. Astoria",
                "            1. Szczeliniec",
                "                1. Powiat Pustogorski",
                "                    1. Zaczęstwo",
                "                        1. Kasyno Marzeń",
                "                        1. Szkoła Magów"
            };
        }
    }
}
