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
    /// Get a list of available courses for the specified <paramref name="division"/>.
    /// </summary>
    /// <param name="division"></param>
    /// <returns>List of courses.</returns>
    Task<IEnumerable<Course>> GetCoursesAsync(Division division);

    /// <summary>
    /// Get a list of all groups for the specified <paramref name="division"/>
    /// on the specified <paramref name="course"/>.
    /// </summary>
    /// <param name="division"></param>
    /// <param name="course"></param>
    /// <returns>List of groups.</returns>
    Task<IEnumerable<Group>> GetGroupsAsync(Division division, Course course);

    /// <summary>
    /// Get a schedule for the specified <paramref name="group"/>.
    /// </summary>
    /// <param name="group"></param>
    /// <returns>Model of schedule.</returns>
    Task<Schedule> GetScheduleAsync(Group group);
}
