using Xunit;
using FluentAssertions;
using TechTest;
using Application;

namespace XUnit_tech_test
{
    public class ConsoleContextTest
    {
        [Theory]
        [InlineData("IRELAND", "1", "1")]
        [InlineData("IRELAND", "1", "2")]
        [InlineData("germany", "10", "20")]
        [InlineData("irelandD", "1", "20")]
        public void Should_Init_Be_NotNull_Test(string employeelocation, string srthoursworked, string srthourlyrate)
        {
            // arrange
            var input = new UserInput()
            {
                EmployeesLocation = employeelocation,
                StrHoursRate = srthourlyrate,
                StrHoursWorked = srthoursworked
            };

            var consoleContext = new ConsoleContext(new ApplicationContext(), input);
            IUserInput result;

            // act
            consoleContext.Init();
            result = consoleContext.UserInput;

            // assert
            result.Should().NotBeNull();
        }
    }
}
