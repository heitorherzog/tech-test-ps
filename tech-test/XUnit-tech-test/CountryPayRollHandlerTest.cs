using Xunit;
using TechTest;
using FluentAssertions;
using Application;


namespace XUnit_tech_test
{
    public class CountryPayRollHandlerTest
    {
        [Theory]
        [InlineData("IRELAND", "1", "1")]
        [InlineData("ireland", "1", "2")]
        public void Should_IrelandPayrollHandler_Return_IrelandPayroll(string employeelocation, string srthoursworked, string srthourlyrate)
        {
            // arrange
            var app = new ApplicationContext();
            var handler = new IrelandPayrollHandler();
            IPayRollCountry payrollresult;

            var input = new UserInput()
            {
                EmployeesLocation = employeelocation,
                StrHoursRate = srthourlyrate,
                StrHoursWorked = srthoursworked
            };

            // act
            var userInterpreted = app.Interpret(input);
            payrollresult = handler.SetCountryPayRoll(userInterpreted);

            // assert
            payrollresult.Should().NotBeNull();
            payrollresult.Should().BeOfType<IrelandPayroll>();
            userInterpreted.EmployeesLocation.Should().ContainAll(Countries.ireland.ToString());
        }
    }
}
