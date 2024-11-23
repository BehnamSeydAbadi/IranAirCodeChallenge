namespace IranAirCodeChallenge.Strategies;

public class LoanFromBankBStrategy : AbstractStrategy
{
    protected override int GetInstallmentsCount() => 8;

    protected override int GetInterestRate()
    {
        return new Random().Next(minValue: -20, maxValue: 50);
    }
}