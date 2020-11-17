namespace Sandbox
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;

    using goodweebs.Data;
    using goodweebs.Data.Common;
    using goodweebs.Data.Common.Repositories;
    using goodweebs.Data.Models;
    using goodweebs.Data.Repositories;
    using goodweebs.Data.Seeding;
    using goodweebs.Services.Data;
    using goodweebs.Services.Messaging;

    using CommandLine;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Entities;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Collections.Generic;

    public static class Program
    {
        public static async Task Main(string[] args)
        {

            string json = null;
            using (StreamReader r = new StreamReader(@"C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\wwwroot\anime-offline-database.json"))
            {
                json = r.ReadToEnd();
            }
            //WORKS!!!!
            var animeDTOs = JsonConvert.DeserializeObject<AnimeDTO[]>(json);
            Console.WriteLine(json);

            Console.WriteLine();
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            // Seed data on application startup
            //    using (var serviceScope = serviceProvider.CreateScope())
            //    {
            //        var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //        dbContext.Database.Migrate();
            //        new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            //    }

            //    using (var serviceScope = serviceProvider.CreateScope())
            //    {
            //        serviceProvider = serviceScope.ServiceProvider;

            //        return Parser.Default.ParseArguments<SandboxOptions>(args).MapResult(
            //            opts => SandboxCode(opts, serviceProvider).GetAwaiter().GetResult(),
            //            _ => 255);
            //    }
        }

        private static async Task<int> SandboxCode(SandboxOptions options, IServiceProvider serviceProvider)
        {
            var sw = Stopwatch.StartNew();

            var settingsService = serviceProvider.GetService<ISettingsService>();
            Console.WriteLine($"Count of settings: {settingsService.GetCount()}");

            Console.WriteLine(sw.Elapsed);
            return await Task.FromResult(0);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .UseLoggerFactory(new LoggerFactory()));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();
        }

    }
}
