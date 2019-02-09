using System;
using DwarfLife.Enums;

namespace DwarfLife.Diaries
{
    public class DiaryHelper
    {
        private static Diary diary = null;
        public static void Log(DiaryTarget target, string message)
        {
            switch (target)
            {
                case DiaryTarget.Console:
                    diary = new ConsoleLogger();
                    diary.Log(message);
                    break;
                case DiaryTarget.File:
                    diary = new FileLogger();
                    diary.Log(message);
                    break;
                default:
                    return;
            }
        }
    }
}
