
using InfrastructureEF.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
        }
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddDbContext<MartianContext>(options =>
            {
                options.UseInMemoryDatabase("TestDatabase-" + Guid.NewGuid());
            });
        }

    }
}
