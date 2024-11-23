namespace IranAirCodeChallenge.Strategies;

public abstract class AbstractStrategy
{
    public virtual long Handle(decimal totalLoanAmount)
    {
        //Source: https://khanesarmaye.com/calculate-interest-on-bank-loans/
        //مبلغ کلی وام × نرخ سود × (تعداد اقساط + ۱) تقسیم بر ۲۴۰۰.

        const decimal defaultDivision = 2400m;
        var installmentsCount = GetInstallmentsCount();
        var interestRate = GetInterestRate();

        decimal interestValueInDecimal = totalLoanAmount * (installmentsCount + 1) * interestRate / defaultDivision;
        var interestValueInNaturalNumber = (long)Math.Floor(interestValueInDecimal);

        var installmentValueInDecimal = (totalLoanAmount + interestValueInNaturalNumber) / installmentsCount;
        return (long)Math.Floor(installmentValueInDecimal);
    }

    protected abstract int GetInstallmentsCount();
    protected abstract int GetInterestRate();
}