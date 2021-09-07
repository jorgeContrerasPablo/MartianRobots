using InfrastructureEF.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer;
using ServiceLayer.IRepositories;
using ServiceLayer.IService;

namespace API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            if (_environment.IsProduction())
            {
                services.AddDbContext<MartianContext>(options =>
                {
                    options.UseNpgsql(Configuration.GetConnectionString("DatabaseConection"),
                        optionsBuilder => optionsBuilder.MigrationsAssembly(nameof(InfrastructureEF)));
                });
            }

            //Repostories
            services.AddScoped<IRobotRepository, RobotRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();

            var a = _environment.EnvironmentName;
            //Service
            services.AddSingleton<IWorldService, WorldService>();
            services.AddScoped<ICommandService, CommandService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
