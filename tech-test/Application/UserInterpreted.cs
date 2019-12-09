namespace Application
{
    public class UserInterpreted
    {
        public bool isValid { get; }
        public int HoursWorked { get; }
        public int HoursRate { get; set; }

        public UserInterpreted(bool isValid, int hoursWorked, int hoursRate)
        {
            this.isValid = isValid;
            HoursWorked = hoursWorked;
            HoursRate = hoursRate;
        }
    }
}
