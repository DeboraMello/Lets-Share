using Lets_Share.Models;
using Lets_Share.ViewModels;
using LetsRsvp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lets_Share.Controllers
{
    public class ItemController : Controller
    {
        private readonly IRepositorio _repositorio;
        private IQueryable<AddItem> SearchReturn;
        public ItemController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public IActionResult Index()
        {

            var viewModel = new ItemsViewModel()
            {
                Items = _repositorio.ItemSet,
                Search = string.Empty
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(AddItem item)
        {

            if (ModelState.IsValid)
            {
                _repositorio.Add(item);

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public IActionResult Edit(int id)
        {

            //var retorno = ;
            AddItem item = _repositorio.ItemSet.FirstOrDefault(x => x.Id.Equals(id));

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(AddItem item)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Update(item);

                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var teste = _repositorio.ItemSet;
            AddItem item = _repositorio.ItemSet.FirstOrDefault(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(AddItem item)
        {
            _repositorio.Remove(item);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(ItemsViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.Search))
            {
                SearchReturn = _repositorio.ItemSet.Where(x => x.Name.Contains(viewModel.Search));
                viewModel.Items = SearchReturn;
            }
            
            return View(viewModel);
        }

        public IActionResult Rent()
        {

            var viewModel = new ItemsViewModel()
            {
                Items = _repositorio.ItemSet.Where(x => x.AvailableRent == true & x.AvailableBorrow == true),
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Rent(ItemsViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.Search))
            {
                SearchReturn = _repositorio.ItemSet.Where(x => x.Name.Contains(viewModel.Search) & x.AvailableRent == true & x.AvailableBorrow == true);
                viewModel.Items = SearchReturn;
            }

            return View(viewModel);
        }
    }
}
