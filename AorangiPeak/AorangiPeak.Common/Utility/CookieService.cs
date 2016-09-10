using System;
using System.Web;
using System.Web.Security;

namespace AorangiPeak.Common.Utility
{
    public class CookieService
    {
        private static string Encrypt(string str)
        {
            string strResult = "";
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(str, true, 2);
            strResult = FormsAuthentication.Encrypt(ticket).ToString();
            return strResult;
        }

        private static string Decrypt(string str)
        {
            string strResult = "";
            strResult = FormsAuthentication.Decrypt(str).Name.ToString();
            return strResult;
        }

        public static HttpCookie SaveCookies(string str)
        {
            string encryptStr = Encrypt(str);
            HttpCookie cookie = new HttpCookie("AP_Guid", encryptStr);
            cookie.Expires = DateTime.Now.AddDays(1);
            return cookie;
        }

        public static string ReadCookies(HttpCookie cookie)
        {
            if (cookie != null)
                return Decrypt(cookie.Value);
            return string.Empty;
        }

        public static HttpCookie DeleteCookies(HttpCookie cookie)
        {
            if (cookie != null)
            {
                cookie.Values.Remove("AP_Guid");
                cookie.Expires = DateTime.Now.AddDays(-1);
            }

            return cookie;
        }
    }
}
