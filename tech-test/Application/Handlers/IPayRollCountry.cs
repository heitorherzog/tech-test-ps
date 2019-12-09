namespace Application
{
    public interface IPayRollCountry
    {
        Deductions ComputeTaxes(UserInterpreted userInterpreted);
    }
}
