namespace IranAirCodeChallenge.Strategies;

public class LoanFromBankAStrategy : AbstractStrategy
{
    protected override int GetInstallmentsCount() => 10;

    protected override int GetInterestRate() => 20;
}