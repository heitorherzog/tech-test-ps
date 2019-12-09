using System;

namespace Application
{
    public class ApplicationContext
    {
        CountryPayRollHandler PayRollState { get; }
        public HandleOutputDeductions Handle { get; }
        public ApplicationContext()
        {
            PayRollState = new IrelandPayrollHandler();
            Handle = new HandleOutputDeductions();
        }
        public UserInterpreted Interpret(IUserInput userInput)
        {
            string location = userInput.EmployeesLocation;
            bool isvalidLocation = Enum.IsDefined(typeof(Countries), location.ToLower());
            int.TryParse(userInput.StrHoursRate, out int hoursRate);
            int.TryParse(userInput.StrHoursWorked, out int hoursWorked);

            var isValid = (hoursRate != 0 && hoursWorked != 0 && isvalidLocation);

            return new UserInterpreted(isValid, hoursWorked, hoursRate, location);
        }
        public void Process(IUserInput userInput)
        {
            var UserInterpret = Interpret(userInput);
            var payrollrule = PayRollState.SetCountryPayRoll(userInput);
            var result = payrollrule?.ComputeTaxes(UserInterpret);

            Handle.GetDeductions(result);
            Handle.FormatResult();
        }
    }
}
