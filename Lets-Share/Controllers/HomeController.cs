using Lets_Share.Models;
using Lets_Share.ViewModels;
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

        //public IActionResult Index()
        //{

        //    var viewModel = new ItemsViewModel()
        //    {
        //        Items = _repositorio.ItemSet.Where(x => (bool)(x.AvailableRent & x.AvailableBorrow == true));
        //    };
        //    return View(viewModel);
        //}

        public IActionResult Index()
        {

            var viewModel = new ItemsViewModel()
            {
                Items = _repositorio.ItemSet.Where(x => (bool)(x.AvailableRent & x.AvailableBorrow == true))
            };


            return View(viewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
