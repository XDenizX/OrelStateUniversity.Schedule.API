namespace OrelStateUniversity.API.Helpers;

public static class DateTimeHelper
{
    public static long ConvertToLong(DateTime dateTime)
    {
        return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
    }
}
