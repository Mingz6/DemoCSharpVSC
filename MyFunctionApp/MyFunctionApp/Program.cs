using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFunctionApp.Models;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((hostBuilderContext, services) =>
        {
            
            services.AddOptions<FuncSettings>()
                .Configure<IConfiguration>((settings, configuration) => configuration.Bind(settings));
        })
        .Build();

host.Run();