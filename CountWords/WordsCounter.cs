namespace CountWords
{
    using FindOccurrances;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordsCounter
    {
        public static void Main(string[] args)
        {
            string path = "../../words.txt";
            string[] words = ExtractWords(path);
            Dictionary<string, int> wordsCount = OccurranceCounter.Count(words);
            var sortedwordsCount = wordsCount.OrderBy(x => x.Value);
            foreach (var item in sortedwordsCount)
            {
                Console.WriteLine("{0} -> {1} times.", item.Key, item.Value);   
            }
        }

        private static string[] ExtractWords(string path)
        {
            var reader = new StreamReader(path);
            string words = string.Empty;
            using (reader)
            {
                words = reader.ReadToEnd().ToLower();
            }

            char[] splitters = { ' ', '?', '!', '.', ',', ':', '-', '–' };
            string[] splittedWords = words.Split(
                splitters, StringSplitOptions.RemoveEmptyEntries);
            return splittedWords;
        }
    }
}
