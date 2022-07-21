using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class BookStoreController : Controller
    {
        UserRepository _repository = new UserRepository();
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            User user = _repository.Login(model);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            User user = _repository.Register(model);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }
    }
}
