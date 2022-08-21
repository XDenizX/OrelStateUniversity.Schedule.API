using Newtonsoft.Json;

namespace OrelStateUniversity.API.Models;

/// <summary>
/// Represents a class for storing course information.
/// </summary>
public class Course
{
    [JsonProperty("kurs")]
    public int Number { get; set; }
}
