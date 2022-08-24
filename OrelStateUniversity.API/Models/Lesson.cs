using Newtonsoft.Json;

namespace OrelStateUniversity.API.Models;

/// <summary>
/// Represents a class for storing data about lessons.
/// </summary>
public class Lesson
{
    [JsonProperty("id_cell")]
    public int Id { get; set; }

    [JsonProperty("NumberLesson")]
    public int Number { get; set; }

    [JsonProperty("DateLesson")]
    public string Date { get; set; }

    [JsonProperty("Korpus")]
    public int BuildingNumber { get; set; }

    [JsonProperty("NumberRoom")]
    public string Classroom { get; set; }

    [JsonProperty("special")]
    public string Specialization { get; set; }

    [JsonProperty("employee_id")]
    public int EmployeeId { get; set; }

    [JsonProperty("Name")]
    public string EmployeeName { get; set; }

    [JsonProperty("Family")]
    public string EmployeeSurname { get; set; }

    [JsonProperty("SecondName")]
    public string EmployeePatronymic { get; set; }

    [JsonProperty("DayWeek")]
    public int DayOfWeek { get; set; }

    [JsonProperty("idGruop")]
    public int GroupId { get; set; }

    [JsonProperty("title")]
    public string GroupName { get; set; }

    [JsonProperty("NumberSubGruop")]
    public int SubgroupNumber { get; set; }

    [JsonProperty("TitleSubject")]
    public string SubjectTitle { get; set; }

    [JsonProperty("TypeLesson")]
    public string LessonType { get; set; }

    [JsonProperty("kurs")]
    public int CourseNumber { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }

    [JsonProperty("pass")]
    public string LinkPassword { get; set; }

    [JsonProperty("zoom_link")]
    public string ZoomLink { get; set; }

    [JsonProperty("zoom_password")]
    public string ZoomLinkPassword { get; set; }
}
