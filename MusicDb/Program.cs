using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MusicDb.Data;
using MusicDb.Repositories;
using MusicDb.Services;
using MusicDb.Services.Output;
using Serilog;

namespace MusicDb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Configure Serilog early to capture startup logs
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Async(a => a.Console())
                .CreateLogger();

            try
            {
                Log.Information("Starting MusicDb application...");

                var host = Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        config.AddJsonFile("appsettings.json", optional: false);

                        var env = hostingContext.HostingEnvironment;
                        config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                        if (env.IsDevelopment())
                        {
                            config.AddUserSecrets<Program>();
                        }

                        config.AddEnvironmentVariables();
                    })
                    .ConfigureServices((context, services) =>
                    {
                        services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>();
                        services.AddScoped<IDbConnection>(sp =>
                            sp.GetRequiredService<IDbConnectionFactory>().CreateConnection());

                        services.AddScoped<IDataAccess, DataAccess>();

                        services.AddScoped<IArtistRepository, ArtistRepository>();
                        services.AddScoped<IRecordRepository, RecordRepository>();
                        services.AddScoped<IDiscRepository, DiscRepository>();
                        services.AddScoped<ITrackRepository, TrackRepository>();

                        services.AddScoped<IArtistDbService, ArtistDbService>();
                        services.AddScoped<IRecordDbService, RecordDbService>();
                        services.AddScoped<IDiscDbService, DiscDbService>();
                        services.AddScoped<ITrackDbService, TrackDbService>();

                        services.AddSingleton<IOutputService, ConsoleOutputService>();
                    })
                    .UseSerilog()
                    .Build();

                using (var scope = host.Services.CreateScope())
                {
                    // await scope.ServiceProvider.GetRequiredService<IArtistDbService>().RunAllDatabaseOperations();
                    await scope.ServiceProvider.GetRequiredService<IRecordDbService>().RunAllDatabaseOperations();
                    // await scope.ServiceProvider.GetRequiredService<IDiscDbService>().RunAllDatabaseOperations();
                    // await scope.ServiceProvider.GetRequiredService<ITrackDbService>().RunAllDatabaseOperations();
                }

                Log.Information("All database operations completed successfully");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
