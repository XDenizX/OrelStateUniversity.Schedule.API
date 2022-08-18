using System.Text.RegularExpressions;

namespace OrelStateUniversity.API.Helpers;

/// <summary>
/// Represents the helper class for interacting with the HTML code of the page.
/// </summary>
public class HtmlPageParser
{
    private readonly string _pageCode;

    /// <summary>
    /// Create an instance of the class with the specified page code <paramref name="pageCode"/>.
    /// </summary>
    /// <param name="pageCode">HTML code of page.</param>
    public HtmlPageParser(string pageCode)
    {
        _pageCode = pageCode;
    }

    /// <summary>
    /// Get the assigned value of a variable named <paramref name="variableName"/>
    /// in the page code.
    /// </summary>
    /// <param name="variableName">Name of the variable.</param>
    /// <returns>Value of the variable.</returns>
    public string GetVariableValue(string variableName)
    {
        var regex = new Regex($"{variableName}[\\s]*=[\\s]*toNumbers[\\s]*\\([\\s]*\"(?<value>\\w*)\"[\\s]*\\)");
        
        Match match = regex.Match(_pageCode);
        
        return match.Groups["value"].Value;
    }

    /// <summary>
    /// Check whether the page code is HTML code.
    /// </summary>
    /// <returns>Returns <see langword="true"/> when code is HTML code and 
    /// <see langword="false"/> otherwise.
    /// </returns>
    public bool IsHtmlPage()
    {
        return _pageCode.Contains("<html>");
    }
}
