using System;
using System.Collections.Generic;
using System.Linq;
using Interface;
using Microsoft.Extensions.Logging;

namespace UrlParserTask
{
    public class UrlParser : IParser
    {
        private readonly ILogger<UrlParser> logger;

        public UrlParser(ILogger<UrlParser> logger)
        {
            this.logger = logger;
        }

        public IEnumerable<UrlData> Parse(string[] data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            List<UrlData> result = new List<UrlData>();
            for (int i = 0; i < data.Length; i++)
            {
                UrlData urlData = new UrlData();
                var urlParts = data[i].Split('/', StringSplitOptions.RemoveEmptyEntries).Skip(1);

                if (!urlParts.Any())
                {
                    this.logger.LogWarning($"Error in line {i + 1}.");
                    continue;
                }

                urlData.HostName = urlParts.First();

                urlData.Segments = urlParts
                    .Skip(1)
                    .Select(segment => segment.Split('?').First());

                IEnumerable<string> parameters = urlParts
                    .Last()
                    .Split('?')
                    .Skip(1);

                urlData.Parameters = !parameters.Any() ? Array.Empty<(string, string)>() : parameters
                    .First()
                    .Split('&')
                    .Select(parameter => parameter.Split('='))
                    .Select(pair => (pair.First(), pair.Last()))
                    .ToArray();

                result.Add(urlData);
            }

            return result;
        }
    }
}
