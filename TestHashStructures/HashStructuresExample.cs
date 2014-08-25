namespace TestHashStructures
{
    using System;
    using System.Collections.Generic;
    using HashStructures;

    public class HashStructuresExample
    {
        public static void Main(string[] args)
        {
            HasTableExample();
            HashedSetExample();
        }

        private static void HashedSetExample()
        {
            HashedSet<int> numbers = new HashedSet<int>();
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine("Has 2 -> {0}", numbers.Contains(2));
            Console.WriteLine("Has 10 -> {0}", numbers.Contains(10));

            List<int> otherNumbers = new List<int>() { 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            Console.WriteLine("Original set of numbers: ");
            Console.WriteLine(string.Join(", ", numbers.ToArray()));
            Console.WriteLine("Other set of number:");
            Console.WriteLine(string.Join(", ", otherNumbers));

            Console.WriteLine("Union of the sets");
            numbers.Union(otherNumbers);
            Console.WriteLine(string.Join(", ", numbers.ToArray())); // From 0 - 14

            Console.WriteLine("Intersect of the unioned numbers with other set:");
            numbers.Intersect(otherNumbers);
            Console.WriteLine(string.Join(", ", numbers.ToArray()));  // FROM 6 - 14
        }

        private static void HasTableExample()
        {
            var hashTable = new HashTable<string, decimal>();
            hashTable.Add("BMW", 20000);
            hashTable.Add("Mercedes", 25000);
            hashTable.Add("Skoda", 20000);
            hashTable.Add("Moher", 20000);
            hashTable.Add("Motoped", 20000);
            hashTable.Add("Kolelo", 20000);
            hashTable.Add("Motor s kosh", 20000);
            hashTable.Add("Ferrari", 25000);
            hashTable.Add("Lamborghini", 25000);
            hashTable.Add("Aston Martin", 25000);
            hashTable.Add("Zonda", 25000);
            hashTable.Add("Pontiak", 25000);
            hashTable.Add("Bangiq", 25000);
            hashTable.Add("Opel", 2555555);
            hashTable.Add("VW", 25000);
            hashTable.Add("Honda", 25000);
            hashTable.Add("Suzuki", 25000);
            hashTable.Add("Pazarska kolichka", 25000);
            hashTable.Add("Kia", 25000);

            string[] keys = hashTable.Keys();
            Console.WriteLine("KEYS: " + string.Join(", ", keys));
            Console.WriteLine(hashTable["Opel"]);

            foreach (var item in hashTable)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            hashTable.Delete("Suzuki");
            try
            {
                // Should throw Element not found
                Console.WriteLine(hashTable["Suzuki"]);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
