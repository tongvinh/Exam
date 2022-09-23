using System.Reflection;
using Examination.Infrastructure.MongoDb;
using Examination.Infrastructure.MongoDb.SeedWork;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Serilog;

namespace Examination.API
{
    public class Program
    {
        public static int Main(string[] args)
        {
            string appName = typeof(Startup).Namespace;
            var configuration = GetConfiguration();

            Log.Logger = CreateSerilogLogger(configuration);
            try
            {
                Log.Information("Starting web host ({ApplicationContext})...", appName);
                var host = CreateHostBuilder(args).Build();
                Log.Information("Apply configuration web host ({ApplicationContext})...", appName);

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var logger = services.GetRequiredService<ILogger<ExamMongoDbSeeding>>();
                    var settings = services.GetRequiredService<IOptions<ExamSettings>>();
                    var mongoClient = services.GetRequiredService<IMongoClient>();
                    new ExamMongoDbSeeding()
                        .SeedAsync(mongoClient, settings, logger)
                        .Wait();
                }

                host.Run();
                Log.Information("Started web host ({ApplicationContext})...", appName);
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})", appName);
                return 1;
            }

            //  Create a logger object

            Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
            {
                return new LoggerConfiguration()
                  .MinimumLevel.Information()
                  .Enrich.WithProperty("ApplicationContext", appName)
                  .Enrich.FromLogContext()
                  .WriteTo.Console()
                  .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day, shared: true)
                  .ReadFrom.Configuration(configuration)
                  .CreateLogger();
            }

            IConfiguration GetConfiguration()
            {
                var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddEnvironmentVariables()
                  .AddUserSecrets(Assembly.GetAssembly(typeof(Startup)));

                var config = builder.Build();
                return builder.Build();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}