using System;
using System.Collections.Generic;
using ThorinsCompany;

namespace DwarfMineSimulator
{
    public class RandomizerThorins : IRamdomizerThorins
    {
        Random rnd = new Random();

        public int ReturnRandomNumber(int first, int last)
        {
            int random = rnd.Next(first, last + 1);
            return random;
        }

        public DwarfType GenerateDwarfType(int chanceToFatherOrSingle)
        {
            if (chanceToFatherOrSingle <= 33)
            {
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.FatherBorn);
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.TotalBorn);
                return DwarfType.Father;                
            }
            else if (chanceToFatherOrSingle > 33 && chanceToFatherOrSingle <= 66)
            {
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.SingleBorn);
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.TotalBorn);
                return DwarfType.Single;
            }
            else if (chanceToFatherOrSingle > 66 && chanceToFatherOrSingle <= 99)
            {
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.LazyBorn);
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.TotalBorn);
                return DwarfType.Lazy;
            }
            else
            {
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.SuiciderBorn);
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.TotalBorn);
                return DwarfType.Bomber;
            }
        }

        public bool WillHeBeBorn(int chanceToFatherOrSingle)
        {
            if (chanceToFatherOrSingle == 1)
                return true;
            else
                return false;
        }

        public int ReturnPriceMaterials(Material material)
        {
            int random = 0;
            switch (material)
            {
                case Material.Mithril:
                    random = rnd.Next(15, 25 + 1);
                    break;
                case Material.Silver:
                    random = rnd.Next(5, 15 + 1);
                    break;
                case Material.Gold:
                    random = rnd.Next(10, 20 + 1);
                    break;
                case Material.DirtyGold:
                    random = rnd.Next(1, 5 + 1);
                    break;
            }
            return random;
        }

        public Material WhatDidYouDigOut(int chanceMaterialUseReturnRandomNumberHere)
        {
            Material material = Material.Gold;
            if (chanceMaterialUseReturnRandomNumberHere >= 0
                && chanceMaterialUseReturnRandomNumberHere <= 5)
            {
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.MithrilMinded);
                material = Material.Mithril;
            }
            else if (chanceMaterialUseReturnRandomNumberHere >= 6
                && chanceMaterialUseReturnRandomNumberHere <= 20)
            {
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.GoldMinded);
                material = Material.Gold;
            }
            else if (chanceMaterialUseReturnRandomNumberHere >= 21
                && chanceMaterialUseReturnRandomNumberHere <= 55)
            {
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.SilverMinded);
                material = Material.Silver;
            }
            else if (chanceMaterialUseReturnRandomNumberHere >= 56
                && chanceMaterialUseReturnRandomNumberHere <= 100)
            {
                Logger.GetInstance().AddLogToFinalAndDailyReport(1, InformationInRaport.TaintedGoldMinded);
                material = Material.DirtyGold;
            }

            return material;
        }
    }
}
