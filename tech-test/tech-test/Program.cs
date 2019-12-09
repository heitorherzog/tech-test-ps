using Application;
namespace TechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleContext = new ConsoleContext(new ApplicationContext());
            consoleContext.Init();
            consoleContext.Process();
            consoleContext.OutPutResult();
        }
    }
}
