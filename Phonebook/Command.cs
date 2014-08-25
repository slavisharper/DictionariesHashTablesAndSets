namespace Phonebook
{
    using System;

    public class Command
    {
        private Phonebook phonebook;
        private Printer printer;
        private string[] commandParts;

        public Command(string[] commandParts, Phonebook phonebook, Printer printer)
        {
            if ( commandParts == null || commandParts.Length > 2 || commandParts.Length == 0)
            {
                throw new ArgumentException("Invalid commands passed!");    
            }

            this.commandParts = commandParts;
            this.phonebook = phonebook;
            this.printer = printer;
        }

        public void Execute()
        {
            if (this.commandParts.Length == 1)
	        {
		        var result = this.phonebook.Find(this.commandParts[0]);
                this.printer.PrintContacts(result);
	        }
            else
            {
                var result = this.phonebook.Find(
                    this.commandParts[0], this.commandParts[1]);
                this.printer.PrintContacts(result);
            }
        }
    }
}
