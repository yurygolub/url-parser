using System.Collections.Generic;

namespace Interface
{
    public class UrlData
    {
        public string HostName { get; set; }

        public IEnumerable<string> Segments { get; set; }

        public IEnumerable<(string key, string value)> Parameters { get; set; }
    }
}
