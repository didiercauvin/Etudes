using AdministrationContext;
using BuildingBlocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {

                   services
                   .AddTransient<MyApplication>()
                   .AddScoped<ICommandHandler<RegisterPatientCommand>, RegisterPatientCommand.Handler>()
                   .AddDbContext<AdministrationDbContext>();
               }).UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var myService = services.GetRequiredService<MyApplication>();
                    await myService.Run();

                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadLine();

        }
    }

    public class MyApplication
    {
        private readonly ICommandHandler<RegisterPatientCommand> _registerPatientCommandHandler;

        public MyApplication(
            ICommandHandler<RegisterPatientCommand> registerPatientCommandHandler)
        {
            this._registerPatientCommandHandler = registerPatientCommandHandler;
        }

        internal async Task Run()
        {
            Console.WriteLine("Hello World!");
            var input = new RegisterPatientCommand()
            {
                FirstName = "Didier",
                Name = "Cauvin",
                Birthdate = new DateTime(1980, 12, 30),
                Adresse1 = "chemin du plan de clavel",
                PostalCode = "13330",
                City = "Pelissanne"
            };

            _registerPatientCommandHandler.Handle(input);
        }
    }
}

