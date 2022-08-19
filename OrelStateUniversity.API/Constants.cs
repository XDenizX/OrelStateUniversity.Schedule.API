namespace OrelStateUniversity.API;

public class Constants
{
    public const string CookieName = "BPC";
    public const string CookiePath = "/";
    public const string CookieDomain = "oreluniver.ru";

    public static readonly DateTime CookieExpirationDate = new DateTime(2037, 12, 31, 23, 55, 55);
    
    public const string StudentsScheduleEndpoint = "https://oreluniver.ru/schedule/divisionlistforstuds";
}
