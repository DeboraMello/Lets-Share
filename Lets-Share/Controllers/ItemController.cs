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
        public ItemController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public IActionResult Index()
        {

            var viewModel = new ItemsViewModel()
            {
                Items = _repositorio.ItemSet
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
    }
}
