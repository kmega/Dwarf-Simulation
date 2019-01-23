namespace BFC.Console.Presentation
{
    public class WindowsConsole : IOutputWritter
    {
        public void WriteLine(string information)
        {
            System.Console.WriteLine(information);
        }
    }
}
