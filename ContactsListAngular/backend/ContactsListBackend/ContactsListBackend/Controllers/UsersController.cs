using ContactsListBackend.Models;
using ContactsListBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsListBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersRepository _repo;

        public UsersController(IUsersRepository repo) {
            _repo = repo;
        }

        // POST: api/<UsersController>
        [HttpPost]
        public string Login([FromBody] User usuario)
        {
            return _repo.Login(usuario.Name, usuario.Password);
        }

        // GET api/<UsersController>/5
        [HttpGet("{userName}")]
        public User Get(string userName)
        {
            return _repo.GetByName(userName);
        }

    }
}
