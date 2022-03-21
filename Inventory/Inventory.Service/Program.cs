using CleanArchitecture.Infrastructure.Persistence;
using Inventory.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Service
{
    public  class Program
    {
        public static void Main(string[] args)
        {
           var host= CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<InventoryDbContext>();
                InventoryDbContextSeed.SeedSampleProductDataAsync(context);
            }
            host.Run();
        }

  
        //public  static void Main(string[] args)
        //{
        //    var host = CreateHostBuilder(args).Build();

        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;

        //        try
        //        {
        //            var context = services.GetRequiredService<InventoryDbContext>();

        //            if (context.Database.IsSqlServer())
        //            {
        //                context.Database.Migrate();
        //            }

        //            // InventoryDbContextSeed.SeedSampleProductDataAsync(context);
        //        }
        //        catch (Exception ex)
        //        {
        //            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        //            logger.LogError(ex, "An error occurred while migrating or seeding the database.");

        //            throw;
        //        }
        //    }

        //     host.RunAsync();
        //    //CreateHostBuilder(args).Build().Run();
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
