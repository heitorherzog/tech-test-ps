namespace Application
{
    public class UserInterpreted
    {
        public bool isValid { get; }
        public int HoursWorked { get; }
        public int HoursRate { get; }
        public string EmployeesLocation { get; }

        public UserInterpreted(bool isValid, int hoursWorked, int hoursRate, string employeesLocation)
        {
            this.isValid = isValid;
            HoursWorked = hoursWorked;
            HoursRate = hoursRate;
            EmployeesLocation = employeesLocation;
        }
    }
}
