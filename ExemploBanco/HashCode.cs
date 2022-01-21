using System.Text;
using System.Security.Cryptography;

namespace ExemploBanco
{
    class HashCode
    {
        public string PassHash(string data)
        {
            SHA1 sha = SHA1.Create();
            byte[] hashdata = sha.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashdata.Length; i++)
            {
                sb.Append(hashdata[i].ToString());
            }
            return sb.ToString();
        }
    }
}
