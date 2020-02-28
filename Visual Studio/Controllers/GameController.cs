using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardsAgainstHumanityClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardsAgainstHumanityClone.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index(Profile profile = null)
        {
            return View(profile);
        }
    }
}