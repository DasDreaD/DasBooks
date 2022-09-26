using DasBooksAPI.Options;
using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Persistence;
using Persistence.DbContexts.DasBooks;
using Persistence.Repositories;
using System.Data;
using System.Reflection;

namespace DasBooksAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;
            services.AddControllers(setupAction => setupAction.ReturnHttpNotAcceptable = true)
                .AddXmlSerializerFormatters()
                .AddApplicationPart(presentationAssembly);

            var applicationAssembly = typeof(Application.AssemblyReference).Assembly;
            services.AddMediatR(applicationAssembly);

            services.AddScoped<IDbConnection>(db => new SqlConnection(Configuration.GetConnectionString("DasbooksDb")));

            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();

            services.ConfigureOptions<DatabaseOptionsSetup>();

            services.AddDbContext<DasBooksDbContext>(
                (serviceProvider, options) =>
                {
                    var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>().Value;
                    var connectionString = databaseOptions.ConnectionString;
                    options.UseSqlServer(connectionString, sqlServerOptionsAction =>
                    {
                        sqlServerOptionsAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                        sqlServerOptionsAction.CommandTimeout(databaseOptions.CommandTimeout);
                    });
                    options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
                    options.EnableDetailedErrors(databaseOptions.EnableDetailedError);
                });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options =>
                {
                    options.Run(async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsync("An unexpected fault happened. Please try again later");
                    });
                });
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
