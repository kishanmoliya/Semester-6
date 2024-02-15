using System;
using System.Security.Cryptography;
using System.Text;

public static class UrlEncryptor
{
    private static readonly byte[] entropy = Encoding.Unicode.GetBytes("YourEntropyString");

    public static string Encrypt(string input)
    {
        byte[] encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(input), entropy, DataProtectionScope.CurrentUser);
        return Convert.ToBase64String(encryptedData);
    }

    public static string Decrypt(string encryptedInput)
    {
        try
        {
            byte[] decryptedData = ProtectedData.Unprotect(Convert.FromBase64String(encryptedInput), entropy, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decryptedData);
        }
        catch (CryptographicException)
        {
            return null; // Decryption failed
        }
    }
}