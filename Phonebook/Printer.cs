using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class Printer
    {
        public void PrintContacts(IEnumerable<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                this.Print(contact);
            }
        }

        private void Print(Contact contact)
        {
            string fullname = string.Format("{0} {1} {2}",
                contact.FirstName, contact.MiddleName, contact.LastName);
            string contactToDisplay = string.Format(
                "{0}({1}) from {2} - {3}",fullname, contact.Nickname, contact.Town, contact.PhoneNumber);
            Console.WriteLine(contactToDisplay);
        }
    }
}
