using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Interfaces;

#pragma warning disable SA1116 // Split parameters should start on line after declaration

namespace DataWriterImplementation
{
    public class XmlFileWriter : IDataWriter
    {
        private readonly string path;

        public XmlFileWriter(string path)
        {
            this.path = path;
        }

        public void Write(IEnumerable<UrlData> data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            XDocument xDocument = new XDocument();
            XElement urlAddresses = new XElement("urlAddresses");

            foreach (UrlData urlData in data)
            {
                XElement urlAddress = new XElement("urlAddress");

                urlAddress.Add(
                    new XElement("host",
                        new XAttribute("name", urlData.HostName)));

                if (urlData.Segments.Any())
                {
                    XElement uri = new XElement("uri");
                    foreach (string segment in urlData.Segments)
                    {
                        uri.Add(new XElement("segment", segment));
                    }

                    urlAddress.Add(uri);
                }

                if (urlData.Parameters.Any())
                {
                    XElement prms = new XElement("parameters");
                    foreach (var (key, value) in urlData.Parameters)
                    {
                        prms.Add(
                            new XElement("parametr",
                                new XAttribute("value", value),
                                new XAttribute("key", key)));
                    }

                    urlAddress.Add(prms);
                }

                urlAddresses.Add(urlAddress);
            }

            xDocument.Add(urlAddresses);

            xDocument.Save(this.path);
        }
    }
}
