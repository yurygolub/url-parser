using System;
using Moq;
using NUnit.Framework;

namespace Interfaces.Tests
{
    [TestFixture]
    public class InterfaceTests
    {
        [Test]
        public void ParseTest()
        {
            var parser = new Mock<IParser>();

            parser.Object.Parse(Array.Empty<string>());

            parser.Verify();
        }

        [Test]
        public void ReadTest()
        {
            var datarReader = new Mock<IDataReader>();

            datarReader.Object.Read();

            datarReader.Verify();
        }

        [Test]
        public void WriteTest()
        {
            var dataWriter = new Mock<IDataWriter>();

            dataWriter.Object.Write(Array.Empty<UrlData>());

            dataWriter.Verify();
        }

        [Test]
        public void ConvertTest()
        {
            var dataConverter = new Mock<IDataConverter>();

            dataConverter.Object.Convert();

            dataConverter.Verify();
        }
    }
}
