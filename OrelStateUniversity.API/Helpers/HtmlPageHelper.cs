using System.Text.RegularExpressions;

namespace OrelStateUniversity.API.Helpers;

/// <summary>
/// Represents the static helper class for interacting with the HTML code of the page.
/// </summary>
public static class HtmlPageHelper
{
    public static string GetVariableValue(string pageContent, string variableName)
    {
        var regex = new Regex($"{variableName}[\\s]*=[\\s]*toNumbers[\\s]*\\([\\s]*\"(?<value>\\w*)\"[\\s]*\\)");
        
        Match match = regex.Match(pageContent);
        
        return match.Groups["value"].Value;
    }

    public static bool IsHtmlPage(string pageContent)
    {
        return pageContent.Contains("<html>");
    }
}
