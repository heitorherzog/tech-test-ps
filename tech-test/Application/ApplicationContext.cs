using System;

namespace Application
{
    public class ApplicationContext
    {
        public CountryPayRollHandler PayRollState { get; }
        public HandleOutputDeductions Handle { get; }
        public UserInterpreted UserInterpreted { get => _userInterpreted; }
        private UserInterpreted _userInterpreted { get; set; }
        public ApplicationContext()
        {
            PayRollState = new IrelandPayrollHandler();
            Handle = new HandleOutputDeductions();
        }
        public UserInterpreted Interpret(IUserInput userInput)
        {
            string location = userInput.EmployeesLocation.ToLower();
            bool isvalidLocation = Enum.IsDefined(typeof(Countries), location);
            int.TryParse(userInput.StrHoursRate, out int hoursRate);
            int.TryParse(userInput.StrHoursWorked, out int hoursWorked);

            var isValid = (hoursRate != 0 && hoursWorked != 0 && isvalidLocation);

            _userInterpreted = new UserInterpreted(isValid, hoursWorked, hoursRate, location);

            return UserInterpreted;
        }
        public void Process(IUserInput userInput)
        {
            var UserInterpret = Interpret(userInput);
            var payrollrule = PayRollState.SetCountryPayRoll(UserInterpret);
            var result = payrollrule?.ComputeTaxes(UserInterpret);

            Handle.GetDeductions(result);
            Handle.FormatResult();
        }
    }
}
