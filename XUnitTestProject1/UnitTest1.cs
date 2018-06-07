using System;
using Xunit;
using ATM_Machine;
using static ATM_Machine.Program;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void WillDeposit()
        {
            Assert.Equal(1200, Program.TransactionDeposit(200));
        }
        [Theory]
        [InlineData(7, 1007)]
        [InlineData(17, 1017)]
        [InlineData(107, 1107)]
        [InlineData(6, 1006)]
        [InlineData(10, 1010)]
        [InlineData(15, 
            1015)]
        public void NumberTest(int value, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.TransactionDeposit(value));
        }
    }
}
