using System.Text;
using System.Security.Cryptography;

namespace HabboBot.Connection
{
    public static class HId
    {
        public static string GenerateId(int length = 32)
        {
            using (RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[length];
                rngProvider.GetBytes(new byte[length]);
                using (MD5 md5 = MD5.Create())
                {
                    var md5Hash = md5.ComputeHash(bytes);
                    StringBuilder sb = new StringBuilder();
                    foreach (var data in md5Hash)
                    {
                        sb.Append(data.ToString("x2"));
                    }
                    return $"~{sb.ToString()}";
                }
            }
        }
    }
}
