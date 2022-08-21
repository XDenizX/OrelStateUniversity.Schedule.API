using Newtonsoft.Json;

namespace OrelStateUniversity.API.Models;

/// <summary>
/// Represents a class for storing division information.
/// </summary>
public class Division
{
    [JsonProperty("idDivision")]
    public int Id { get; set; }

    [JsonProperty("titleDivision")]
    public string Title { get; set; }

    [JsonProperty("shortTitle")]
    public string ShortTitle { get; set; }
}