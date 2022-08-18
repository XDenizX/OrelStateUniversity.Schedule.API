using System.Text.RegularExpressions;

namespace OrelStateUniversity.API.Helpers;

public class HtmlPageParser
{
    private readonly string _pageCode;

    public HtmlPageParser(string pageCode)
    {
        _pageCode = pageCode;
    }

    public string GetVariableValue(string variableName)
    {
        var regex = new Regex($"{variableName}[\\s]*=[\\s]*toNumbers[\\s]*\\([\\s]*\"(?<value>\\w*)\"[\\s]*\\)");
        
        Match match = regex.Match(_pageCode);
        
        return match.Groups["value"].Value;
    }
}
