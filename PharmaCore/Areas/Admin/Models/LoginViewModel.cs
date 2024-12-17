using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCore.Areas.Admin.Models
{
    public class LoginViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; } // برای ذخیره کردن وضعیت ورود کاربر
    }
}