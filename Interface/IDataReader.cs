using System.Collections.Generic;

namespace Interface
{
    public interface IDataReader
    {
        IEnumerable<string> Read();
    }
}
