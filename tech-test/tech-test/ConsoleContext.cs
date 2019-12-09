using Application;
using System;
namespace TechTest
{
    public class ConsoleContext
    {
        public UserInput UserInput { get; set; }
        public ApplicationContext AppContext { get; }

        public ConsoleContext(ApplicationContext appContext, UserInput userInput = null)
        {
            UserInput = userInput;
            AppContext = appContext;
        }
        public void Init()
        {
            if (UserInput == null)
            {
                UserInput = new UserInput();
                Console.WriteLine("Please enter the hours worked:");
                UserInput.StrHoursWorked = Console.ReadLine();
                Console.WriteLine("Please enter the hourly rate: ");
                UserInput.StrHoursRate = Console.ReadLine();
                Console.WriteLine("Please enter the employee’s location: ");
                UserInput.EmployeesLocation = Console.ReadLine();
            }
        }
        public void Process()
        {
            AppContext.Process(UserInput);
        }

        public string OutPutResult()
        {
            string result = AppContext.Handle.ResultBuilder.ToString();
            Console.WriteLine(result);
            return result;
        }
    }
}