using ContactsListBackend.Config;
using ContactsListBackend.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactsRepository
    {
        private readonly IOptions<MyConfig> config;
        private List<Contact> _contacts;
        private ObjectCopier oc;
        private FileStream dataFile;
        private StreamReader sr;
        private StreamWriter sw;

        public List<Contact> contacts {
            get {
                if (this._contacts == null)
                    _contacts = new List<Contact>();

                return _contacts;
            }

            set {
                this._contacts = value;
            }
        }

        public ContactRepository(IOptions<MyConfig> config) {
            this.config = config;
            this.fileName = "contacts.json";
            this.contacts = this.LoadData();
            oc = new ObjectCopier();
        }

        private void CreateTestData()
        {
            var p1 = new Contact();
            p1.Id = 1;
            p1.FirstName = "Chuck";
            p1.LastName = "Shuldiner";
            p1.Email = "chuck@death.com";
            p1.PhoneNumber = 999999999;
            var p2 = new Contact();
            p2.Id = 2;
            p2.FirstName = "Max";
            p2.LastName = "Cavalera";
            p2.Email = "max@sepultura.br";
            p2.PhoneNumber = 111000111;
            this.contacts.Add(p1);
            this.contacts.Add(p2);
            this.SaveData(this.contacts);
        }

        public void Add(Contact entity)
        {
            contacts.Add(entity);
            this.SaveData(this.contacts);
        }

        public List<Contact> GetAll()
        {
            return contacts.ToList();
        }

        public void Modify(Contact entity)
        {
            var auxContact=contacts.FirstOrDefault(x => x.Id == entity.Id);
            oc.Copy(entity, auxContact);
            this.SaveData(this.contacts);
        }

        public void Remove(Contact entity)
        {
            contacts.Remove(entity);
            this.SaveData(this.contacts);
        }

        public Contact GetById(int id)
        {
            return contacts.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
