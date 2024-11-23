namespace IranAirCodeChallenge.Strategies;

public class LoanFromBankAStrategy
{
    public long Handle(decimal totalLoanAmount)
    {
        //Source: https://khanesarmaye.com/calculate-interest-on-bank-loans/
        //مبلغ کلی وام × نرخ سود × (تعداد اقساط + ۱) تقسیم بر ۲۴۰۰.

        const int totalInstallments = 10;
        const decimal defaultDivision = 2400m;

        decimal interestValueInDecimal = totalLoanAmount * (totalInstallments + 1) * 20 / defaultDivision;
        var interestValueInNaturalNumber = (long)Math.Floor(interestValueInDecimal);

        var installmentValueInDecimal = (totalLoanAmount + interestValueInNaturalNumber) / totalInstallments;
        return (long)Math.Floor(installmentValueInDecimal);
    }
}