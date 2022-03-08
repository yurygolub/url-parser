using DependencyResolver;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public static class Program
    {
        public static void Main()
        {
            Startup startup = new Startup();
            startup.CreateServiceProvider();

            var converter = startup.ServiceProvider.GetService<IDataConverter>();
            converter?.Convert();
        }
    }
}
