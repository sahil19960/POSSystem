using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PosSystem.Models;
using PosSystem.Services;
using System;
using System.Diagnostics;

namespace PosSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IDatabaseAccessService _databaseAccessService;

        public LoginController(IDatabaseAccessService databaseAccessService)
        {
            _databaseAccessService = databaseAccessService;
        }

        public IActionResult Login()
        {
           return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(User userDetails)
        {
            var user = _databaseAccessService.GetUserByEmailIdAndPassword(userDetails.UserEmailId, userDetails.Password);

            if(user != null)
            {
                HttpContext.Session.SetInt32("User", user.UserId);

                return RedirectToAction("PosDashboard", "PosDashboard");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
