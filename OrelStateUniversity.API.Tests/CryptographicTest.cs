using OrelStateUniversity.API.Helpers;
using System.Security.Cryptography;

namespace OrelStateUniversity.API.Tests;

internal class CryptographicTest
{
    [Test]
    public void DecryptTest1()
    {
        string input = "995ba9d0b3dcb82f31b50e37a777a371";
        
        CipherMode mode = CipherMode.CBC;
        string key = "bc09975b05b62e66efb1488bbdac9412";
        string IV = "c74cad6a2073d03bd8e1a577c6e5f938";

        byte[] encryptedText = CryptographicHelper.Encrypt(input, mode, key, IV);
        string decryptedText = CryptographicHelper.Decrypt(encryptedText, mode, key, IV);

        Assert.That(decryptedText, Is.EqualTo(input));
    }

    [Test]
    public void DecryptTest2()
    {
        string expectedOutput = "4920528c372e9b9d32fe932cbbcf25bb";

        CipherMode mode = CipherMode.CBC;
        string key = "0088232c0662bbbb6ad8909685bca8b3";
        string IV = "31da26aba9238fc428ee9be76149834b";

        byte[] cypherText = StringHelper.HexToBytes("6584ab4675209e0506c0381ea7f38ae6");

        string actualOutput = CryptographicHelper.Decrypt(cypherText, mode, key, IV);

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }
}
