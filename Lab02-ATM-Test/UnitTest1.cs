using System;
using Lab02_ATM;
using Xunit;

namespace Lab02_ATM_Test
{
    public class UnitTest1
    {
        [Fact]
        public void CanViewBalance()
        {
            Assert.Equal(Program.AcctBalance, Program.ViewBalance());          
        }


        [Theory]
        [InlineData(10, 10, 0)]
        [InlineData(5, 10, -5)]
        [InlineData(10, 9, 1)]
        public void CanWithdraw(decimal AcctBalance, decimal WithdrawalAmount, decimal ExpectedNewBalance)
        {
            if (AcctBalance >= WithdrawalAmount)
            {
                decimal NewBalance = AcctBalance - WithdrawalAmount;
                Assert.Equal(ExpectedNewBalance, NewBalance);
            }
            else
            {
                Assert.True(AcctBalance < WithdrawalAmount);
            }
        }

        [Theory]
        [InlineData(10, 10, 20)]
        [InlineData(5, 10, 15)]
        [InlineData(10, 0, 10)]
        public void CanDeposit(decimal AcctBalance, decimal DepositAmount, decimal ExpectedNewBalance)
        {
                decimal NewBalance = AcctBalance + DepositAmount;
                Assert.Equal(ExpectedNewBalance, NewBalance);
        }
    }
}
