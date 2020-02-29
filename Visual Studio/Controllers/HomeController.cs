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

        public readonly IProfileDAL profileContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IProfileDAL context) : base()
        {
            profileContext = context;
            Bridge.context = context;
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
            if (profileContext.GetCollection().Count() > 0)
            {
                if (profileContext.CheckIfReturningUser(profile))
                {
                    GameViewModel model = new GameViewModel(profile);
                    return RedirectToAction("Index", "Game", model);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Signup");
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
                    return RedirectToAction("Index", "Game", profile);
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
