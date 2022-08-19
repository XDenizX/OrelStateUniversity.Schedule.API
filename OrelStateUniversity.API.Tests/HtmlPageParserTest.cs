using OrelStateUniversity.API.Helpers;

namespace OrelStateUniversity.API.Tests;

internal class HtmlPageParserTest
{
    private string _content;

    [SetUp]
    public void Setup()
    {
        _content = "\t\tfunction toNumbers(d){var e=[];d.replace(/(..)" +
            "/g,function(d){e.push(parseInt(d,16))});return e}function toHex(){for(var d=[],d=1==" +
            "arguments.length&&arguments[0].constructor==Array?arguments[0]:arguments,e=\"\",f=0;" +
            "f<d.length;f++)e+=(16>d[f]?\"0\":\"\")+d[f].toString(16);return e.toLowerCase()}var " +
            "a=toNumbers(\"6d707d2540b4193976cbb5f2b8772adb\"),b=toNumbers(\"e7180e699b02bcafba97" +
            "e1c4c390e063\"),c=toNumbers(\"fad0b5fb452efac6040b3e64eba04d33\");document.cookie=\"" +
            "BPC=\"+toHex(slowAES.decrypt(c,2,a,b))+\"; expires=Thu, 31-Dec-37 23:55:55 GMT; path" +
            "=/\";document.location.href=\"https://foobar.com\";";
    }

    [Test]
    public void GetVariableValueATest()
    {
        string variableValue = HtmlPageHelper.GetVariableValue(_content, "a");
        string expectedValue = "6d707d2540b4193976cbb5f2b8772adb";

        Assert.That(variableValue, Is.EqualTo(expectedValue));
    }

    [Test]
    public void GetVariableValueBTest()
    {
        string variableValue = HtmlPageHelper.GetVariableValue(_content, "b");
        string expectedValue = "e7180e699b02bcafba97e1c4c390e063";

        Assert.That(variableValue, Is.EqualTo(expectedValue));
    }

    [Test]
    public void GetVariableValueCTest()
    {
        string variableValue = HtmlPageHelper.GetVariableValue(_content, "c");
        string expectedValue = "fad0b5fb452efac6040b3e64eba04d33";

        Assert.That(variableValue, Is.EqualTo(expectedValue));
    }

    [Test]
    public void IsHtmlPageTest()
    {
        string htmlPageCode = "<html>\r\n<head>\r\n\t<meta charset=\"utf-8\" />\r\n</head>\r\n" +
            "<body>\r\n    <h1>Test</h1>\r\n</body>\r\n</html>";

        Assert.That(HtmlPageHelper.IsHtmlPage(htmlPageCode), Is.True);
    }

    [Test]
    public void IsNotHtmlPageTest()
    {
        string htmlPageCode = "<script></script>";

        Assert.That(HtmlPageHelper.IsHtmlPage(htmlPageCode), Is.False);
    }
}
