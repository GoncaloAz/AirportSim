using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportSimulatorBackend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AirportSimulatorBackend
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

            const string postgresConnectionString = @"
                Host=ec2-54-228-174-49.eu-west-1.compute.amazonaws.com;
                Port=5432;
                Username=qwtwijwahxwwyj;
                Password=4d39425c61fd8f1f7a2e4fb8e394376a55895c19bad973b13fded8c8a8afe2b4;
                Database=dcad8acsr9sh15;
                Pooling=true;
                SSL Mode=Require;
                TrustServerCertificate=True;
                ";

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AirportSimulatorBackend", Version = "v1" });
            });

            services.AddDbContext<ApiContext>(opt => opt.UseNpgsql(postgresConnectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AirportSimulatorBackend v1"));
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
