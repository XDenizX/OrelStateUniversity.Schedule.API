using System.Security.Cryptography;

namespace OrelStateUniversity.API.Helpers;

/// <summary>
/// Represent a static helper class for encryption and decryption 
/// of messages using the AES algorithm.
/// </summary>
public static class CryptographicHelper
{
    private static readonly Aes _aesAlgorithm = Aes.Create();

    /// <summary>
    /// Encrypt a <paramref name="inputText"/> using specified <paramref name="mode"/>,
    /// <paramref name="key"/> and <paramref name="initialVector"/>.
    /// </summary>
    /// <param name="inputText">Text for the encrypt.</param>
    /// <param name="mode">Mode of the encryption. See <see cref="CipherMode"/></param>
    /// <param name="key">Key for the encryption.</param>
    /// <param name="initialVector">Initial vector for the encryption.</param>
    /// <returns>Encrypted message as <see langword="byte"/>[].</returns>
    public static byte[] Encrypt(string inputText, CipherMode mode, string key, string initialVector)
    {
        byte[] output;

        _aesAlgorithm.Mode = mode;
        _aesAlgorithm.Padding = PaddingMode.None;
        _aesAlgorithm.IV = StringHelper.HexToBytes(initialVector);
        _aesAlgorithm.Key = StringHelper.HexToBytes(key);

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

    /// <summary>
    /// Decrypt a <paramref name="cipherText"/> using specified <paramref name="mode"/>,
    /// <paramref name="key"/> and <paramref name="initialVector"/>.
    /// </summary>
    /// <param name="cipherText">Text for the decryption.</param>
    /// <param name="mode">Mode of the decryption. See <see cref="CipherMode"/></param>
    /// <param name="key">Key for the decryption.</param>
    /// <param name="initialVector">Initial vector for the decryption.</param>
    /// <returns>Decrypted message as <see langword="string"/>.</returns>
    public static string Decrypt(byte[] cipherText, CipherMode mode, string key, string initialVector)
    {
        var output = new byte[16];

        _aesAlgorithm.Mode = mode;
        _aesAlgorithm.Padding = PaddingMode.None;
        _aesAlgorithm.IV = StringHelper.HexToBytes(initialVector);
        _aesAlgorithm.Key = StringHelper.HexToBytes(key);

        ICryptoTransform decryptor = _aesAlgorithm.CreateDecryptor(_aesAlgorithm.Key, _aesAlgorithm.IV);

        using (var memoryStream = new MemoryStream(cipherText))
        {
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            {
                using (var streamReader = new BinaryReader(cryptoStream))
                {
                    streamReader.Read(output);
                }
            }
        }

        return StringHelper.BytesToHex(output);
    }
}
