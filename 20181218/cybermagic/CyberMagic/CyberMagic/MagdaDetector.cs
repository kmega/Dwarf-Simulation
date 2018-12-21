using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace CyberMagic
{
    public class MagdaDetector
    {

        public  string magdaDetector(List<string> stories)
        {
            string txt = "Magda Patiril występowała w następujących Opowieściach:\n\n";
            foreach (var item in stories)
            {

                if (new TextParser().ExtractStuffWithMagda(item) == "")
                {
                    continue;
                }
                else
                {
                    txt += new TextParser().ExtrakctTitle(item) + "\n";
                }
            }
            return txt;
        }
    }
}
