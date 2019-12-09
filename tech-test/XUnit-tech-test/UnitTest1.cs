using System;
using tech_test;
using Xunit;
using FluentAssertions;

namespace XUnit_tech_test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("IRELAND", "1", "1")]
        [InlineData("IRELAND", "1", "2")]
        [InlineData("germany", "10", "20")]
        public void ShouldProcessBeValidTest(string employeelocation, string srthoursworked, string srthourlyrate)
        {
            // arrange
            var consoleContext = new ConsoleContext();
            var result = string.Empty;

            // act
            consoleContext.Init(new UserInput(srthoursworked, srthourlyrate, employeelocation));
            consoleContext.Process();
            result = consoleContext.OutPutResult();

            // assert
            result.Should().NotBeNullOrWhiteSpace();
        }
    }
}
