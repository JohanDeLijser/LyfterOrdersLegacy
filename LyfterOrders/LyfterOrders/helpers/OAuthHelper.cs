using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LyfterOrders.helpers
{
    public class OAuthHelper
    {
        public static String getTimeStamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static String getNonce()
        {
            string result = "";
            SHA1 sha1 = SHA1.Create();
            Random rand = new Random();

            while (result.Length < 32)
            {
                string[] generatedRandoms = new string[4];

                for (int i = 0; i < 4; i++)
                {
                    generatedRandoms[i] = rand.Next().ToString();
                }

                result += Convert.ToBase64String(sha1.ComputeHash(Encoding.ASCII.GetBytes(string.Join("", generatedRandoms) + "|"))).Replace("=", "").Replace("/", "").Replace("+", "");
            }

            return result.Substring(0, 32);
        }
        
        public static String getSignature(String clientKey)
        {
            return "dl8ipcFavJUfCjcs4DzFOwPIHdA";
        }

        public static String getAuthString(String clientKey)
        {
            return "oauth_customer_key=" + clientKey +
                   "&oauth_signature_method=HMAC-SHA1" +
                   "&oauth_timestamp=" + getTimeStamp(DateTime.Now) +
                   "&oauth_nonce=" + getNonce() +
                   "&oauth_version=1.0" +
                   "&oauth_signature=" + getSignature(clientKey);
        }
    }
}