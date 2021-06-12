using ContactsListBackend.Models;
using ContactsListBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsListBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContactsRepository _repo;

        public ContactsController(IContactsRepository repo) {
            _repo = repo;
        }

        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _repo.GetAll();
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _repo.GetById(id);
        }

        // POST api/<ContactsController>
        [HttpPost]  
        public void Post([FromBody] object value)
        {
            var innerValue = JsonConvert.DeserializeObject<Contact>(value.ToString());
            if (validateData(innerValue))
                this._repo.Add(innerValue);
        }

        private bool validateData(Contact p)
        {
            var isDataOk = (!String.IsNullOrEmpty(p.firstName) && !String.IsNullOrEmpty(p.lastName)
                && !String.IsNullOrEmpty(p.email) && !String.IsNullOrEmpty(p.email));

            return isDataOk;
        }

        // PUT api/<ContactsController>/5
        [HttpPut]
        public void Put([FromBody] object value)
        {
            var innerValue = JsonConvert.DeserializeObject<Contact>(value.ToString());

            if (validateData(innerValue))
                this._repo.Modify(innerValue);
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var auxContact=this._repo.GetById(id);
            this._repo.Remove(auxContact);
        }
    }
}
