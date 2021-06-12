using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend.Config
{
    public class MyConfig
    {
        private string _DBConnectionString;

        public string DBConnectionString { get => _DBConnectionString; set => _DBConnectionString = value; }
    }
}
