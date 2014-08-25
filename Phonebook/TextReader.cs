namespace Phonebook
{
    using System.Collections.Generic;
    using System.IO;

    public class TextReader
    {
        private StreamReader reader;
        private List<string> textLines;
        private string path;

        public TextReader(string path)
        {
            this.path = path;
        }

        public string Path { get; set; }

        public string[] GetLines()
        {
            this.reader = new StreamReader(this.path);
            this.textLines = new List<string>();

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    this.textLines.Add(line);
                    line = reader.ReadLine();
                }
            }

            return this.textLines.ToArray();
        }

        public string GetFullText()
        {
            string fullText = string.Empty;
            this.reader = new StreamReader(this.path);

            using (reader)
            {
                fullText = reader.ReadToEnd();
            }

            return fullText;
        }
    }
}
