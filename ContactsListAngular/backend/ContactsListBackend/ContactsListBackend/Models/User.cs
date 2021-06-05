using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend.Models
{
    public class User
    {
        private int _id;
        private String _name;
        private String _password;
        private String _token;

        public string Name { get => _name; set => _name = value; }
        public string Password { get => _password; set => _password = value; }
        public string Token { get => _token; set => _token = value; }
    }
}
