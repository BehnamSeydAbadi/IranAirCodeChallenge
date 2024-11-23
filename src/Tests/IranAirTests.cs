using FluentAssertions;
using IranAirCodeChallenge.Strategies;

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
}