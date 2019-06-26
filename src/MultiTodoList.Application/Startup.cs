using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTodoList.Application.Infrastructure;
using MultiTodoList.Core.TodoModule.UseCase;
using MultiTodoList.Core.TodoModule.UseCase.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace MultiTodoList.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("main");
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<MultiTodoListDbContext>(options => options
                .UseSqlite(connection)
                .EnableDetailedErrors());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "MultiTodoList Service", Version = "v1"});
            });
            services.AddScoped<IUserRepository, UserEfRepository>();
            services.AddTransient<IChangeGroupColor, ChangeGroupColor>();
            services.AddTransient<ICreateGroup, CreateGroup>();
            services.AddTransient<ICreateTodo, CreateTodo>();
            services.AddTransient<ICreateUser, CreateUser>();
            services.AddTransient<IDeleteUser, DeleteUser>();
            services.AddTransient<IGetUser, GetUser>();
            services.AddTransient<IGetUsers, GetUsers>();
            services.AddTransient<IMakeCompletedTodo, MakeCompletedTodo>();
            services.AddTransient<IRemoveGroup, RemoveGroup>();
            services.AddTransient<IRemoveTodo, RemoveTodo>();
            services.AddTransient<IUpdateUser, UpdateUser>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "MultiTodoList Service V1"); });
            app.UseMvc();
        }
    }
}