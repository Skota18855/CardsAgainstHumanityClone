using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardsAgainstHumanityClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardsAgainstHumanityClone.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("ProfileDetails");
        }
        public IActionResult ProfileDetails(Profile profile)
        {
            return View(profile);
        }
    }
}