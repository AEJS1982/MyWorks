using ContactsListBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend.Repositories
{
    public interface IContactsRepository
    {
        void Add(Contact entity);
        void Remove(Contact entity);
        List<Contact> GetAll();
        Contact GetById(int id);
        void Modify(Contact entity);
    }
}
