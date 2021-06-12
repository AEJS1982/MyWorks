using ContactsListBackend.Controllers;
using ContactsListBackend.Models;
using ContactsListBackend.Repositories;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace ContactsListBackend.Tests.Repositories
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           

        }

        [Test]
        public void ContactsListIsNotEmpty()
        {
            var testData = new List<Contact>();
            testData.Add(new Contact() {FirstName="John" , LastName="Rambo", Email="a@a.com" });
            var repo = NSubstitute.Substitute.For<IContactsRepository>();

            repo.GetAll().ReturnsForAnyArgs(testData);
            var c1 = new ContactsController(repo);
            var contactsList=(IList<Contact>)c1.Get();
            repo.Received().GetAll();
            Assert.IsTrue(contactsList.Count > 0);
            

        }


    }
}