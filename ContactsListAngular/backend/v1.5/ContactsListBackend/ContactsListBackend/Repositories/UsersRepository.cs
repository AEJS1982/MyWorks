using ContactsListBackend.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        List<User> users;
        public UsersRepository()
        {
            this.fileName = "users.json";
            this.users = this.LoadData();
        }

        public User GetByName(string name)
        {
            return this.users.Where(x => x.Name == name).FirstOrDefault();
        }

        public string Login(string name, string password)
        {
            var auxUser = this.users.Where(x => x.Name == name).FirstOrDefault();
            var Token = "ERROR";
            var Randomizer = new Random();
            
            if (auxUser != null)
            {
                if (auxUser.Password == password)
                {
                    Token = "token_" + Randomizer.Next(100000, 999999).ToString();
                    auxUser.Token = Token;
                    this.SaveData(this.users);
                }
            }

            return Token;
        }

        public bool ValidateToken(string token)
        {
            var auxUser = this.users.Where(x => x.Token==token).FirstOrDefault();
            if (auxUser != null)
                return true;
            else
                return false;
        }

    }
}
