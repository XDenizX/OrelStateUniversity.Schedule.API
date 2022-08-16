using OrelStateUniversity.API.Interfaces;
using OrelStateUniversity.API.Models;

namespace OrelStateUniversity.API;

/// <summary>
/// Represents a class with the implementation of interaction with Orel State University API
/// with HttpClient.
/// </summary>
public class ScheduleApiClient : IScheduleApiClient
{
    public async Task<IEnumerable<Division>> GetDivisionsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync(Division devision)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Group>> GetGroupsAsync(Division devision, Course course)
    {
        throw new NotImplementedException();
    }

    public async Task<Schedule> GetScheduleAsync(Group group)
    {
        throw new NotImplementedException();
    }
}