using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend.Models
{
    public class Contact
    {
        private int _id;
        private String _firstName;
        private String _lastName;
        private String _phoneNumber;
        private string _email;

        public int id {
            get { return _id; }
            set { _id = value; }
        }

        public String firstName {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public String lastName {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public String phoneNumber {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string email {
            get { return _email; }
            set { _email = value; }
        }

        public Contact() { 
        
        }
    }
}
