using System.Security.Cryptography;
using System.Text;
namespace DataConnect.Business
{
    public class Encryption 
    {
        public static string ComputeSha256Hash(string rawData) // zorgt er voor dat de wachtwoorden gehashed worden.
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData)); // maakt een array van bites



                StringBuilder builder = new StringBuilder(); // zet de array om in een string
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString(); // geeft de string terug
            }

        }
    }
}
