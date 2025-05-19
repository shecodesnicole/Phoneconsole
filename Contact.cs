using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Phonebook_Application
{
    // Represents a contact in the phonebook
    public class Contact
    {
        // Property to store the contact's name
        public string Name { get; set; }

        // Property to store the contact's phone number
        public string PhoneNumber { get; set; }

        // Constructor to initialize a contact with a name and phone number
        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        // Overrides the default ToString method to display contact details in a readable format
        public override string ToString()
        {
            return $"{Name} - {PhoneNumber}";
        }
    }
}
