using OrelStateUniversity.API.Helpers;
using System.Security.Cryptography;

namespace OrelStateUniversity.API.Tests;

internal class HtmlPageParserTest
{
    private HtmlPageParser _htmlPageParser;

    [SetUp]
    public void Setup()
    {
        _htmlPageParser = new HtmlPageParser("\t\tfunction toNumbers(d){var e=[];d.replace(/(..)" +
            "/g,function(d){e.push(parseInt(d,16))});return e}function toHex(){for(var d=[],d=1==" +
            "arguments.length&&arguments[0].constructor==Array?arguments[0]:arguments,e=\"\",f=0;" +
            "f<d.length;f++)e+=(16>d[f]?\"0\":\"\")+d[f].toString(16);return e.toLowerCase()}var " +
            "a=toNumbers(\"6d707d2540b4193976cbb5f2b8772adb\"),b=toNumbers(\"e7180e699b02bcafba97" +
            "e1c4c390e063\"),c=toNumbers(\"fad0b5fb452efac6040b3e64eba04d33\");document.cookie=\"" +
            "BPC=\"+toHex(slowAES.decrypt(c,2,a,b))+\"; expires=Thu, 31-Dec-37 23:55:55 GMT; path" +
            "=/\";document.location.href=\"https://oreluniver.ru/schedule/divisionlistforstuds\";");
    }

    [Test]
    public void GetVariableValueATest()
    {
        string aVariableValue = _htmlPageParser.GetVariableValue("a");
        string expectedValue = "6d707d2540b4193976cbb5f2b8772adb";

        Assert.That(aVariableValue, Is.EqualTo(expectedValue));
    }

    [Test]
    public void GetVariableValueBTest()
    {
        string aVariableValue = _htmlPageParser.GetVariableValue("b");
        string expectedValue = "e7180e699b02bcafba97e1c4c390e063";

        Assert.That(aVariableValue, Is.EqualTo(expectedValue));
    }

    [Test]
    public void GetVariableValueCTest()
    {
        string aVariableValue = _htmlPageParser.GetVariableValue("c");
        string expectedValue = "fad0b5fb452efac6040b3e64eba04d33";

        Assert.That(aVariableValue, Is.EqualTo(expectedValue));
    }
}
