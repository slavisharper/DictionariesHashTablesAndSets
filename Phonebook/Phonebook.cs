namespace Phonebook
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Phonebook
    {
        private MultiDictionary<string, Contact> contactNames;
        private MultiDictionary<string, Contact> contactTowns;

        public Phonebook()
        {
            this.contactNames = new MultiDictionary<string, Contact>(true);
            this.contactTowns = new MultiDictionary<string, Contact>(true);
        }

        public Phonebook(IEnumerable<Contact> contacts)
            : this()
        {
            foreach (var contact in contacts)
            {
                this.Add(contact);
            }
        }

        public void Add(Contact contact)
        {
            this.contactNames.Add(contact.FirstName.ToLower(), contact);
            if (contact.LastName != null)
            {
                this.contactNames.Add(contact.LastName.ToLower(), contact);
            }
            
            if (contact.MiddleName != null)
            {
                this.contactNames.Add(contact.MiddleName.ToLower(), contact);
            }

            if (contact.Nickname != null)
            {
                this.contactNames.Add(contact.Nickname.ToLower(), contact);
            }

            this.contactTowns.Add(contact.Town.ToLower(), contact);
        }

        public List<Contact> Find(string name)
        {
            var found = this.contactNames[name.ToLower()].ToList();
            return found;
        }

        public List<Contact> Find(string name, string town)
        {
            var foundNames = this.contactNames[name.ToLower()].ToList();
            var founTowns = this.contactTowns[town.ToLower()].ToList();
            var founContacts = foundNames.Intersect(founTowns).ToList();
            return founContacts;
        }
    }
}
