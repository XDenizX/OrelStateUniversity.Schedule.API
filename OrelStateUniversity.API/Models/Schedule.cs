using Newtonsoft.Json;
using OrelStateUniversity.API.Converters;

namespace OrelStateUniversity.API.Models;

/// <summary>
/// Represents a class for storing schedule information.
/// </summary>
[JsonConverter(typeof(ScheduleJsonConverter))]
public class Schedule
{
    public List<Lesson> Lessons { get; set; } = new();
}
