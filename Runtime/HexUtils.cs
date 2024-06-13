using System;

public static class HexUtils
{
    public static sbyte[] ToHexBytes(this float value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);
        return Array.ConvertAll(bytes, b => (sbyte)b);
    }
    
    public static byte ToHexByte(this int value)
    {
        if (value < 0 || value > 255)
        {
            throw new ArgumentOutOfRangeException("value", "The value is outside the range of byte (0 to 255).");
        }

        string hexString = value.ToString("X2"); // Convert to hexadecimal string with 2 characters
        byte result = Convert.ToByte(hexString, 16); // Parse hexadecimal string to byte
        return result;
    }


}