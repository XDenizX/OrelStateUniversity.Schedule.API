using System.Security.Cryptography;

namespace OrelStateUniversity.API.Helpers;

public static class CryptographicHelper
{
    private static readonly Aes _aesAlgorithm = Aes.Create();

    public static byte[] Encrypt(string inputText, CipherMode mode, string key, string IV)
    {
        byte[] output;

        _aesAlgorithm.Mode = mode;
        _aesAlgorithm.Key = StringHelper.HexToBytes(key);
        _aesAlgorithm.IV = StringHelper.HexToBytes(IV);

        ICryptoTransform encryptor = _aesAlgorithm.CreateEncryptor(_aesAlgorithm.Key, _aesAlgorithm.IV);

        using (var memoryStream = new MemoryStream())
        {
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            using (var streamWriter = new StreamWriter(cryptoStream))
            {
                streamWriter.Write(inputText);
            }

            output = memoryStream.ToArray();
        }

        return output;
    }

    public static string Decrypt(byte[] cipherText, CipherMode mode, string key, string IV)
    {
        string output;

        _aesAlgorithm.Key = StringHelper.HexToBytes(key);
        _aesAlgorithm.Mode = mode;
        _aesAlgorithm.IV = StringHelper.HexToBytes(IV);

        ICryptoTransform decryptor = _aesAlgorithm.CreateDecryptor(_aesAlgorithm.Key, _aesAlgorithm.IV);

        using (var memoryStream = new MemoryStream(cipherText))
        {
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);
            
            output = streamReader.ReadToEnd();
        }

        return output;
    }
}
