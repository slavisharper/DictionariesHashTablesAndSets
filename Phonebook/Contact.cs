namespace Phonebook
{
    using System;

    public class Contact
    {
        public Contact(
            string firstName, string number, string town, string middleName = null, string lastName = null, string nickname = null)
        {
            if (firstName == null || number == null || town == null)
            {
                throw new ArgumentNullException();
            }

            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Nickname = nickname;
            this.PhoneNumber = number;
            this.Town = town;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Town { get; set; }

        public string Nickname { get; set; }
    }
}
