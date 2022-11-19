using System.Linq;
using DAL.App.EF;
using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // find the dbcontext
                var descriptor = services
                    .SingleOrDefault(d => 
                        d.ServiceType == typeof(DbContextOptions<AppDbContext>)
                        );
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<AppDbContext>(options =>
                {
                    // do we need unique db?
                    options.UseInMemoryDatabase(builder.GetSetting("test_database_name"));
                });

                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();

                db.Database.EnsureCreated();
                
                // data is already seeded
                if (db.StandardUnits.Any()) return;
                
                // seed data

                db.StandardUnits.Add((new StandardUnit()
                {
                    Title = "Title 0",
                    Symbol = "Symbol 0"
                }));
                db.SaveChanges();
            });
        }
    }
}