namespace Application
{
    public class GermanyPayrollHandler : CountryPayRollHandler
    {
        public override IPayRollCountry PayRollCountry { get => _payRollCountry; }
        private IPayRollCountry _payRollCountry { get; set; }

        public override IPayRollCountry SetCountryPayRoll(UserInterpreted user)
        {
            if (user.EmployeesLocation == Countries.germany.ToString())
            {
                _payRollCountry = null;
                return _payRollCountry;
            }
            else
            {
                return null;
            }
        }
    }
}
