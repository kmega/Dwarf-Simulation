using BFC.Console.AppLogic;
using BFC.Console.Presentation;

namespace TheForest.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new WindowsConsole();
            var theForrest = new BlackForest(console);
        }
    }
}
