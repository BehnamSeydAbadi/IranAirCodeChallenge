namespace IranAirCodeChallenge.Exceptions;

public class InvalidTotalLoanAmountException()
    : Exception(message: "Total loan amount for Bank B should be between 100 and 500 million tomans");