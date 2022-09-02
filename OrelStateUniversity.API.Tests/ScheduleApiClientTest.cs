namespace OrelStateUniversity.API.Tests;

internal class ScheduleApiClientTest
{
    private ScheduleApiClient _scheduleApiClient;

    [SetUp]
    public void Setup()
    {
        _scheduleApiClient = new ScheduleApiClient();
    }

    [Test]
    public void GetScheduleTest()
    {
        var divisions = _scheduleApiClient.GetStudentDivisionsAsync().Result;
        var courses = _scheduleApiClient.GetCoursesAsync(divisions.First().Id).Result;
        var groups = _scheduleApiClient.GetGroupsAsync(divisions.First().Id, courses.First().Number).Result;
        var schedule = _scheduleApiClient.GetScheduleAsync(groups.First().Id).Result;
    }
}
