using Lets_Share.Models;
using LetsRsvp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lets_Share.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorio _repositorio;

        public HomeController(ILogger<HomeController> logger, IRepositorio repositorio)
        {
            _logger = logger;
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Items()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Items(AddItem item)
        {

            if (ModelState.IsValid)
            {
                _repositorio.Add(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }
    }
}
