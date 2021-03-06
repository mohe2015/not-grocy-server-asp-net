using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using NotGrocy.Models;
using NotGrocy;
using Microsoft.Data.Sqlite;

namespace NotGrocy
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
            // https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers?tabs=dotnet-core-cli
            // Set the active provider via configuration
            var provider = Configuration.GetValue("Provider", "Postgresql");

            services.AddDbContext<NotGrocyContext>(
                options => _ = provider switch
                {
                    "Sqlite" => options.UseSqlite(
                        Configuration.GetConnectionString("SqliteConnection"),
                        x => x.MigrationsAssembly("NotGrocy.SqliteMigrations")),
                    "Postgresql" => options.UseNpgsql(
                        Configuration.GetConnectionString("PostgresqlConnection"),
                        x => x.MigrationsAssembly("NotGrocy.PostgresqlMigrations")),
                    "Mysql" => options.UseMySql(
                        Configuration.GetConnectionString("MysqlConnection"),
                        Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect(Configuration.GetConnectionString("MysqlConnection")),
                        //Microsoft.EntityFrameworkCore.ServerVersion.Parse(Configuration.GetConnectionString("MysqlConnection")),
                        x => x.MigrationsAssembly("NotGrocy.MysqlMigrations")),

                    _ => throw new Exception($"Unsupported provider: {provider}")
                });
            
            services.AddControllers().AddJsonOptions(options => {
                // This is just a quick fix - the api should probably be designed differently.
                // options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NotGrocy", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NotGrocy v1"));
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
