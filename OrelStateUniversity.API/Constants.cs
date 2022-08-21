namespace OrelStateUniversity.API;

public class Constants
{
    public const string CookieName = "BPC";
    public const string CookiePath = "/";
    public const string CookieDomain = "oreluniver.ru";

    public static readonly DateTime CookieExpirationDate = new DateTime(2037, 12, 31, 23, 55, 55);
    
    public const string DevisionListEndpoint = "https://oreluniver.ru/schedule/divisionlistforstuds";
    public const string CourseListEndpoint = "https://oreluniver.ru/schedule/{0}/kurslist";
    public const string GroupListEndpoint = "https://oreluniver.ru/schedule/{0}/{1}/grouplist";
    public const string ScheduleEndpoint = "https://oreluniver.ru/schedule//{0}///{1}/printschedule";
}
