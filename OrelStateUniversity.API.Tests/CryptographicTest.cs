using OrelStateUniversity.API.Helpers;
using System.Security.Cryptography;

namespace OrelStateUniversity.API.Tests;

internal class CryptographicTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DecryptTest()
    {
        string input = "995ba9d0b3dcb82f31b50e37a777a371";
        
        CipherMode mode = CipherMode.CBC;
        string key = "bc09975b05b62e66efb1488bbdac9412";
        string IV = "c74cad6a2073d03bd8e1a577c6e5f938";

        byte[] encryptedText = CryptographicHelper.Encrypt(input, mode, key, IV);
        string decryptedText = CryptographicHelper.Decrypt(encryptedText, mode, key, IV);

        Assert.That(decryptedText.Equals(input), Is.True);
    }
}
