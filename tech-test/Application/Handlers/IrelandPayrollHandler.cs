namespace Application
{
   public class IrelandPayrollHandler : CountryPayRollHandler
    {
        public override IPayRollCountry PayRollCountry { get => _payRollCountry; }
        private IPayRollCountry _payRollCountry { get; set; }
        public override IPayRollCountry SetCountryPayRoll(UserInterpreted user)
        {
            if (user.EmployeesLocation == Countries.ireland.ToString())
            {
                _payRollCountry = new IrelandPayroll();
                return PayRollCountry;
            }
            else
            {
                //chain to another country
                return null;
            }
        }
    }
}
