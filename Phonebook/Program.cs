namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private const string PhonesPath = "../../phones.txt";
        private const string CommandsPath = "../../commands.txt";

        public static void Main(string[] args)
        {
            Printer printer = new Printer();
            Phonebook phone = ParsePhones();
            Command[] commands = ParseCommands(phone, printer);

            foreach (var command in commands)
            {
                command.Execute();
            }
        }

        private static Command[] ParseCommands(Phonebook phone, Printer printer)
        {
            TextReader commandReader = new TextReader(CommandsPath);
            string[] rawCommands = commandReader.GetLines();
            List<Command> commands = new List<Command>(rawCommands.Length);

            foreach (var rawCommand in rawCommands)
            {
                string[] commandParts = rawCommand.Split(new char[] { ',', '(', ')', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (commandParts.Length == 2)
                {
                    commands.Add(new Command(
                        new string[] { commandParts[1] }, phone, printer));
                }
                else if (commandParts.Length == 3)
                {
                    commands.Add(new Command(
                        new string[] { commandParts[1], commandParts[2] }, phone, printer));
                }
                else
                {
                    throw new ArgumentException("Invalid command!");
                }
            }

            return commands.ToArray();
        }

        private static Phonebook ParsePhones()
        {
            TextReader phonesReader = new TextReader(PhonesPath);
            string[] rawContacts = phonesReader.GetLines();
            Phonebook phonebook = new Phonebook();

            foreach (var rawContact in rawContacts)
            {
                Contact newContact = null;
                string[] rawContactParts = rawContact.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string[] nameNickname = rawContactParts[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                string town = rawContactParts[1].Trim();
                string number = rawContactParts[2].Trim();
                string[] names = nameNickname[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string nickname = string.Empty;
                if (nameNickname.Length == 2)
                {
                    nickname = nameNickname[1].Trim();
                }

                if (names.Length == 3)
                {
                    newContact = new Contact(
                        names[0].Trim(), number, town, names[1].Trim(), names[2].Trim(), nickname);
                }
                else if (names.Length == 2)
                {
                    newContact = new Contact(
                        names[0].Trim(), number, town, null, names[1].Trim(), nickname);
                }
                else if (names.Length == 1)
                {
                    newContact = new Contact(
                        names[0].Trim(), number, town, null, null, nickname);
                }

                phonebook.Add(newContact);
            }

            return phonebook;
        }
    }
}
