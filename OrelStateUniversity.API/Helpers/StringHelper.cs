﻿namespace OrelStateUniversity.API.Helpers;

public static class StringHelper
{
    public static byte[] HexToBytes(string hex)
    {
        return Enumerable
            .Range(0, hex.Length)
            .Where(x => x % 2 == 0)
            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
            .ToArray();
    }

    public static string BytesToHex(byte[] bytes)
    {
        return BitConverter
            .ToString(bytes)
            .Replace("-", string.Empty)
            .ToLower();
    }
}
