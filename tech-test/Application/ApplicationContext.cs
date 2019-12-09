using System;
using System.Text;

namespace Application
{
    public class ApplicationContext
    {
        public StringBuilder ResultBuilder { get; set; }
        Deductions Deductions { get; set; }
        public ApplicationContext()
        {
            Deductions = new Deductions();
            ResultBuilder = new StringBuilder();
        }
        public UserInterpreted Interpret(IUserInput userInput)
        {
            string location = userInput.EmployeesLocation;
            bool isvalidLocation = Enum.IsDefined(typeof(Countries), location.ToLower());
            int.TryParse(userInput.StrHoursRate, out int hoursRate);
            int.TryParse(userInput.StrHoursWorked, out int hoursWorked);

            var isValid = (hoursRate != 0 && hoursWorked != 0 && isvalidLocation);

            return new UserInterpreted(isValid, hoursWorked, hoursRate);
        }
        public void Process(IUserInput userInput)
        {
            var UserInterpret = Interpret(userInput);

            if (UserInterpret.isValid)
            {

                ResultBuilder.AppendFormat("Employee location: {0}{1}", Deductions.Employeelocation, Environment.NewLine);
                ResultBuilder.AppendFormat("Gross Amount: {0:C}{1}", Deductions.GrossAmount, Environment.NewLine);
                ResultBuilder.AppendLine("Less deductions");
                ResultBuilder.AppendFormat("Income Tax: {0:C}{1}", Deductions.IncomeTax, Environment.NewLine);
                ResultBuilder.AppendFormat("Universal Social Charge: {0:C}{1}", Deductions.UniversalSocialCharge, Environment.NewLine);
                ResultBuilder.AppendFormat("Pension: {0:C}{1}", Deductions.Pension, Environment.NewLine);
                ResultBuilder.AppendFormat("Net Amount: {0:C}{1}", Deductions.NetAmount, Environment.NewLine);
            }
            else
            {
                Append("Please insert valid values");
            }
        }
        private void Append(string text)
        {
            ResultBuilder.Append(text);
        }
    }
}
