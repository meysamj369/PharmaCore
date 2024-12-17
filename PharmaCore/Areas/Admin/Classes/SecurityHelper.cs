using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;


namespace PharmaCore.Areas.Admin.Classes
{
    public class SecurityHelper
    {
        public static string HashPasswordMD5(string password)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // تبدیل هش به رشته‌ی هگزادسیمال
                StringBuilder sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("X2")); // به صورت حروف بزرگ
                }
                return sb.ToString();
            }
        }
    }
}