using System;
using Xunit;

namespace XUnit_tech_test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var consoleContext = new ConsoleContext();
            consoleContext.Test();
        }
    }
}
