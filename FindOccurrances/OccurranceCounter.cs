namespace FindOccurrances
{
    using System.Collections.Generic;

    public static class OccurranceCounter
    {
        public static Dictionary<T, int> Count<T>(ICollection<T> elements)
        {
            var occurances = new Dictionary<T, int>();
            foreach (var element in elements)
            {
                if (occurances.ContainsKey(element))
                {
                    occurances[element]++;
                }
                else
                {
                    occurances.Add(element, 1);
                }
            }

            return occurances;
        }

        public static T[] GetOddOccured<T>(ICollection<T> elements)
        {
            var occurrances = Count(elements);
            var oddOccured = new List<T>();

            foreach (var occurance in occurrances)
            {
                if (occurance.Value % 2 != 0)
                {
                    oddOccured.Add(occurance.Key);
                }
            }

            return oddOccured.ToArray();
        }
    }
}
