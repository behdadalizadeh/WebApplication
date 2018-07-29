using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Core.DTO.Pagination;
using WebApplication.Core.ViewModel.Users;
using WebApplication.Data.Repository;

namespace WebApplication.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersRepository _usersRepository;
        public UsersController(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IActionResult GetAll(Pagination vm)
        {
            var result = _usersRepository.GetAll(vm);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsersCreateViewModel vm)
        {
            var result = _usersRepository.Create(vm);
            TempData.AddResult(result);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _usersRepository.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(int id, UsersEditViewModel vm, string returnUrl)
        {
            var result = _usersRepository.Edit(id, vm);
            TempData.AddResult(result);
            return Redirect(returnUrl);
        }

        [HttpPost]
        public IActionResult Delete(int id, string returnUrl)
        {
            var result = _usersRepository.Delete(id);
            TempData.AddResult(result);
            return Redirect(returnUrl);
        }
    }
}