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

        public ConsoleContext()
        {
            Builder = new StringBuilder();
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
        public void Process()
        {

            int.TryParse(UserInput.StrHoursWorked, out int hoursworked);
            int.TryParse(UserInput.StrHoursRate, out int hoursRate);

            if (UserInput.EmployeesLocation.ToLower() == "ireland")
            {
                var d = new Deductions()
                {
                    Employeelocation = UserInput.StrHoursWorked,
                    GrossAmount = hoursworked * hoursRate,
                    IncomeTax = 0,
                    UniversalSocialCharge = 0,
                    Pension = 0,
                    NetAmount = 0
                };


                Builder.AppendFormat("Employee location: {0}{1}", d.Employeelocation, Environment.NewLine);
                Builder.AppendFormat("Gross Amount: {0:C}{1}", d.GrossAmount, Environment.NewLine);
                Builder.AppendLine("Less deductions");
                Builder.AppendFormat("Income Tax: {0:C}{1}", d.IncomeTax, Environment.NewLine);
                Builder.AppendFormat("Universal Social Charge: {0:C}{1}", d.UniversalSocialCharge, Environment.NewLine);
                Builder.AppendFormat("Pension: {0:C}{1}", d.Pension, Environment.NewLine);
                Builder.AppendFormat("Net Amount: {0:C}{1}", d.NetAmount, Environment.NewLine);
            }
            else
            {
                WriteText("not implemented");
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
