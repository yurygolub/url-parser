using System.Collections.Generic;

namespace Interface
{
    public interface IDataWriter
    {
        void Write(IEnumerable<UrlData> data);
    }
}
