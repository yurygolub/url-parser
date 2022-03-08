using System.Collections.Generic;

namespace Interfaces
{
    public interface IDataReader
    {
        IEnumerable<string> Read();
    }
}
