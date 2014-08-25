namespace FindOccurrances
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            double[] numbers = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            var occurrances = OccurranceCounter.Count(numbers);

            foreach (var number in occurrances)
            {
                Console.WriteLine("{0} -> {1} times.", number.Key, number.Value);
            }
        }
    }
}
