using System.Collections.Generic;

namespace Interfaces
{
    public interface IDataWriter
    {
        void Write(IEnumerable<UrlData> data);
    }
}
