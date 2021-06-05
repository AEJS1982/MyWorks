using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend.Repositories
{
    public interface IUsersRepository
    {
        string Login(string name,string password);
        bool ValidateToken(string token);
    }
}
