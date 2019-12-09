namespace Application
{
    public class IrelandPayroll : IPayRollCountry
    {
        private decimal Incoming { get; set; }
        public Deductions ComputeTaxes(UserInterpreted userInterpreted)
        {
            var input = userInterpreted;
            Incoming = input.HoursRate * input.HoursWorked;

            var d = new Deductions()
            {

                Employeelocation = input.EmployeesLocation,
                GrossAmount = Incoming,
                IncomeTax = CalculateincomeTaxRate(),
                UniversalSocialCharge = CalculeteUniversalSocialCharge(),
                Pension = CompulsoryPension(),
                NetAmount = 0

            };

            d.NetAmount = d.GrossAmount - d.IncomeTax - d.UniversalSocialCharge - d.Pension;

            return d;
        }

        /// <summary>
        ///income tax at a rate of 25 % for the first €600 and 40 % thereafter
        /// </summary>
        /// <returns></returns>
        private decimal CalculateincomeTaxRate()
        {
            if (Incoming <= 600)
                return (Incoming * 0.25m);

            var IncomeTax = (600 * 0.25m);
            IncomeTax = ((Incoming - 600) * 0.40m) + IncomeTax;

            return IncomeTax;
        }
        /// <summary>
        ///Given the employee is located in Ireland, a Universal social charge of 7 % is applied for the first €500 euro and 8 % thereafter
        /// </summary>
        /// <returns></returns>
        private decimal CalculeteUniversalSocialCharge()
        {
            if (Incoming <= 500)
                return (Incoming * 0.07m);

            var IncomeTax = (500 * 0.07m);
            IncomeTax = ((Incoming - 500) * 0.08m) + IncomeTax;
            return IncomeTax;
        }
        /// <summary>
        ///Given the employee is located in Ireland, a compulsory pension contribution of 4 % is applied
        /// </summary>
        /// <returns></returns>
        private decimal CompulsoryPension()
        {
            return (Incoming * 0.04m);
        }
    }
}
