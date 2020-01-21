using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAppLABNumbers.Models;

namespace MyFirstWebAppLABNumbers.Controllers
{
    public class CatsController : Controller
    {
        public IActionResult All()
        {

            ViewData["Cat"] = new Cat
            {
                Name = "Pesho",
                Age = 15

            };

            var model = new Cat
            {
                Name="Ivaylo",
                Age=3
            };
            return View(model);
        }

        public string Details(int id)
        {
            return "Cat ID: " + id;
        }
    }
}
