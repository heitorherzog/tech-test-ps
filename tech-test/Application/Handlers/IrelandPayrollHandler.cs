namespace Application
{
   public class IrelandPayrollHandler : CountryPayRollHandler
    {
        public override IPayRollCountry SetCountryPayRoll(IUserInput user)
        {
            if (user.EmployeesLocation == Countries.ireland.ToString())
            {
                return new IrelandPayroll();
            }
            else
            {
                //chain to another country
                return null;
            }
        }
    }
}
