using PharmaCore.Areas.Admin.Classes;
using PharmaCore.Areas.Admin.Models;
using PharmaCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaCore.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly AdminContext _context; // کانتکست دیتابیس

        public AccountController()
        {
            _context = new AdminContext(); // مقداردهی کانتکست
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // هش کردن پسورد
            string hashedPassword = SecurityHelper.HashPasswordMD5(model.Password);

            // بررسی کاربر در دیتابیس
            var user = _context.Users
                .FirstOrDefault(u => u.UserName == model.UserName && u.Password == hashedPassword && u.Active == true);

            if (user == null)
            {
                ModelState.AddModelError("", "نام کاربری یا رمز عبور اشتباه است.");
                return View(model);
            }

            // ذخیره اطلاعات کاربر در سشن یا کوکی
            Session["UserId"] = user.UserId;
            Session["UserName"] = user.UserName;

            // ریدایرکت به صفحه اصلی یا داشبورد
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            // پاک کردن سشن
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
