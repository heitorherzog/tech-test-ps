namespace Application
{
    public abstract class CountryPayRollHandler
    {
        public abstract IPayRollCountry PayRollCountry { get; }
        public abstract IPayRollCountry SetCountryPayRoll(UserInterpreted user);
    }
}
