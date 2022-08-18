using OrelStateUniversity.API.Helpers;
using System.Security.Cryptography;

namespace OrelStateUniversity.API.Tests;

internal class StringHelperTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void HexToStringTest()
    {
        string input = "0102030405ff";
        byte[] expectedOutput = { 0x01, 0x02, 0x03, 0x04, 0x05, 0xFF };

        byte[] actualOutput = StringHelper.HexToBytes(input);

        Assert.That(actualOutput.SequenceEqual(expectedOutput), Is.True);
    }

    [Test]
    public void BytesToHexStringTest()
    {
        byte[] input = { 0x01, 0x02, 0x03, 0x04, 0x05, 0xFF };
        string expectedOutput = "0102030405ff";

        string actualOutput = StringHelper.BytesToHex(input);

        Assert.That(actualOutput.Equals(expectedOutput), Is.True);
    }
}
