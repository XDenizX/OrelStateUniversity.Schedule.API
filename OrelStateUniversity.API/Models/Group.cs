using Newtonsoft.Json;

namespace OrelStateUniversity.API.Models;

/// <summary>
/// Represents a class for storing group information.
/// </summary>
public class Group
{
    [JsonProperty("idgruop")]
    public int Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("Codedirection")]
    public string DirectionCode { get; set; }

    [JsonProperty("levelEducation")]
    public string EducationLevel { get; set; }
}
