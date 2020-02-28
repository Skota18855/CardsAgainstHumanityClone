using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CardsAgainstHumanityClone.Models;
using CardsAgainstHumanityClone.Data;

namespace CardsAgainstHumanityClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProfileDAL profileContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IProfileDAL context) : base()
        {
            profileContext = context;
            //_logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Profile profile)
        {
            if (profileContext.CheckIfReturningUser(profile))
            {
                return RedirectToAction("Index", "Game");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Profile profile)
        {
            if (ModelState.IsValid)
            {
                if (profileContext.AddProfile(profile, out string message))
                {
                    return RedirectToAction("GamePage");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View();
            }
        }


        public IActionResult GamePage()
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
