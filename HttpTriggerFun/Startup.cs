using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using HttpTriggerFun.Model;
using HttpTriggerFun.Repositories;
using HttpTriggerFun.Services.Interfaces;
using HttpTriggerFun.Services;
using HttpTriggerFun;

[assembly: FunctionsStartup(typeof(HttpTriggerFun.Startup))]
namespace HttpTriggerFun
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureServices(builder.Services).BuildServiceProvider(true);
        }

        private IServiceCollection ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            services.AddSingleton(new FunctionConfiguration(config));
            services.AddDbContext<CosmosContext>();
            services.AddScoped<IRepository<Book>, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
