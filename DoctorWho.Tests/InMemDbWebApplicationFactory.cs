using System;
using System.Linq;
using DoctorWho.Db;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorWho.Tests
{
    public class InMemDbWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var contextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DoctorWhoCoreDbContext)
                );
                services.Remove(contextDescriptor);

                services.AddScoped(e =>
                {
                    var opt = new DbContextOptionsBuilder();
                    opt.UseInMemoryDatabase("API testing db");
                    
                    return new DoctorWhoCoreDbContext(opt.Options);
                });

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;

                    var db = scopedServices.GetService<DoctorWhoCoreDbContext>();

                    db?.Database.EnsureCreated();
                }
            });
            
            base.ConfigureWebHost(builder);
        }
    }
}