using System.Text.RegularExpressions;

namespace OrelStateUniversity.API.Helpers;

/// <summary>
/// Represents the static helper class for interacting with the HTML code of the page.
/// </summary>
public static class HtmlPageHelper
{
    private const string VariableRegularExpression = "(?<name>[\\w\\d]+)[\\s]*=[\\s]*toNumbers[\\s]*\\([\\s]*\"(?<value>\\w*)\"[\\s]*\\)";

    public static Dictionary<string, string> GetAllVariables(string pageContent)
    {
        var regex = new Regex(VariableRegularExpression);
        
        MatchCollection matches = regex.Matches(pageContent);

        IEnumerable<KeyValuePair<string, string>> variables = matches
            .Select(match => match.Groups)
            .Select(group => (Name: group["name"].Value, Value: group["value"].Value))
            .Select(x => new KeyValuePair<string, string>(x.Name, x.Value));

        return new Dictionary<string, string>(variables);
    }

    public static bool IsHtmlPage(string pageContent)
    {
        return pageContent.Contains("<html>");
    }
}
