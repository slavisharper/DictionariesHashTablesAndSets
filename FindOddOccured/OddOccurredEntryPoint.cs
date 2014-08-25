namespace FindOddOccured
{
    using System;
    using System.Collections.Generic;
    using FindOccurrances;

    public class OddOccurredEntryPoint
    {
        public static void Main(string[] args)
        {
            string[] words = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            string[] oddOccuredWords = OccurranceCounter.GetOddOccured(words);
            Console.WriteLine("Odd occurred in the array: " + string.Join(", ", oddOccuredWords));
        }
    }
}
