using Newtonsoft.Json;
using OrelStateUniversity.API.Helpers;
using OrelStateUniversity.API.Interfaces;
using OrelStateUniversity.API.Models;
using System.Net;
using System.Security.Cryptography;

namespace OrelStateUniversity.API;

/// <summary>
/// Represents a class with the implementation of interaction with Orel State University API
/// with HttpClient.
/// </summary>
public class ScheduleApiClient : IScheduleApiClient
{
    private readonly HttpClientHandler _httpClientHandler = new();
    private readonly HttpClient _httpClient;

    public ScheduleApiClient()
    {
        var bpcCookie = new Cookie()
        {
            Value = string.Empty,
            Name = Constants.CookieName,
            Path = Constants.CookiePath,
            Domain = Constants.CookieDomain,
            Expires = Constants.CookieExpirationDate
        };

        _httpClientHandler.CookieContainer.Add(bpcCookie);
        _httpClient = new HttpClient(_httpClientHandler);
    }

    public async Task<IEnumerable<Division>> GetStudentDivisionsAsync()
    {
        return await RequestObject<IEnumerable<Division>>(Constants.DevisionListEndpoint);
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync(int divisionId)
    {
        string endpoint = string.Format(Constants.CourseListEndpoint, divisionId);

        return await RequestObject<IEnumerable<Course>>(endpoint);
    }

    public async Task<IEnumerable<Group>> GetGroupsAsync(int divisionId, int courseNumber)
    {
        string endpoint = string.Format(Constants.GroupListEndpoint, divisionId, courseNumber);

        return await RequestObject<IEnumerable<Group>>(endpoint);
    }

    public async Task<Schedule> GetScheduleAsync(int groupId, DateTime dateTime)
    {
        // Time offset for getting the schedule correctly.
        // The API does not return lessons for the current day.
        long milliseconds = DateTimeHelper.ConvertToLong(dateTime - TimeSpan.FromDays(1));

        string endpoint = string.Format(Constants.ScheduleEndpoint, groupId, milliseconds);

        return await RequestObject<Schedule>(endpoint);
    }

    public async Task<Schedule> GetScheduleAsync(int groupId)
    {
        return await GetScheduleAsync(groupId, DateTime.Now);
    }

    private async Task<T> RequestObject<T>(string endpoint)
    {
        string content = await RequestContent(endpoint);

        T? obj = JsonConvert.DeserializeObject<T>(content);
        if (obj == null)
        {
            throw new NullReferenceException("Failed to get an object at the specified endpoint.");
        }

        return obj;
    }

    private async Task<string> RequestContent(string endpoint)
    {
        string content = await GetContent(endpoint);
        
        if (!HtmlPageHelper.IsHtmlPage(content))
        {
            return content;
        }

        UpdateCookie(content);

        return await GetContent(endpoint);
    }

    private async Task<string> GetContent(string endpoint)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();

        string content = await response.Content.ReadAsStringAsync();

        return content;
    }

    private void UpdateCookie(string content)
    {
        Dictionary<string, string> variables = HtmlPageHelper.GetAllVariables(content);

        string key = variables["a"];
        string initialVector = variables["b"];
        string cipherText = variables["c"];
        byte[] cipherTextBytes = StringHelper.HexToBytes(cipherText);

        string bpcCookieValue = CryptographicHelper.Decrypt(
            cipherTextBytes,
            CipherMode.CBC,
            key,
            initialVector);

        CookieCollection cookies = _httpClientHandler.CookieContainer.GetAllCookies();
        Cookie bpcCookie = cookies[Constants.CookieName];
        if (bpcCookie == null)
        {
            throw new NullReferenceException("BPC cookie is not contained in the collection.");
        }

        bpcCookie.Value = bpcCookieValue;
    }
}