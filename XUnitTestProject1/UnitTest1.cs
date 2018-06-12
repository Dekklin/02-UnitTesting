using System;
using Xunit;
using ATM_Machine;
using static ATM_Machine.Program;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CanDeposit()
        {
            Assert.Equal(1200, Program.TransactionDeposit(1000, 200));
        }
        [Theory]
        [InlineData(1000, 7, 1007)]
        [InlineData(300, 57, 357)]
        [InlineData(200, 13, 213)]
        public void DepositTest(int total, int depo, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.TransactionDeposit(total, depo));
        }
        [Theory]
        [InlineData(1000, 500, 500)]
        [InlineData(800, 50, 750)]
        [InlineData(50, 100, 50)]
        public void CanWithdrawl(int total, int withdrawl, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.TransactionWithdrawl(total, withdrawl));

        }

    }
}
