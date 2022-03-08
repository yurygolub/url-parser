using System.Collections.Generic;

namespace Interface
{
    public interface IParser
    {
        IEnumerable<UrlData> Parse(string[] data);
    }
}
