using Autofac;
using Autofac.Configuration;
using Interfaces;
using Microsoft.Extensions.Configuration;

using System;
using System.IO;


namespace Module
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigContainer();

            var manager = Container.Resolve<IManager>();
            var type = Container.Resolve<IType>();
            Console.WriteLine("Call method from Type");
            type.Test();
            Console.WriteLine("Call method from manager");
            manager.Test();

            Console.WriteLine("Done,  press enter to exit");
            Console.ReadLine();
        }

        private static void ConfigContainer()
        {
            var config = new ConfigurationBuilder();
            // config.AddJsonFile comes from Microsoft.Extensions.Configuration.Json
            // config.AddXmlFile comes from Microsoft.Extensions.Configuration.Xml
            config.AddJsonFile("services.json");

            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            Container = builder.Build();
        }

        public static IContainer Container { get; set; }
    }
}
