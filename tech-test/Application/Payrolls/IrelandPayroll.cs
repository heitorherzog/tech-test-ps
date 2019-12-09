namespace Application
{
    public class IrelandPayroll : IPayRollCountry
    {
        public Deductions ComputeTaxes(UserInterpreted userInterpreted)
        {
            return new Deductions();
        }
    }
}
