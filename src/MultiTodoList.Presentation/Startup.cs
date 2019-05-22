using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTodoList.Infrastructure;

namespace MultiTodoList.Presentation
{
    class EfOptions : DbContextOptions<MultiTodoListDbContext>
    {
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _options    =
            new Lazy<DbContextOptions<MultiTodoListDbContext>>(
                () =>
                {
                    var connection = Configuration.GetConnectionString("main");
                    var optionsBuilder = new DbContextOptionsBuilder<MultiTodoListDbContext>();
                    var options = optionsBuilder
                        .UseSqlite(connection)
                        .EnableDetailedErrors()
                        .Options;
                    return options;
                },true);
        }

        public IConfiguration Configuration { get; }

        private Lazy<DbContextOptions<MultiTodoListDbContext>> _options;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<MultiTodoListDbContext>(sf=>new MultiTodoListDbContext(_options.Value));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc();
        }
    }
}