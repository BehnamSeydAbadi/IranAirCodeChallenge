using IranAirCodeChallenge.Strategies;

namespace Tests.FakeObjects;

public class FakeLoanFromBankBStrategy : LoanFromBankBStrategy
{
    private int _interestRate;

    public void ReturnInterestRate(int interestRate)
    {
        _interestRate = interestRate;
    }

    protected override int GetInterestRate() => _interestRate;
}