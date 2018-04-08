using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetCore.Data;
using Microsoft.AspNetCore.Mvc;
using BetCore.Areas.Backoffice.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BetCore.Filters;

namespace BetCore.Areas.Backoffice.Controllers
{
    public class AuthenticationBackofficeController : BackofficeControllerBase
    {
        public AuthenticationBackofficeController(BetCoreDbContext context) : base(context)
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthencationBackofficeLoginViewModel model)
        {
            //ModelState.Remove("Password");
            if (!(model?.Login == "admin" && model?.Password == "admin"))
                ModelState.AddModelError("Login", "Login ou mot de passe incorrect.");

            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("USER_BO", JsonConvert.SerializeObject(model));

                var url = TempData["REDIRECT_BO"]?.ToString();
                if (!string.IsNullOrWhiteSpace(url))
                    return Redirect(url);
                //return RedirectToAction("Index", "Dashboard", new { area ="" });
                return RedirectToAction("Index", "Dashboard");
            }
            else
                return View();
        }

        [HttpGet]
        [AuthenticationBackofficeFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_BO");
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}