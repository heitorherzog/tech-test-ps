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
        [InlineData("irelanD", "1", "2")]
        public void Should_Process_Be_Valid_Ireland(string employeelocation, string srthoursworked, string srthourlyrate)
        {
            // arrange
            var input = new UserInput()
            {
                EmployeesLocation = employeelocation,
                StrHoursRate = srthourlyrate,
                StrHoursWorked = srthoursworked
            };

            var consoleContext = new ConsoleContext(new ApplicationContext(), input);
            string outPutResult;
            IUserInput userInputresult;
            UserInterpreted userInterpreted;
            CountryPayRollHandler payRollState;

            // act
            consoleContext.Init();
            userInputresult = consoleContext.UserInput;
            consoleContext.Process();
            userInterpreted = consoleContext.AppContext.UserInterpreted;
            payRollState = consoleContext.AppContext.PayRollState;
            outPutResult = consoleContext.OutPutResult();

            // assert
            consoleContext.AppContext.Should().NotBeNull();
            userInputresult.Should().NotBeNull();

            userInterpreted.isValid.Should().BeTrue();
            payRollState.Should().NotBeNull();
            payRollState.Should().BeOfType<IrelandPayrollHandler>();
            payRollState.PayRollCountry.Should().BeOfType<IrelandPayroll>();
            outPutResult.Should().NotBeNullOrWhiteSpace();
        }

        [Theory]
        [InlineData("IREAND", "x", "1")]
        [InlineData("irelanDdd", "1", "2")]
        public void Should_Process_Be_Invalid_Ireland(string employeelocation, string srthoursworked, string srthourlyrate)
        {
            // arrange
            var input = new UserInput()
            {
                EmployeesLocation = employeelocation,
                StrHoursRate = srthourlyrate,
                StrHoursWorked = srthoursworked
            };

            var consoleContext = new ConsoleContext(new ApplicationContext(), input);
            string outPutResult;
            IUserInput userInputresult;
            UserInterpreted userInterpreted;
            CountryPayRollHandler payRollState;

            // act
            consoleContext.Init();
            userInputresult = consoleContext.UserInput;
            consoleContext.Process();
            userInterpreted = consoleContext.AppContext.UserInterpreted;
            payRollState = consoleContext.AppContext.PayRollState;
            outPutResult = consoleContext.OutPutResult();

            // assert
            consoleContext.AppContext.Should().NotBeNull();
            userInputresult.Should().NotBeNull();

            userInterpreted.isValid.Should().BeFalse();
            payRollState.Should().NotBeNull();
            payRollState.Should().BeOfType<IrelandPayrollHandler>();
            payRollState.PayRollCountry.Should().BeNull();
            outPutResult.Should().NotBeNullOrWhiteSpace();
        }
    }
}
