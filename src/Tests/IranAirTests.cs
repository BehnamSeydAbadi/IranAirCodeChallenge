using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using IranAirCodeChallenge.Exceptions;
using IranAirCodeChallenge.Strategies;
using IranAirCodeChallenge.Utils;
using Tests.FakeObjects;

namespace Tests;

public class IranAirTests
{
    [Theory(DisplayName =
        "There is a bank called A, When the company asks from bank A to get a loan, Then the company should get the loan in 10 installments with an interest rate of 20%")]
    [InlineData(100000000, 10916666)]
    [InlineData(500000000, 54583333)]
    public void LoanFromBankAShouldBePaidInTenInstallmentsWithAnInterestRateOf20Percents(
        decimal totalLoanAmount, long expectedInstallmentValue
    )
    {
        var loanFromBankAStrategy = new LoanFromBankAStrategy();

        var installmentValue = loanFromBankAStrategy.Handle(totalLoanAmount);

        installmentValue.Should().Be(expectedInstallmentValue);
    }

    [Theory(DisplayName =
        "There is a bank called B, When the company asks from bank B to get a loan, Then the company should get the loan in 8 installments with an interest rate of between -20% and 50%")]
    [InlineData(100000000, -20, 11562500)]
    [InlineData(300000000, 30, 41718750)]
    [InlineData(500000000, 50, 74218750)]
    public void
        LoanFromBankBShouldBePaidInEightInstallmentsWithAnInterestRateBetweenMinusTwentyPercentsAndFiftyPercents(
            decimal totalLoanAmount, int interestRate, long expectedInstallmentValue
        )
    {
        var loanFromBankBStrategy = new FakeLoanFromBankBStrategy();
        loanFromBankBStrategy.ReturnInterestRate(interestRate);

        var installmentValue = loanFromBankBStrategy.Handle(totalLoanAmount);

        installmentValue.Should().Be(expectedInstallmentValue);
    }

    [Theory(DisplayName =
        "There is a bank called B, When the company asks from bank B to get a loan lower than 100000000 or more than 500000000, Then an error should be thrown")]
    [InlineData(-100000000)]
    [InlineData(99999999)]
    [InlineData(500000001)]
    public void
        LoanInInvalidValueFromBankBAnErrorShouldBeThrown(
            decimal totalLoanAmount
        )
    {
        var loanFromBankBStrategy = new LoanFromBankBStrategy();

        var action = () => loanFromBankBStrategy.Handle(totalLoanAmount);

        action.Should().ThrowExactly<InvalidTotalLoanAmountException>();
    }
}