using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaPrograms
{
    public class MakeATeaTask
    {
        public string QualityTea(List<ListTeaClass> informatioAboutTea, int temperature, int boilingtime)
        {
            string Quality = "";

            if (int.Parse(informatioAboutTea[2].boilingTime) * 60 * 1.1 < boilingtime
                || int.Parse(informatioAboutTea[2].boilingTime) * 60 * 0.9 > boilingtime)
            {
                Quality = "Yucky";
            }
            else if (int.Parse(informatioAboutTea[2].boilingpoint) * 1.1 < temperature)
            {
                Quality = "Yucky";
            }
            else if (int.Parse(informatioAboutTea[2].boilingpoint) * 0.9 > temperature)
            {
                Quality = "Weak";
            }
            else
            {
                Quality = "Perfect";
            }
            return Quality;
        }
    }
}
