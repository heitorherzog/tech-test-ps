using Application;

namespace TechTest
{
    public class UserInput : IUserInput
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
        public UserInput() { }
    }
}
