namespace BFC.Console.Presentation
{
    public class WindowsConsole : IOutputWritter
    {
        private IOutputWritter _writter;
        public void WriteLine(string information)
        {
            System.Console.WriteLine(information);
        }
        public WindowsConsole()
        {

        }
        public WindowsConsole(IOutputWritter writter)
        {
            _writter = writter;
        }
    }
    
}
