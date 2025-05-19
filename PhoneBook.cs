using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_Application
{
    // Represents a phonebook that manages contacts
    public class Phonebook
    {
        // List to store Contact objects
        private List<Contact> contacts = new();

        // Adds a new contact to the phonebook
        public void AddContact(string name, string number)
        {
            contacts.Add(new Contact(name, number));
            Console.WriteLine("Contact added.");
        }

        // Displays all contacts, sorted alphabetically by name
        public void ViewContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Phonebook is empty.");
                return;
            }

            // Sort contacts by name using MergeSort
            var sortedContacts = MergeSort(contacts);

            Console.WriteLine("All Contacts (sorted):");
            foreach (var contact in sortedContacts)
            {
                Console.WriteLine(contact);
            }
        }

        // Searches for a contact by name (case-insensitive)
        public Contact? SearchContact(string name)
        {
            return contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Deletes a contact by name if found
        public void DeleteContact(string name)
        {
            var contact = SearchContact(name);
            if (contact != null)
            {
                contacts.Remove(contact);
                Console.WriteLine("Contact removed.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        // Recursively sorts a list of contacts using Merge Sort based on name
        private List<Contact> MergeSort(List<Contact> list)
        {
            if (list.Count <= 1)
                return list;

            int mid = list.Count / 2;

            // Recursively divide the list into halves
            var left = MergeSort(list.GetRange(0, mid));
            var right = MergeSort(list.GetRange(mid, list.Count - mid));

            // Merge the sorted halves
            return Merge(left, right);
        }

        // Merges two sorted lists of contacts into one sorted list
        private List<Contact> Merge(List<Contact> left, List<Contact> right)
        {
            List<Contact> result = new List<Contact>();
            int i = 0, j = 0;

            // Compare contacts by name and add the smaller one to the result
            while (i < left.Count && j < right.Count)
            {
                if (string.Compare(left[i].Name, right[j].Name, StringComparison.OrdinalIgnoreCase) <= 0)
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            // Add any remaining contacts from the left list
            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            // Add any remaining contacts from the right list
            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }
    }
}
