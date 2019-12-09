using Xunit;
using FluentAssertions;
using TechTest;
using Application;

namespace XUnit_tech_test
{
  public  class IrelandPayrollTest
    {
        [Theory]
        [InlineData("ireland", "40", "10")]
        public void Should_Deductions_Match_CalculationsTest(string employeelocation, string srthoursworked, string srthourlyrate)
        {
            // arrange
            var input = new UserInput()
            {
                EmployeesLocation = employeelocation,
                StrHoursRate = srthourlyrate,
                StrHoursWorked = srthoursworked
            };

            var payroll = new IrelandPayroll();
            Deductions result;
            var app = new ApplicationContext();
            UserInterpreted ui;
            decimal incomingTax;
            decimal universalSocialCharge;
            decimal compulsoryPension;

            // act
            ui = app.Interpret(input);
            result = payroll.ComputeTaxes(ui);

            incomingTax = CalculateincomeTaxRate(result.GrossAmount);
            universalSocialCharge = CalculeteUniversalSocialCharge(result.GrossAmount);
            compulsoryPension = CompulsoryPension(result.GrossAmount);

            // assert 
            result.GrossAmount.Should().BeApproximately(ui.HoursRate * ui.HoursWorked,4);
            result.IncomeTax.Should().BeApproximately(incomingTax,4);
            result.UniversalSocialCharge.Should().BeApproximately(universalSocialCharge,4);
            result.Pension.Should().BeApproximately(compulsoryPension, 4);

        }

        private decimal CalculateincomeTaxRate(decimal Incoming)
        {
            if (Incoming <= 600)
                return (Incoming * 0.25m);

            var IncomeTax = (600 * 0.25m);
            IncomeTax = ((Incoming - 600) * 0.40m) + IncomeTax;

            return IncomeTax;
        }
        private decimal CalculeteUniversalSocialCharge(decimal Incoming)
        {
            if (Incoming <= 500)
                return (Incoming * 0.07m);

            var IncomeTax = (500 * 0.07m);
            IncomeTax = ((Incoming - 500) * 0.08m) + IncomeTax;
            return IncomeTax;
        }
        private decimal CompulsoryPension(decimal Incoming)
        {
            return (Incoming * 0.04m);
        }
    }
}
