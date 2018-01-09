using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;

using TestASPNETIdentity.Models;

namespace TestASPNETIdentity.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Users model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if ((model.Email == "admin@admin.com") && (model.Password == "12345"))
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "Yu"),
                    new Claim(ClaimTypes.Email, "yuki@email.com"),
                    new Claim(ClaimTypes.Country, "VN"),
                }, "ApplicationCookie");
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }

        public ActionResult Registraion()
        {
            return View();
        }
    }
}