using System.Data;
using Dapper.FastCrud;
using FluentValidation.AspNetCore;
using HospitalService.Abstractions;
using HospitalService.Configurations;
using HospitalService.Filters;
using HospitalService.Services;
using HospitalService.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;

namespace HospitalService
{
    public class Startup
    { 
        public string CurrentDirectory { get; set; }
        public Startup(IConfiguration configuration)
        {
            OrmConfiguration.DefaultDialect = SqlDialect.MySql;
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Register env and config services
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>
            (provider => new ConfigurationService(provider.GetService<IEnvironmentService>())
            {
                CurrentDirectory = CurrentDirectory
            });

            // Db Connection
            services.AddTransient<IDbConnection>(serviceProvider =>
            {
                var configService = serviceProvider.GetService<IConfigurationService>();
                var connectionString = configService.GetConfiguration().GetConnectionString("HospitalDbConnection");
                return new MySqlConnection(connectionString);
            });
            
            // Register Hospital Repository, if need to hook up a different repository then interface it with IHospitalRepository 
            services.AddSingleton<IHospitalRepository, MockHospitalService>();

            // Injecting Validation Filter
            services.AddScoped<ValidationFilter>();
            services.AddControllers()
                .AddFluentValidation(fv => 
                    fv.RegisterValidatorsFromAssemblyContaining<HospitalValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
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
