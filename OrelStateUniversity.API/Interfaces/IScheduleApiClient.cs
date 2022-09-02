using OrelStateUniversity.API.Models;

namespace OrelStateUniversity.API.Interfaces;

/// <summary>
/// Represents a client for interaction with the API of the Orel State University.
/// </summary>
public interface IScheduleApiClient
{
    /// <summary>
    /// Get a list of available divisions for students.
    /// </summary>
    /// <returns>List of divisions.</returns>
    Task<IEnumerable<Division>> GetStudentDivisionsAsync();

    /// <summary>
    /// Get a list of available courses for the specified <paramref name="divisionId"/>.
    /// </summary>
    /// <param name="divisionId">Identifier of division</param>
    /// <returns>List of courses.</returns>
    Task<IEnumerable<Course>> GetCoursesAsync(int divisionId);

    /// <summary>
    /// Get a list of all groups for the specified <paramref name="divisionId"/>
    /// on the specified <paramref name="courseNumber"/>.
    /// </summary>
    /// <param name="divisionId">Identifier of division</param>
    /// <param name="courseNumber">Number of course</param>
    /// <returns>List of groups.</returns>
    Task<IEnumerable<Group>> GetGroupsAsync(int divisionId, int courseNumber);

    /// <summary>
    /// Get a schedule for the specified <paramref name="groupId"/>.
    /// </summary>
    /// <param name="groupId">Identifier of group</param>
    /// <returns>Model of schedule.</returns>
    Task<Schedule> GetScheduleAsync(int groupId);
}
