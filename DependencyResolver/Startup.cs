using System;
using System.IO;
using DataReaderImplementation;
using DataWriterImplementation;
using Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using UrlParserTask;

namespace DependencyResolver
{
    public class Startup
    {
        private IServiceProvider serviceProvider;

        public Startup()
        {
            this.ConfigurationRoot = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        public IServiceProvider ServiceProvider => this.serviceProvider;

        public IConfigurationRoot ConfigurationRoot { get; }

        public void CreateServiceProvider()
        {
            this.serviceProvider = new ServiceCollection()
                        .AddScoped<IDataReader, TextFileReader>(p => new TextFileReader(this.ConfigurationRoot["SourceFileName"]))
                        .AddScoped<IParser, UrlParser>()
                        .AddScoped<IDataWriter, XmlFileWriter>(p => new XmlFileWriter(this.ConfigurationRoot["DestinationFileName"]))
                        .AddSingleton<IDataConverter, TextToXmlConverter>()
                        .AddLogging(logBuilder =>
                            logBuilder
                            .AddNLog()
                            .SetMinimumLevel(LogLevel.Trace))
                        .BuildServiceProvider();
        }
    }
}
