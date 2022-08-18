namespace OrelStateUniversity.API.Helpers;

/// <summary>
/// Represent a static helper class for the string convertations.
/// </summary>
public static class StringHelper
{
    /// <summary>
    /// Convert hexadecimal string to bytes array.
    /// </summary>
    /// <param name="hex">Hexadecimal string</param>
    /// <returns>Bytes array</returns>
    public static byte[] HexToBytes(string hex)
    {
        return Enumerable
            .Range(0, hex.Length)
            .Where(x => x % 2 == 0)
            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
            .ToArray();
    }

    /// <summary>
    /// Convert bytes array to hexadecimal representation.
    /// </summary>
    /// <param name="bytes">Bytes array</param>
    /// <returns>Hexadecimal string representation of bytes array</returns>
    public static string BytesToHex(byte[] bytes)
    {
        return BitConverter
            .ToString(bytes)
            .Replace("-", string.Empty)
            .ToLower();
    }
}
