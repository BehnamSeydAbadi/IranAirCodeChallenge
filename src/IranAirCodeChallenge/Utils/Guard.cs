namespace IranAirCodeChallenge.Utils;

public class Guard
{
    public static void Assert<TException>(bool isValid) where TException : Exception, new()
    {
        if (!isValid) throw new TException();
    }
}