namespace Application
{
    public class GermanyPayrollHandler : CountryPayRollHandler
    {
        public override IPayRollCountry SetCountryPayRoll(IUserInput user)
        {
            if (user.EmployeesLocation == Countries.germany.ToString())
            {
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
