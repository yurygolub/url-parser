using System.Collections.Generic;
using System.IO;
using Interfaces;

namespace DataReaderImplementation
{
    public class TextFileReader : IDataReader
    {
        private readonly string path;

        public TextFileReader(string path)
        {
            this.path = path;
        }

        public IEnumerable<string> Read()
        {
            List<string> list = new List<string>();
            using StreamReader streamReader = new StreamReader(this.path);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                list.Add(line);
            }

            return list.ToArray();
        }
    }
}
