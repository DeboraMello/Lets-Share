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
    public class UserController : Controller
    {
        private readonly IRepositorio _repositorio;
        public UserController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public IActionResult Index()
        {

            var viewModel = new UsersViewModel()
            {
                Users = _repositorio.UserSet
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(AddUser user)
        {

            if (ModelState.IsValid)
            {
                _repositorio.Add(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }

        public IActionResult Edit(int id)
        {
            AddUser user = _repositorio.UserSet.FirstOrDefault(x => x.Id.Equals(id));

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(AddUser user)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Update(user);

                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            AddUser user = _repositorio.UserSet.FirstOrDefault(x => x.Id == id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(AddUser user)
        {
            _repositorio.Remove(user);

            return RedirectToAction("Index");
        }
    }
}
