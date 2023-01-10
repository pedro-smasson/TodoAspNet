using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Commands.Handlers;
using Todo.Domain.Repositories;
using Todo.Infra.Contexts;
using Todo.Infra.Repositories;

namespace Todo.Api
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
            services.AddControllers();

            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("Database"));
            //services.AddDbContext<TodoContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddTransient<ITodoRepository, TodoRepository>();

            services.AddTransient<CreateTodoHandler, CreateTodoHandler>();
            services.AddTransient<UpdateTodoHandler, UpdateTodoHandler>();
            services.AddTransient<MarkTodoAsDoneHandler, MarkTodoAsDoneHandler>();
            services.AddTransient<MarkTodoAsUndoneHandler, MarkTodoAsUndoneHandler>();

            //services
            //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(opt =>
            //    {
            //        opt.Authority = "https://securetoken.google.com/todoappaspnet";
            //        opt.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidIssuer = "https://securetoken.google.com/todoappaspnet",
            //            ValidateAudience = true,
            //            ValidAudience = "todoappaspnet",
            //            ValidateLifetime = true
            //        };
            //    });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}