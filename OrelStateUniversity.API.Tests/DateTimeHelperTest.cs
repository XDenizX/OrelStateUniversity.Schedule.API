using OrelStateUniversity.API.Helpers;

namespace OrelStateUniversity.API.Tests;

internal class DateTimeHelperTest
{
    [Test]
    public void ConvertZeroToLongTest()
    {
        var ms = DateTimeHelper.ConvertToLong(DateTime.UnixEpoch);

        Assert.That(ms, Is.EqualTo(0));
    }

    [Test]
    public void ConvertOneDayToLongTest()
    {
        var ms = DateTimeHelper.ConvertToLong(DateTime.UnixEpoch + TimeSpan.FromDays(1));

        Assert.That(ms, Is.EqualTo(86400000));
    }
}
