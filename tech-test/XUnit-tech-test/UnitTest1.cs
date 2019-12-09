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
        [InlineData("irelandD", "1", "20")]
        public void ShouldProcessBe_ValidTest(string employeelocation, string srthoursworked, string srthourlyrate)
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

        [Theory]
        [InlineData("IRELAND", "1", "1")]
        [InlineData("IRELAND", "1", "2")]
        [InlineData("germany", "10", "20")]
        [InlineData("italy", "10", "20")]
        public void ShoulInterpretBe_ValidTest(string employeelocation, string srthoursworked, string srthourlyrate)
        {
            // arrange
            var consoleContext = new ConsoleContext();
            var result = false;

            // act
            consoleContext.Init(new UserInput(srthoursworked, srthourlyrate, employeelocation));
            result = consoleContext.Interpret();

            // assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("eua", "", "1")]
        [InlineData("IRELAAND", "1", "2")]
        [InlineData("geramany", "10", "20")]
        [InlineData("Brazil", "10", "20")]
        [InlineData("itaaly", "10", "20")]
        [InlineData("italy", "x", "20")]
        public void ShoulInterpretBe_IvalidTest(string employeelocation, string srthoursworked, string srthourlyrate)
        {
            // arrange
            var consoleContext = new ConsoleContext();
            var result = false;

            // act
            consoleContext.Init(new UserInput(srthoursworked, srthourlyrate, employeelocation));
            result = consoleContext.Interpret();

            // assert
            result.Should().BeFalse();
        }

    }
}
