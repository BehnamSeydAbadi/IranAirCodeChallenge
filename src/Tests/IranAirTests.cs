using FluentAssertions;

namespace Tests;

public class IranAirTests
{
    [Theory(DisplayName =
        "There is a bank called A, When the company asks from bank A to get a loan, Then the company should get the loan in 10 installments with an interest rate of 20%")]
    [InlineData(100000000, 10916666)]
    [InlineData(500000000, 54583333)]
    public void LoanFromBankAShouldBePaidInTenInstallmentsWithAnInterestRateOf20Percents(
        decimal totalLoanAmount, long installmentValue
    )
    {
        //Source: https://khanesarmaye.com/calculate-interest-on-bank-loans/
        //مبلغ کلی وام × نرخ سود × (تعداد اقساط + ۱) تقسیم بر ۲۴۰۰.

        const int totalInstallments = 10;
        const decimal defaultDivision = 2400m;

        decimal interestValueInDecimal = totalLoanAmount * (totalInstallments + 1) * 20 / defaultDivision;
        var interestValueInNaturalNumber = (long)Math.Floor(interestValueInDecimal);

        var installmentValueInDecimal = (totalLoanAmount + interestValueInNaturalNumber) / totalInstallments;
        var installmentValueInNaturalNumber = (long)Math.Floor(installmentValueInDecimal);

        installmentValueInNaturalNumber.Should().Be(installmentValue);
    }
}