using System.Security.Cryptography;
using System.Text;

public static class HashingUtil
{
    public static string ConvertirCadena(string entrada)
    {
         using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(entrada);
            byte[] hashBytes = sha256.ComputeHash(bytes);

            return Convert.ToHexString(hashBytes); 
        }
    }
}