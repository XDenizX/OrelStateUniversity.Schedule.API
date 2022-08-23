using OrelStateUniversity.API.Models;

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
        var courses = _scheduleApiClient.GetCoursesAsync(divisions.First()).Result;
        var groups = _scheduleApiClient.GetGroupsAsync(divisions.First(), courses.First()).Result;
        var schedule = _scheduleApiClient.GetScheduleAsync(groups.First()).Result;
    }

    [Test]
    public void GetCoursesArgumentNullExceptionTest()
    {
        Assert.That(
            () => _scheduleApiClient.GetCoursesAsync(null),
            Throws.ArgumentNullException);

        Assert.That(
            () => _scheduleApiClient.GetCoursesAsync(new Division { Id = 1 }),
            Throws.Nothing);
    }

    [Test]
    public void GetGroupsArgumentNullExceptionTest()
    {
        Assert.That(
            () => _scheduleApiClient.GetGroupsAsync(null, new Course { Number = 1 }),
            Throws.ArgumentNullException);

        Assert.That(
            () => _scheduleApiClient.GetGroupsAsync(new Division { Id = 1 }, null),
            Throws.ArgumentNullException);

        Assert.That(
            () => _scheduleApiClient.GetGroupsAsync(null, null),
            Throws.ArgumentNullException);

        Assert.That(
            () => _scheduleApiClient.GetGroupsAsync(new Division { Id = 1 }, new Course { Number = 1 }),
            Throws.Nothing);
    }

    [Test]
    public void GetScheduleArgumentNullExceptionTest()
    {
        Assert.That(
            () => _scheduleApiClient.GetScheduleAsync(null),
            Throws.ArgumentNullException);
    }
}
