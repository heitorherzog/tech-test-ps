using System;
using System.Text;

namespace tech_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleContext = new ConsoleContext();
            consoleContext.Init();
            consoleContext.Process();
        }
    }

    public class UserInput
    {
        public string StrHoursWorked { get; set; }
        public string StrHoursRate { get; set; }
        public string EmployeesLocation { get; set; }
        public UserInput(string strHoursWorked, string strHoursRate, string employeesLocation)
        {
            StrHoursWorked = strHoursWorked;
            StrHoursRate = strHoursRate;
            EmployeesLocation = employeesLocation;
        }
        public UserInput()
        {

        }
    }
    public class ConsoleContext
    {
        UserInput UserInput { get; set; }
        StringBuilder Builder { get; set; }
        Deductions Deductions { get; set; }

        public ConsoleContext()
        {
            Builder = new StringBuilder();
            Deductions = new Deductions();
        }
        public void Init(UserInput userInput)
        {
            UserInput = userInput;
        }
        public void Init()
        {
            UserInput = new UserInput();
            Console.WriteLine("Please enter the hours worked:");
            UserInput.StrHoursWorked = Console.ReadLine();
            Console.WriteLine("Please enter the hourly rate: ");
            UserInput.StrHoursRate = Console.ReadLine();
            Console.WriteLine("Please enter the employee’s location: ");
            UserInput.EmployeesLocation = Console.ReadLine();
        }

        public bool Interpret()
        {
            string location = UserInput.EmployeesLocation;
            bool isvalidLocation = Enum.IsDefined(typeof(Countries), location.ToLower());
            int.TryParse(UserInput.StrHoursRate, out int hoursRate);
            int.TryParse(UserInput.StrHoursWorked, out int hoursWorked);

            Deductions.GrossAmount = hoursWorked * hoursRate;

            return (hoursRate != 0 && hoursWorked != 0 && isvalidLocation);
        }

        public enum Countries
        {
            ireland,
            italy,
            germany
        }

        public void Process()
        {
            var valid = Interpret();
            if (valid)
            {

                Builder.AppendFormat("Employee location: {0}{1}", Deductions.Employeelocation, Environment.NewLine);
                Builder.AppendFormat("Gross Amount: {0:C}{1}", Deductions.GrossAmount, Environment.NewLine);
                Builder.AppendLine("Less deductions");
                Builder.AppendFormat("Income Tax: {0:C}{1}", Deductions.IncomeTax, Environment.NewLine);
                Builder.AppendFormat("Universal Social Charge: {0:C}{1}", Deductions.UniversalSocialCharge, Environment.NewLine);
                Builder.AppendFormat("Pension: {0:C}{1}", Deductions.Pension, Environment.NewLine);
                Builder.AppendFormat("Net Amount: {0:C}{1}", Deductions.NetAmount, Environment.NewLine);
            }
            else
            {
                WriteText("Please insert valid values");
            }
        }

        public string OutPutResult()
        {
            string result = Builder.ToString();
            Console.WriteLine(result);
            return result;
        }

        private string WriteText(string text)
        {
            Builder.Append(text);
            return Builder.ToString();
        }
    }
    class Deductions
    {
        public string Employeelocation { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal UniversalSocialCharge { get; set; }
        public decimal Pension { get; set; }
        public decimal NetAmount { get; set; }
    }
}
