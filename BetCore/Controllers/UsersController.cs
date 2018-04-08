using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BetCoreModels.Models;
using BetCore.Data;
using BetCore.Utils;

namespace BetCore.Controllers
{
    public class UsersController : Controller
    {
        private readonly BetCoreDbContext context;

        public UsersController(BetCoreDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = user.Password.Encrypt();
                user.UpdatedAt = DateTime.Now;
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                //ViewBag.Message = "Utilisateur engristré";
                //ViewData["Message"] = "Utilisateur engristré";
                //return View();

                TempData["Message"] = "Utilisateur engristré";

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}