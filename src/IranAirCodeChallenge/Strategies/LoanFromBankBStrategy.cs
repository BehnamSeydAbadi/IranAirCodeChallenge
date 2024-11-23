namespace IranAirCodeChallenge.Strategies;

public class LoanFromBankBStrategy : AbstractStrategy
{
    protected override int GetInstallmentsCount() => 8;

    protected override int GetInterestRate() => new Random().Next(minValue: -20, maxValue: 50);

    protected override bool ValidateTotalLoadAmount(decimal totalLoanAmount)
    {
        return base.ValidateTotalLoadAmount(totalLoanAmount)
               && 100000000 <= totalLoanAmount && totalLoanAmount <= 500000000;
    }
}