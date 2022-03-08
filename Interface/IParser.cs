using System.Collections.Generic;

namespace Interfaces
{
    public interface IParser
    {
        IEnumerable<UrlData> Parse(string[] data);
    }
}
