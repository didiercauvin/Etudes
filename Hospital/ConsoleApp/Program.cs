using AdministrationContext;
using BuildingBlocks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
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
                   .AddMediatR(typeof(RegisterPatientRequest.Handler).Assembly)
                   .AddTransient<MyApplication>()
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
        private readonly IMediator _mediator;

        public MyApplication(IMediator mediator)
        {
            _mediator = mediator;
        }

        internal async Task Run()
        {
            Console.WriteLine("Hello World!");
            var input = new RegisterPatientRequest()
            {
                FirstName = "Didier",
                Name = "Cauvin",
                Birthdate = new DateTime(1980, 12, 30),
                Adresse1 = "chemin du plan de clavel",
                PostalCode = "13330",
                City = "Pelissanne"
            };

            await _mediator.Send(input);
        }
    }
}

