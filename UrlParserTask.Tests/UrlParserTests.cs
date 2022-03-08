using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DependencyResolver;
using Interface;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace UrlParserTask.Tests
{
    [TestFixture]
    public class UrlParserTests
    {
        private Startup startup;

        [SetUp]
        public void SetUp()
        {
            Startup startup = new Startup();
            startup.CreateServiceProvider();
            this.startup = startup;
        }

        [Test]
        public void ParseTest()
        {
            string[] data =
            {
                "https://github.com/AnzhelikaKravchuk?tab=repositories",
                "https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU",
                "https://habrahabr.ru/company/it-grad/blog/341486/",
                "dscds",
            };

            IParser parser = this.startup.ServiceProvider.GetService<IParser>();

            IEnumerable<UrlData> expected = parser.Parse(data);

            Assert.AreEqual(3, expected.Count());
        }

        [Test]
        public void ParseMockTest()
        {
            string[] data =
            {
                "https://github.com/AnzhelikaKravchuk?tab=repositories",
                "https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU",
                "https://habrahabr.ru/company/it-grad/blog/341486/",
                "dscds",
            };

            IParser parser = this.startup.ServiceProvider.GetService<IParser>();

            IEnumerable<UrlData> expected = parser.Parse(data);

            Assert.AreEqual(3, expected.Count());
        }
    }
}
