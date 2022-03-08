using System.Linq;

namespace Interface
{
    public class TextToXmlConverter : IDataConverter
    {
        private readonly IDataReader dataReader;
        private readonly IParser parser;
        private readonly IDataWriter dataWriter;

        public TextToXmlConverter(IDataReader dataReader, IParser parser, IDataWriter dataWriter)
        {
            this.dataReader = dataReader;
            this.parser = parser;
            this.dataWriter = dataWriter;
        }

        public void Convert()
        {
            var data = this.dataReader.Read().ToArray();
            
            this.dataWriter.Write(this.parser.Parse(data));
        }
    }
}
